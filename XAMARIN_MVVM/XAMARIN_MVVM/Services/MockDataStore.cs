using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XAMARIN_MVVM.Models;

namespace XAMARIN_MVVM.Services
{
    public  static class MockDataStore
    {
        public static List<Item> items = new List<Item>();

        public static void PopulateItems()
        {
            items.Add(new Models.Item { Id = Guid.NewGuid().ToString(), Text = "Milk", Description = "2L" , Price=1.5f});
            items.Add(new Models.Item { Id = Guid.NewGuid().ToString(), Text = "Eggs", Description = "2 Packs", Price=2f });
            items.Add(new Models.Item { Id = Guid.NewGuid().ToString(), Text = "Sugar", Description = "1Kg" , Price=0.5f});
            items.Add(new Models.Item { Id = Guid.NewGuid().ToString(), Text = "Meat spices", Description = "Spicy", Price=1f });

        }
        public static List<Item> GetItemsAsync()
        {
            return items;
        }

        public static bool AddItemAsync(Item item)
        {
            items.Add(item);

            return true;
        }
        public static void Delete(Item item)
        {
            items.Remove(item);
        }
    

        public static Item GetItemAsync(string id)
        {
            foreach(var Item in items)
            {
                if (Item.Id == id)
                {
                    return Item;
                }
                
            }
            return new Item();
        }
        public static double GetSum()
        {
            double sum = 0;
            foreach(var item in items)
            {
                sum += item.Price;
            }
            return sum;
        }
      
    }
}