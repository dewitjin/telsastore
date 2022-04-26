using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;


namespace StoreAPI.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateItems(Item item)
        {
            _db.Add(item);
            return Save();
        }

        public Item GetItem(int itemId)
        {
            return _db.Items.FirstOrDefault(x => x.Id == itemId);
        }

        public ICollection<Item> GetItems()
        {
            return _db.Items.OrderBy(x => x.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
