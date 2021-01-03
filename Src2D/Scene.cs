using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Src2D.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Src2D
{
    public abstract class Scene
    {
        const int ID_LEGNTH = 10;

        public bool HasStarted { get => hasStarted; }
        private bool hasStarted;

        public SceneEnityColection Entities { get => entities; }
        private SceneEnityColection entities;

        public Dictionary<string, List<BaseEntity>> EntityQuerys { get => entityQuerys; }
        private readonly Dictionary<string, List<BaseEntity>> entityQuerys
            = new Dictionary<string, List<BaseEntity>>();

        public Scene()
        {
            entities = new SceneEnityColection(this, ID_LEGNTH);
        }

        public void Start()
        {
            CreateEnities();
            BindEntityEvents();

            hasStarted = true;
        }

        public abstract void CreateEnities();
        public abstract void BindEntityEvents();

        public void Update(float deltaTime)
        {
            Entities?.ForEach(ent =>
            {
                if (ent is IUpdateEntity updateEntity && ent.HasStarted)
                {
                    updateEntity.Update(deltaTime);
                }
            });
        }

        public void Draw2D(SpriteBatch spriteBatch)
        {
            Entities?.ForEach(ent =>
            {
                if (ent is IDraw2DEntity draw2DEntity && ent.HasStarted)
                {
                    draw2DEntity.Draw(spriteBatch);
                }
            });
        }

        public void End()
        {
            entities?.Clear();
            entities = null;
        }
    }

    public class SceneEnityColection : ICollection<BaseEntity>, IEnumerable<BaseEntity>, IList<BaseEntity>
    {
        private readonly int idLegnth;

        private readonly List<BaseEntity> entities = new List<BaseEntity>();
        private readonly List<string> takenIDs = new List<string>();

        public int Count => entities.Count;

        public bool IsReadOnly => false;

        public BaseEntity this[int index] { get => entities[index]; set => entities[index] = value; }
        public BaseEntity this[string id] { get => entities.First(ent => ent.ID == id); }

        public Scene Owner { get => owner; }
        private Scene owner;

        public SceneEnityColection(Scene owner, int idLegnth)
        {
            this.owner = owner;
            this.idLegnth = idLegnth;
        }

        public void Add(BaseEntity item)
        {
            Add(item, (entity) => { });
        }

        public void Add(BaseEntity item, string name)
        {
            Add(item, (entity) =>
            {
                entity.Name = name;
            });
        }

        public void Add(BaseEntity item, Action<BaseEntity> builder)
        {
            if (item != null && item.Owner == null)
            {
                item.Initialize(owner, GetNewID());

                entities.Add(item);

                builder?.Invoke(item);

                if (!item.HasStarted)
                    item.Start();
            }
        }

        public void Clear()
        {
            entities.ForEach(entity => entity.End());
            entities.Clear();
        }

        public bool Contains(BaseEntity item)
        {
            return entities.Contains(item);
        }

        public void CopyTo(BaseEntity[] array, int arrayIndex)
        {
            entities.CopyTo(array, arrayIndex);
        }

        public IEnumerator<BaseEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public bool Remove(BaseEntity item)
        {
            if (entities.Remove(item))
            {
                item.End();
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public int IndexOf(BaseEntity item)
        {
            return entities.IndexOf(item);
        }

        public void Insert(int index, BaseEntity item)
        {
            if (item != null && item.Owner == null)
            {
                item.Initialize(owner, GetNewID());

                entities.Insert(index, item);
                if (!item.HasStarted)
                    item.Start();
            }
        }

        public void RemoveAt(int index)
        {
            Remove(entities[index]);
        }

        public void ForEach(Action<BaseEntity> action)
        {
            entities.ForEach(action);
        }

        private Random rand = new Random();
        private string GetNewID()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";

            string newID = "";
            while (newID.Length < idLegnth)
            {
                newID += chars[rand.Next(0, chars.Length)];
            }

            if (takenIDs.Contains(newID)) return GetNewID();

            takenIDs.Add(newID);
            return newID;
        }
    }
}
