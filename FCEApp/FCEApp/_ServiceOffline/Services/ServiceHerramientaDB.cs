using LiteDB;
using System;
using System.Collections.Generic;

namespace FCEApp
{
    public class ServiceHerramientaDB : LiteDBService<Herramientas>
    {
        public ServiceHerramientaDB()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<Herramientas>()
                .Id(x => x.Id);
        }
        public override Herramientas CreateItem(Herramientas item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override Herramientas DeleteItemAsync(Herramientas item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override Herramientas UpdateItem(Herramientas item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<Herramientas> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
