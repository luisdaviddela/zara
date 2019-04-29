using LiteDB;
using System;
using System.Collections.Generic;

namespace FCEApp
{
    public class ServiceLineaSVivaDB : LiteDBService<LineaSViva>
    {
        public ServiceLineaSVivaDB()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<LineaSViva>()
                .Id(x => x.Id);
        }
        public override LineaSViva CreateItem(LineaSViva item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override LineaSViva DeleteItemAsync(LineaSViva item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override LineaSViva UpdateItem(LineaSViva item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<LineaSViva> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
