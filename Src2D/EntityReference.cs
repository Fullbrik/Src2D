using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public class EntityReference
    {
        public string Query { get; }
        public List<BaseEntity> Entities { get; }

        public EntityReference(string query, Scene scene)
        {
            Query = query;
            if(!scene.EntityQuerys.ContainsKey(query)) 
                scene.EntityQuerys.Add(query, new List<BaseEntity>());

            Entities = scene.EntityQuerys[query];
        }

        public void Do(Action<BaseEntity> action)
        {
            Entities.ForEach(action);
        }
    }
}
