using System;
using LiteDB;
using System.Collections.Generic;
namespace FCEApp
{
    public class ServiceEqSegDB : LiteDBService<EqSeg>
    {
        public ServiceEqSegDB()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<EqSeg>()
                .Id(x => x.Id);
        }
        public override EqSeg CreateItem(EqSeg item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override EqSeg DeleteItemAsync(EqSeg item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override EqSeg UpdateItem(EqSeg item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<EqSeg> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
