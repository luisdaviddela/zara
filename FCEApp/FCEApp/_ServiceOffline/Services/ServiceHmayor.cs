using LiteDB;
using System;
using System.Collections.Generic;
namespace FCEApp
{
    public class ServiceHmayor : LiteDBService<HMayor>
    {
        public ServiceHmayor()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<HMayor>()
                .Id(x => x.Id);
        }
        public override HMayor CreateItem(HMayor item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override HMayor DeleteItemAsync(HMayor item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override HMayor UpdateItem(HMayor item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<HMayor> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
