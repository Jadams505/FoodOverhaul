namespace FoodOverhaul.Classes
{
    public class Nutrition
    {

        public const int MAX = 100;
        public int protein { get; set; }
        public int fruit { get; set; }
        public int vegatable { get; set; }
        public int dairy { get; set; }
        public int carbs { get; set; }

        public Nutrition Protein(int protein)
        {
            this.protein = protein;
            return this;
        }

        public Nutrition Fruit(int fruit)
        {
            this.fruit = fruit;
            return this;
        }

        public Nutrition Vegatable(int vegatable)
        {
            this.vegatable = vegatable;
            return this;
        }
        public Nutrition Dairy(int dairy)
        {
            this.dairy = dairy;
            return this;
        }
        public Nutrition Carbs(int carbs)
        {
            this.carbs = carbs;
            return this;
        }

        private static int Decrement(int field, int amount)
        {
            return field - amount > 0 ? field - amount : 0;
        }

        public void Decrement()
        {
            protein = Decrement(protein, 1);
            carbs = Decrement(carbs, 1);
            dairy = Decrement(dairy, 1);
            fruit = Decrement(fruit, 1);
            vegatable = Decrement(vegatable, 1);
        }

        private static int Add(int field, int amount)
        {
            return field + amount < MAX ? field + amount : MAX;
        }

        public void Add(Nutrition other)
        {
            if(other == null)
            {
                other = new();
            }
            protein = Add(protein, other.protein);
            carbs = Add(carbs, other.carbs);
            dairy = Add(dairy, other.dairy);
            fruit = Add(fruit, other.fruit);
            vegatable = Add(vegatable, other.vegatable);
        }

        public static Nutrition Full()
        {
            return new Nutrition().Vegatable(MAX).Dairy(MAX).Fruit(MAX).Carbs(MAX).Protein(MAX);
        }


        public override string ToString()
        {
            return "Protein " + protein + "\n" + "Carbs " + carbs + "\n" +
                "Dairy " + dairy + "\n" + "Fruit " + fruit + "\n" + "Vegatable " + vegatable; 
        }
    }
}
