using System;
using System.Collections.Generic;

namespace Bars_Task_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Entity> list = new List<Entity>()
            {
                new Entity {Id = 1, ParentId = 0, Name = "Root entity"},
                new Entity {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };
            var parents = Parents(list);
        }
        public class Entity
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Name { get; set; }
        }
        public static Dictionary<int, List<Entity>> Parents(List<Entity> entityis)
        {
            var result = new Dictionary<int, List<Entity>>();
            foreach (var entity in entityis)
            {
                result.TryAdd(entity.ParentId, new List<Entity>());
                result[entity.ParentId].Add(entity);
            }
            return result;
        }
    }
}
