using Microsoft.Xna.Framework;
using Terraria.ID;
namespace FoodOverhaul.Classes
{
    public class Nutrition
    {
        public static readonly int MAX = 100;

        public struct Stat
        {
            public string Name { get; private set; }
            public int Val { get; set; }
            public Stat(string name)
            {
                Name = name;
                Val = 0;
            }

            public override string ToString()
            {
                return Name + " " + Val;
            }
        }

        public Stat Protein;
        public Stat Fruits;
        public Stat Vegatables;
        public Stat Dairy;
        public Stat Carbs;

        public Nutrition()
        {
            Protein = new Stat("Protein");
            Fruits = new Stat("Fruits");
            Vegatables = new Stat("Vegatables");
            Dairy = new Stat("Dairy");
            Carbs = new Stat("Carbs");
        }

        public Nutrition WithProtein(int protein)
        {
            Protein.Val = protein;
            return this;
        }

        public Nutrition WithFruits(int fruits)
        {
            Fruits.Val = fruits;
            return this;
        }

        public Nutrition WithVegatables(int vegatables)
        {
            Vegatables.Val = vegatables;
            return this;
        }
        public Nutrition WithDairy(int dairy)
        {
            Dairy.Val = dairy;
            return this;
        }
        public Nutrition WithCarbs(int carbs)
        {
            Carbs.Val = carbs;
            return this;
        }

        private static void Decrement(ref Stat stat, int amount)
        {
            if(stat.Val - amount > 0)
            {
                stat.Val -= amount;
            }
            else
            {
                stat.Val = 0;
            }
        }

        public void Decrement()
        {
            Decrement(ref Protein, 1);
            Decrement(ref Carbs, 1);
            Decrement(ref Dairy, 1);
            Decrement(ref Fruits, 1);
            Decrement(ref Vegatables, 1);
        }

        private static void Add(ref Stat stat, int amount)
        {
            if(stat.Val + amount < MAX)
            {
                stat.Val += amount;
            }
            else
            {
                stat.Val = MAX;
            }
        }

        public void Add(Nutrition other)
        {
            if(other == null)
            {
                other = new();
            }
            Add(ref Protein, other.Protein.Val);
            Add(ref Carbs, other.Carbs.Val);
            Add(ref Dairy, other.Dairy.Val);
            Add(ref Fruits, other.Fruits.Val);
            Add(ref Vegatables, other.Vegatables.Val);
        }

        public static Nutrition Full()
        {
            return new Nutrition().WithVegatables(MAX).WithDairy(MAX).WithFruits(MAX).WithCarbs(MAX).WithProtein(MAX);
        }

        public override string ToString()
        {
            return Protein.ToString() + "\n" + Carbs.ToString() + "\n" +
                Dairy.ToString() + "\n" + Fruits.ToString() + "\n" + Vegatables.ToString(); 
        }
    }
}
