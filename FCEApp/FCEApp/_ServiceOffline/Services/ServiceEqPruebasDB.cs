using LiteDB;
using System;
using System.Collections.Generic;

namespace FCEApp
{
    public class ServiceEqPruebasDB : LiteDBService<EqPrueba>
    {
        public ServiceEqPruebasDB()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<EqPrueba>()
                .Id(x => x.Id);
        }
        public override EqPrueba CreateItem(EqPrueba item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override EqPrueba DeleteItemAsync(EqPrueba item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override EqPrueba UpdateItem(EqPrueba item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<EqPrueba> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
