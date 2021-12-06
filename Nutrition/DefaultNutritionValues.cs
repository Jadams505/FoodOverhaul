using Terraria.ID;
using System.Collections.Generic;
using FoodOverhaul.Items.Food;
using Terraria.ModLoader;

namespace FoodOverhaul.Nutrition
{
    public class DefaultNutritionValues
    {
        public static HashSet<ItemNutritionPair> RealisticDefault()
        {
            HashSet<ItemNutritionPair> set = new();

            //Vanilla Foods

            set.Add(VanillaEntry(ItemID.CookedMarshmallow, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0));
            set.Add(VanillaEntry(ItemID.AppleJuice, calories: 100, fat: 0, sodium: 8, carbs: 24, protein: 0));
            set.Add(VanillaEntry(ItemID.BloodyMoscato, calories: 155, fat: 1, sodium: 470, carbs: 3, protein: 2));
            set.Add(VanillaEntry(ItemID.BowlofSoup, calories: 95, fat: 6, sodium: 830, carbs: 8, protein: 2));
            set.Add(VanillaEntry(ItemID.BunnyStew, calories: 200, fat: 11, sodium: 760, carbs: 15, protein: 9));
            set.Add(VanillaEntry(ItemID.CookedFish, calories: 150, fat: 4, sodium: 110, carbs: 0, protein: 28));
            set.Add(VanillaEntry(ItemID.CookedShrimp, calories: 100, fat: 2, sodium: 800, carbs: 1, protein: 19));
            set.Add(VanillaEntry(ItemID.Escargot, calories: 50, fat: 1, sodium: 150, carbs: 1, protein: 10));
            set.Add(VanillaEntry(ItemID.FroggleBunwich, calories: 200, fat: 12, sodium: 360, carbs: 30, protein: 22));
            set.Add(VanillaEntry(ItemID.BananaDaiquiri, calories: 150, fat: 0, sodium: 0, carbs: 39, protein: 0));
            set.Add(VanillaEntry(ItemID.FruitJuice, calories: 100, fat: 0, sodium: 130, carbs: 26, protein: 0));
            set.Add(VanillaEntry(ItemID.FruitSalad, calories: 80, fat: 0, sodium: 6, carbs: 20, protein: 1));
            set.Add(VanillaEntry(ItemID.GoldenDelight, calories: 2000, fat: 60, sodium: 500, carbs: 50, protein: 40));
            set.Add(VanillaEntry(ItemID.GrapeJuice, calories: 125, fat: 0, sodium: 10, carbs: 31, protein: 1));
            set.Add(VanillaEntry(ItemID.GrilledSquirrel, calories: 240, fat: 7, sodium: 170, carbs: 0, protein: 43));
            set.Add(VanillaEntry(ItemID.GrubSoup, calories: 150, fat: 5, sodium: 200, carbs: 10, protein: 11));
            set.Add(VanillaEntry(ItemID.Lemonade, calories: 120, fat: 0, sodium: 14, carbs: 30, protein: 0));
            set.Add(VanillaEntry(ItemID.LobsterTail, calories: 80, fat: 0, sodium: 400, carbs: 0, protein: 16));
            set.Add(VanillaEntry(ItemID.MonsterLasagna, calories: 350, fat: 12, sodium: 1000, carbs: 40, protein: 19));
            set.Add(VanillaEntry(ItemID.PeachSangria, calories: 200, fat: 0, sodium: 23, carbs: 19, protein: 0));
            set.Add(VanillaEntry(ItemID.PinaColada, calories: 340, fat: 5, sodium: 14, carbs: 44, protein: 1));
            set.Add(VanillaEntry(ItemID.PrismaticPunch, calories: 180, fat: 0, sodium: 50, carbs: 46, protein: 0));
            set.Add(VanillaEntry(ItemID.RoastedBird, calories: 200, fat: 12, sodium: 500, carbs: 5, protein: 18));
            set.Add(VanillaEntry(ItemID.RoastedDuck, calories: 250, fat: 21, sodium: 700, carbs: 2, protein: 14));
            set.Add(VanillaEntry(ItemID.SauteedFrogLegs, calories: 80, fat: 0, sodium: 3, carbs: 0, protein: 18));
            set.Add(VanillaEntry(ItemID.SeafoodDinner, calories: 330, fat: 11, sodium: 600, carbs: 47, protein: 10));
            set.Add(VanillaEntry(ItemID.SmoothieofDarkness, calories: 110, fat: 0, sodium: 4, carbs: 27, protein: 1));
            set.Add(VanillaEntry(ItemID.TropicalSmoothie, calories: 100, fat: 0, sodium: 50, carbs: 21, protein: 3));
            set.Add(VanillaEntry(ItemID.PumpkinPie, calories: 2000, fat: 75, sodium: 1000, carbs: 300, protein: 20));
            set.Add(VanillaEntry(ItemID.Ale, calories: 70, fat: 0, sodium: 24, carbs: 17, protein: 0));
            set.Add(VanillaEntry(ItemID.Teacup, calories: 0, fat: 0, sodium: 0, carbs: 0, protein: 0));
            set.Add(VanillaEntry(ItemID.Sashimi, calories: 110, fat: 1, sodium: 125, carbs: 4, protein: 21));
            set.Add(VanillaEntry(ItemID.Apple, calories: 100, fat: 0, sodium: 2, carbs: 25, protein: 0));
            set.Add(VanillaEntry(ItemID.Apricot, calories: 75, fat: 1, sodium: 2, carbs: 17, protein: 2));
            set.Add(VanillaEntry(ItemID.Banana, calories: 100, fat: 0, sodium: 1, carbs: 29, protein: 2));
            set.Add(VanillaEntry(ItemID.BlackCurrant, calories: 50, fat: 0, sodium: 0, carbs: 13, protein: 0));
            set.Add(VanillaEntry(ItemID.BloodOrange, calories: 50, fat: 0, sodium: 0, carbs: 12, protein: 0));
            set.Add(VanillaEntry(ItemID.Cherry, calories: 100, fat: 0, sodium: 0, carbs: 24, protein: 2));
            set.Add(VanillaEntry(ItemID.Coconut, calories: 230, fat: 10, sodium: 5, carbs: 4, protein: 1));
            set.Add(VanillaEntry(ItemID.Dragonfruit, calories: 80, fat: 2, sodium: 0, carbs: 17, protein: 1));
            set.Add(VanillaEntry(ItemID.Elderberry, calories: 105, fat: 1, sodium: 9, carbs: 27, protein: 1));
            set.Add(VanillaEntry(ItemID.Grapefruit, calories: 130, fat: 1, sodium: 0, carbs: 33, protein: 3));
            set.Add(VanillaEntry(ItemID.Lemon, calories: 60, fat: 1, sodium: 3, carbs: 19, protein: 2));
            set.Add(VanillaEntry(ItemID.Mango, calories: 125, fat: 1, sodium: 2, carbs: 31, protein: 2));
            set.Add(VanillaEntry(ItemID.Peach, calories: 65, fat: 0, sodium: 20, carbs: 15, protein: 1));
            set.Add(VanillaEntry(ItemID.Pineapple, calories: 80, fat: 0, sodium: 2, carbs: 22, protein: 1));
            set.Add(VanillaEntry(ItemID.Plum, calories: 70, fat: 0, sodium: 0, carbs: 18, protein: 1));
            set.Add(VanillaEntry(ItemID.Rambutan, calories: 120, fat: 0, sodium: 17, carbs: 31, protein: 1));
            set.Add(VanillaEntry(ItemID.Starfruit, calories: 30, fat: 0, sodium: 2, carbs: 7, protein: 1));
            set.Add(VanillaEntry(ItemID.ApplePie, calories: 1880, fat: 60, sodium: 1200, carbs: 250, protein: 14));
            set.Add(VanillaEntry(ItemID.Bacon, calories: 370, fat: 30, sodium: 1200, carbs: 1, protein: 26));
            set.Add(VanillaEntry(ItemID.BananaSplit, calories: 965, fat: 34, sodium: 400, carbs: 150, protein: 12));
            set.Add(VanillaEntry(ItemID.BBQRibs, calories: 460, fat: 20, sodium: 1100, carbs: 40, protein: 21));
            set.Add(VanillaEntry(ItemID.Burger, calories: 600, fat: 33, sodium: 900, carbs: 47, protein: 31));
            set.Add(VanillaEntry(ItemID.MilkCarton, calories: 140, fat: 8, sodium: 90, carbs: 11, protein: 8));
            set.Add(VanillaEntry(ItemID.ChickenNugget, calories: 50, fat: 3, sodium: 90, carbs: 3, protein: 2));
            set.Add(VanillaEntry(ItemID.ChocolateChipCookie, calories: 220, fat: 11, sodium: 140, carbs: 29, protein: 2));
            set.Add(VanillaEntry(ItemID.CoffeeCup, calories: 80, fat: 1, sodium: 32, carbs: 19, protein: 0));
            set.Add(VanillaEntry(ItemID.CreamSoda, calories: 180, fat: 0, sodium: 60, carbs: 47, protein: 0));
            set.Add(VanillaEntry(ItemID.FriedEgg, calories: 90, fat: 7, sodium: 95, carbs: 0, protein: 6));
            set.Add(VanillaEntry(ItemID.Fries, calories: 220, fat: 11, sodium: 134, carbs: 30, protein: 3));
            set.Add(VanillaEntry(ItemID.Grapes, calories: 100, fat: 9, sodium: 3, carbs: 27, protein: 1));
            set.Add(VanillaEntry(ItemID.Hotdog, calories: 350, fat: 16, sodium: 630, carbs: 34, protein: 16));
            set.Add(VanillaEntry(ItemID.IceCream, calories: 300, fat: 15, sodium: 103, carbs: 38, protein: 5));
            set.Add(VanillaEntry(ItemID.Milkshake, calories: 400, fat: 12, sodium: 140, carbs: 74, protein: 7));
            set.Add(VanillaEntry(ItemID.Nachos, calories: 450, fat: 28, sodium: 413, carbs: 46, protein: 6));
            set.Add(VanillaEntry(ItemID.Pizza, calories: 300, fat: 14, sodium: 600, carbs: 29, protein: 11));
            set.Add(VanillaEntry(ItemID.PotatoChips, calories: 150, fat: 10, sodium: 150, carbs: 15, protein: 2));
            set.Add(VanillaEntry(ItemID.ShrimpPoBoy, calories: 370, fat: 12, sodium: 1800, carbs: 41, protein: 23));
            set.Add(VanillaEntry(ItemID.ShuckedOyster, calories: 120, fat: 4, sodium: 211, carbs: 7, protein: 14));
            set.Add(VanillaEntry(ItemID.Spaghetti, calories: 400, fat: 12, sodium: 1000, carbs: 53, protein: 20));
            set.Add(VanillaEntry(ItemID.Steak, calories: 250, fat: 6, sodium: 118, carbs: 0, protein: 49));
            set.Add(VanillaEntry(ItemID.ChristmasPudding, calories: 360, fat: 12, sodium: 350, carbs: 60, protein: 5));
            set.Add(VanillaEntry(ItemID.GingerbreadCookie, calories: 220, fat: 4, sodium: 245, carbs: 43, protein: 4));
            set.Add(VanillaEntry(ItemID.SugarCookie, calories: 190, fat: 9, sodium: 15, carbs: 26, protein: 1));
            set.Add(VanillaEntry(ItemID.Marshmallow, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0));
            set.Add(VanillaEntry(ItemID.PadThai, calories: 300, fat: 15, sodium: 770, carbs: 29, protein: 16));
            set.Add(VanillaEntry(ItemID.Pho, calories: 215, fat: 6, sodium: 980, carbs: 25, protein: 15));
            set.Add(VanillaEntry(ItemID.Sake, calories: 140, fat: 0, sodium: 2, carbs: 0, protein: 0));

            //Modded Foods

            foreach (ModFood food in ModContent.GetContent<ModFood>())
            {
                set.Add(new ItemNutritionPair(food.Type, food.GetNutrition()));
            }
            return set;
        }

        private static ItemNutritionPair VanillaEntry(int id, int calories = 0, int fat = 0, int sodium = 0, int carbs = 0, int protein = 0)
        {
            return new ItemNutritionPair(id, new NutritionData(calories, fat, sodium, carbs, protein));
        }
    }

}

