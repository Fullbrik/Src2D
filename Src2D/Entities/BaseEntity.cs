using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Src2D.Attributes;
using Src2D.Data;

namespace Src2D.Entities
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

        [SrcProperty("Position", Description = "The position of the sprite")]
        public virtual Vector2 Position { get; set; } = Vector2.Zero;
        [SrcProperty("Rotation", Description = "The rotation of the sprite")]
        public virtual float Rotation { get; set; }
        [SrcProperty("Scale", Description = "The scale of the sprite")]
        public virtual Vector2 Scale { get; set; } = Vector2.One;
        [SrcProperty("FlipX", Description = "Weather to flip the sprite sideways")]
        public virtual bool FlipX { get; set; }
        [SrcProperty("FlipY", Description = "Weather to flip the sprite up and down")]
        public virtual bool FlipY { get; set; }
        [SrcProperty("Origin", Description = "The origin of the sprite (where to rotate it from, from 0-1. Use .5 to rotate from the center)")]
        public virtual Vector2 Origin { get; set; } = new Vector2(.5f, .5f);
        [SrcProperty("Color", Description = "The color to tint the sprite. Set it to white for no tint")]
        public virtual Color Color { get; set; } = Color.White;

        public bool HasStarted { get => hasStarted; }
        private bool hasStarted;

        public Scene Owner { get => owner; }
        private Scene owner;

        private readonly Dictionary<string, EventInfo> srcEvents = new Dictionary<string, EventInfo>();
        private readonly Dictionary<string, SrcEvent> srcActions = new Dictionary<string, SrcEvent>();
        private readonly Dictionary<string, PropertyInfo> srcProperties = new Dictionary<string, PropertyInfo>();
        private readonly Dictionary<string, FieldInfo> srcAssets = new Dictionary<string, FieldInfo>();

        private readonly List<Binding> bindings = new List<Binding>();

        internal void Initialize(Scene owner, string id)
        {
            this.owner = owner;
            this.id = id;

            BuildProperties();
            BuildAssets();
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

        private void BuildAssets()
        {
            var type = GetType();

            var assets = type.GetFields();

            foreach (var asset in assets)
            {
                if (Attribute.IsDefined(asset, typeof(SrcAssetAttribute)))
                {
                    var srcAssetAttr
                        = (SrcAssetAttribute)Attribute
                            .GetCustomAttribute(asset, typeof(SrcAssetAttribute));
                    srcAssets.Add(srcAssetAttr.Name, asset);
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
            if (Name != null)
            {
                var queries = Owner.EntityQuerys.Keys;
                foreach (var query in queries)
                {
                    if (Regex.IsMatch(Name, query))
                        Owner.EntityQuerys[query].Add(this);
                }
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

        public void CreateBinding(
            string eventName,
            string themQuery,
            string theirAction,
            bool overideParam,
            string paramOveride)
        {
            if (string.IsNullOrWhiteSpace(eventName)
                || string.IsNullOrWhiteSpace(themQuery)
                || string.IsNullOrWhiteSpace(theirAction))
                return;

            var evnt = srcEvents[eventName];
            EntityReference reff = new EntityReference(themQuery);
            reff.Setup(Owner);

            evnt.AddEventHandler(this, new SrcEvent((string param) =>
            {
                reff.Do(ent => ent.DoAction(theirAction, overideParam ? paramOveride : param));
            }));
        }

        public void DoAction(string action, string param)
        {
            srcActions[action].Invoke(param);
        }

        //public void Bind(string ourActionName, BaseEntity them, string theirEvent, bool overideParam, string paramOveride)
        //{
        //    if (them.srcEvents.ContainsKey(theirEvent))
        //    {
        //        var ourAction = (overideParam) ? (str) => srcActions[ourActionName](paramOveride)
        //                                       : srcActions[ourActionName];

        //        them.srcEvents[theirEvent].AddEventHandler(them, ourAction);

        //        bindings.Add(new Binding(ourAction, them, theirEvent));
        //    }
        //}

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

            value = PropertyData.FixValue(value,
                PropertyData.GetSrcPropertyTypeFor(prop));

            if (prop.PropertyType.IsSubclassOf(typeof(SrcSchema)))
            {
                prop.PropertyType
                    .GetMethod("PopulateFromDictionary")
                    .Invoke(prop.GetValue(this), new object[] { value });
            }
            else
            {
                prop.SetValue(this, value);
            }
        }

        public void SetAsset(string name, string assetName)
        {
            var asset = srcAssets[name];

            asset.SetValue(this, assetName);
        }
    }
}
