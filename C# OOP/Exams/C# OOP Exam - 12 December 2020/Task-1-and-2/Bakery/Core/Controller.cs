using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            totalIncome = 0m;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink currDrink = null;

            if (type == "Tea")
            {
                currDrink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                currDrink = new Water(name, portion, brand);
            }
            string output = string.Empty;

            if (currDrink != null)
            {
                drinks.Add(currDrink);
                output = $"Added {name} ({brand}) to the drink menu";
            }

            return output;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood foods = null;

            // Enum.TryParse(type, out BakedFoodType bakedFoodType); ??????????

            if (type == "Bread")
            {
                foods = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                foods = new Cake(name, price);
            }
            string output = string.Empty;

            if (foods != null)
            {
                bakedFoods.Add(foods);
                output = $"Added {name} ({type}) to the menu";
            }

            return output;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            //ITable currTable = null;

            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            //string output = string.Empty;

            //if (currTable != null)
            //{
            //    tables.Add(currTable);
            //    output = $"Added table number {tableNumber} in the bakery";
            //}

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)              // ???????????????????
        {
            ITable currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            if (currTable != null)
            {
                decimal bill = currTable.GetBill();
                totalIncome += bill;

                currTable.Clear();

                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {bill:f2}");

            }

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink currDrink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (currDrink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            currTable.OrderDrink(currDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood currFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (currTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (currFood == null)
            {
                return $"No {foodName} in the menu";
            }

            currTable.OrderFood(currFood);

            return $"Table {tableNumber} ordered {foodName}";

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable currTable = tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);

            if (currTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                currTable.Reserve(numberOfPeople);
                return $"Table {currTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
