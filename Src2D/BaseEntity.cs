using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Src2D
{
    [SrcEntity("Entity", Description = "A basic entity. doesn't do anything bat has the basic code all entities rely on")]
    public class BaseEntity
    {
        public bool IsActive { get => hasStarted && isActive; set => isActive = value; }
        private bool isActive = false;

        public string ID { get => id; }
        private string id;

        [SrcProperty("Name", DefaultValue = "", Description = "The name of the entity")]
        public string Name
        {
            get => name; 
            set
            {
                RealeseAllQueries();
                name = value;
                BindQueries();
            }
        }
        private string name;

        public bool HasStarted { get => hasStarted; }
        private bool hasStarted;

        public Scene Owner { get => owner; }
        private Scene owner;

        private readonly Dictionary<string, EventInfo> srcEvents = new Dictionary<string, EventInfo>();
        private readonly Dictionary<string, SrcEvent> srcActions = new Dictionary<string, SrcEvent>();
        private readonly Dictionary<string, PropertyInfo> srcProperties = new Dictionary<string, PropertyInfo>();

        private readonly List<Binding> bindings = new List<Binding>();

        internal void Initialize(Scene owner, string id)
        {
            this.owner = owner;
            this.id = id;

            BuildProperties();
            BuildSrcEvents();
            BuildSrcActions();
        }

        private void BuildSrcEvents()
        {
            var type = GetType();

            var events = type.GetEvents();

            foreach (var evnt in events)
            {
                if (evnt.EventHandlerType == typeof(SrcEvent) && Attribute.IsDefined(evnt, typeof(SrcEventAttribute)))
                {
                    var srcEventAttr = (SrcEventAttribute)Attribute.GetCustomAttribute(evnt, typeof(SrcEventAttribute));
                    srcEvents.Add(srcEventAttr.Name, evnt);
                }
            }
        }
        private void BuildSrcActions()
        {
            var type = GetType();

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var methodParams = method.GetParameters();
                if (methodParams.Length > 0 && methodParams[0].ParameterType == typeof(string)
                    && Attribute.IsDefined(method, typeof(SrcActionAttribute)))
                {
                    var srcActionAttr = (SrcActionAttribute)Attribute.GetCustomAttribute(method, typeof(SrcActionAttribute));

                    Delegate srcAction = method.CreateDelegate(typeof(SrcEvent), this);

                    srcActions.Add(srcActionAttr.Name, (SrcEvent)srcAction);
                }
            }
        }

        private void BuildProperties()
        {
            var type = GetType();

            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(SrcPropertyAttribute)))
                {
                    var srcPropertyAttr = (SrcPropertyAttribute)Attribute.GetCustomAttribute(prop, typeof(SrcPropertyAttribute));

                    srcProperties.Add(srcPropertyAttr.Name, prop);
                }
            }
        }

        public void RealeseAllQueries()
        {
            var queries = Owner.EntityQuerys.Keys;
            foreach (var query in queries)
            {
                Owner.EntityQuerys[query].Remove(this);
            }
        }

        public void BindQueries()
        {
            var queries = Owner.EntityQuerys.Keys;
            foreach (var query in queries)
            {
                if(Regex.IsMatch(Name, query))
                    Owner.EntityQuerys[query].Add(this);
            }
        }

        public virtual void PreCache()
        {

        }


        public virtual void Start()
        {
            PreCache();
            hasStarted = true;
        }

        [SrcEvent("OnEnd", ExportsParam = false, Description = "When the entity ends, right before getting destroyed")]
        public event SrcEvent OnEnd;
        public virtual void End()
        {
            hasStarted = false;
            OnEnd?.Invoke("");
            owner = null;
            UnbindAllActions();
        }

        public void Bind(string ourActionName, BaseEntity them, string theirEvent, bool overideParam, string paramOveride)
        {
            var ourAction = (overideParam) ? (str) => srcActions[ourActionName](paramOveride)
                                               : srcActions[ourActionName];

            them.srcEvents[theirEvent].AddEventHandler(them, ourAction);

            bindings.Add(new Binding(ourAction, them, theirEvent));
        }

        private void UnbindAllActions()
        {
            bindings.ForEach(b => UnbindActionWithoutRemove(b.OurAction, b.Them, b.TheirEvent));
            bindings.Clear();
        }

        private void UnbindActionWithoutRemove(SrcEvent ourAction, BaseEntity them, string theirEvent)
        {
            them.srcEvents[theirEvent].RemoveEventHandler(them, ourAction);
        }

        public void SetProperty(string name, object value)
        {
            var prop = srcProperties[name];

            prop.SetValue(this, value);
        }
    }
}
