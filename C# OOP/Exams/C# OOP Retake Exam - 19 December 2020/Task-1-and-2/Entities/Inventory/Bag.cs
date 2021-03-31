using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private int capacity;
        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity 
        { 
            get => capacity; 
            set
            {
                if (value < 0 || value > DefaultCapacity) 
                {
                    capacity = DefaultCapacity;
                }
                else
                {
                    capacity = value;
                }
            } 
        }

        public int Load => Items.Sum(x=>x.Weight);

        public IReadOnlyCollection<Item> Items => throw new NotImplementedException();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!items.Any(x=>x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format($"No item with name {name} in bag!"));
            }

            Item item = items.FirstOrDefault(x => x.GetType().Name == name);


            items.Remove(item); // ????????


            return item;
        }
    }
}
