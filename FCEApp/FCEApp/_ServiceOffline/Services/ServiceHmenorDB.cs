using LiteDB;
using System;
using System.Collections.Generic;

namespace FCEApp
{
    public class ServiceHmenorDB : LiteDBService<HMenor>
    {
        public ServiceHmenorDB()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<HMenor>()
                .Id(x => x.Id);
        }
        public override HMenor CreateItem(HMenor item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override HMenor DeleteItemAsync(HMenor item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override HMenor UpdateItem(HMenor item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<HMenor> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
