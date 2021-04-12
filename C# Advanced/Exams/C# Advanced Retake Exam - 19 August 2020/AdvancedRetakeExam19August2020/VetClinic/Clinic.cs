using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        //public int Count { get { return data.Count; } }
        //or
        public int Count => data.Count;
        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);

            if (pet == null)
            {
                return false;
            }

            data.Remove(pet);
            return true;
        }
        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();

            statistics.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                statistics.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return statistics.ToString();
        }
    }
}
