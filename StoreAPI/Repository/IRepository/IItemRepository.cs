using StoreAPI.Models;
using System.Collections.Generic;


namespace StoreAPI.Repository.IRepository
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
        Item GetItem(int itemId);
        bool CreateItems(Item item);//Need to seed the db
        bool Save();
    }
}
