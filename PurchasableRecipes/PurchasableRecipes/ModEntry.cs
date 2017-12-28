using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace PurchasableRecipes
{
    class ModEntry : Mod
    {
        public bool recipesAdded;


        public override void Entry(IModHelper helper)
        {
            MenuEvents.MenuChanged += OnMenuChanged;
            MenuEvents.MenuClosed += OnMenuClosed;
            ModConfig config = helper.ReadConfig<ModConfig>();

        }

        private void OnMenuChanged(object sender, EventArgsClickableMenuChanged e)
        {
            if (Game1.activeClickableMenu != null && Game1.activeClickableMenu is ShopMenu && !recipesAdded)
            {
                ShopMenu shop = (ShopMenu)Game1.activeClickableMenu;
                if (shop.portraitPerson.name == "Gus")
                {
                    List<Item> stock = addRecipesToStock();
                    recipesAdded = true;
                    Game1.activeClickableMenu = new ShopMenu(stock, 0, "Gus");
                }
            }
        }



        private void OnMenuClosed(object sender, EventArgsClickableMenuClosed e)
        {
            recipesAdded = false;
        }

        private List<Item> addRecipesToStock()
        {
            ModConfig config = Helper.ReadConfig<ModConfig>();
            List<Item> stock = Utility.getSaloonStock();
            if (config.allRecipesUnlockedImmediately)
            {
                stock = addAllRecipesToStock(stock, config);
            }
            else if (!config.allRecipesUnlockedImmediately)
            {
                stock = addSelectRecipesToStock(stock, config);
            }
            return stock;
        }

        private List<Item> addSelectRecipesToStock(List<Item> stock, ModConfig config)
        {
            if (!Game1.player.cookingRecipes.ContainsKey("Trout Soup") && dateRequirement(SDate.Now(), new SDate(14, "fall", 1)))
                stock.Add((Item)new StardewValley.Object(219, 1, true, config.troutSoup, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Blackberry Cobbler") && dateRequirement(SDate.Now(), new SDate(14, "fall", 2)))
                stock.Add((Item)new StardewValley.Object(611, 1, true, config.blackberryCobbler, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Coleslaw") && dateRequirement(SDate.Now(), new SDate(14, "spring", 1)))
                stock.Add((Item)new StardewValley.Object(648, 1, true, config.coleslaw, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Maple Bar") && dateRequirement(SDate.Now(), new SDate(14, "summer", 2)))
                stock.Add((Item)new StardewValley.Object(731, 1, true, config.mapleBar, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Chocolate Cake") && dateRequirement(SDate.Now(), new SDate(14, "winter", 1)))
                stock.Add((Item)new StardewValley.Object(220, 1, true, config.chocolateCake, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Glazed Yams") && dateRequirement(SDate.Now(), new SDate(21, "fall", 1)))
                stock.Add((Item)new StardewValley.Object(208, 1, true, config.glazedYam, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Crab Cakes") && dateRequirement(SDate.Now(), new SDate(21, "fall", 2)))
                stock.Add((Item)new StardewValley.Object(732, 1, true, config.crabCakes, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Radish Salad") && dateRequirement(SDate.Now(), new SDate(21, "spring", 1)))
                stock.Add((Item)new StardewValley.Object(609, 1, true, config.radishSalad, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Complete Breakfast") && dateRequirement(SDate.Now(), new SDate(21, "spring", 2)))
                stock.Add((Item)new StardewValley.Object(201, 1, true, config.completeBreakfast, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Pink Cake") && dateRequirement(SDate.Now(), new SDate(21, "summer", 2)))
                stock.Add((Item)new StardewValley.Object(221, 1, true, config.pinkCake, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Pumpkin Pie") && dateRequirement(SDate.Now(), new SDate(21, "winter", 1)))
                stock.Add((Item)new StardewValley.Object(608, 1, true, config.pumpkinPie, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Bruschetta") && dateRequirement(SDate.Now(), new SDate(21, "winter", 2)))
                stock.Add((Item)new StardewValley.Object(618, 1, true, config.brushetta, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Artichoke Dip") && dateRequirement(SDate.Now(), new SDate(28, "fall", 1)))
                stock.Add((Item)new StardewValley.Object(605, 1, true, config.artichokeDip, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Fiddlehead Risotto") && dateRequirement(SDate.Now(), new SDate(28, "fall", 2)))
                stock.Add((Item)new StardewValley.Object(649, 1, true, config.fiddleheadRisotto, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Lucky Lunch") && dateRequirement(SDate.Now(), new SDate(28, "spring", 2)))
                stock.Add((Item)new StardewValley.Object(204, 1, true, config.luckyLunch, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Roasted Hazelnuts") && dateRequirement(SDate.Now(), new SDate(28, "summer", 2)))
                stock.Add((Item)new StardewValley.Object(607, 1, true, config.roastedHazelnuts, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Cranberry Candy") && dateRequirement(SDate.Now(), new SDate(28, "winter", 1)))
                stock.Add((Item)new StardewValley.Object(612, 1, true, config.cranberryCandy, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Fruit Salad") && dateRequirement(SDate.Now(), new SDate(7, "fall", 2)))
                stock.Add((Item)new StardewValley.Object(610, 1, true, config.fruitSalad, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Stir Fry") && dateRequirement(SDate.Now(), new SDate(7, "spring", 1)))
                stock.Add((Item)new StardewValley.Object(606, 1, true, config.stirFry, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Baked Fish") && dateRequirement(SDate.Now(), new SDate(7, "summer", 1)))
                stock.Add((Item)new StardewValley.Object(198, 1, true, config.bakedFish, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Carp Surprise") && dateRequirement(SDate.Now(), new SDate(7, "summer", 2)))
                stock.Add((Item)new StardewValley.Object(209, 1, true, config.carpSurprise, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Plum Pudding") && dateRequirement(SDate.Now(), new SDate(7, "winter", 1)))
                stock.Add((Item)new StardewValley.Object(604, 1, true, config.plumPudding, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Poppyseed Muffin") && dateRequirement(SDate.Now(), new SDate(7, "winter", 2)))
                stock.Add((Item)new StardewValley.Object(651, 1, true, config.poppyseedMuffin, 0));
            return stock;
        }

        private bool dateRequirement(SDate currentDate, SDate comparedDate)
        {
            if (currentDate >= comparedDate)
            {
                return true;
            }
            else return false;
        }

        private List<Item> addAllRecipesToStock(List<Item> stock, ModConfig config)
        {

            if (!Game1.player.cookingRecipes.ContainsKey("Trout Soup"))
                stock.Add((Item)new StardewValley.Object(219, 1, true, config.troutSoup, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Blackberry Cobbler"))
                stock.Add((Item)new StardewValley.Object(611, 1, true, config.blackberryCobbler, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Coleslaw"))
                stock.Add((Item)new StardewValley.Object(648, 1, true, config.coleslaw, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Maple Bar"))
                stock.Add((Item)new StardewValley.Object(731, 1, true, config.mapleBar, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Chocolate Cake"))
                stock.Add((Item)new StardewValley.Object(220, 1, true, config.chocolateCake, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Glazed Yams"))
                stock.Add((Item)new StardewValley.Object(208, 1, true, config.glazedYam, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Crab Cakes"))
                stock.Add((Item)new StardewValley.Object(732, 1, true, config.crabCakes, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Radish Salad"))
                stock.Add((Item)new StardewValley.Object(609, 1, true, config.radishSalad, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Complete Breakfast"))
                stock.Add((Item)new StardewValley.Object(201, 1, true, config.completeBreakfast, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Pink Cake"))
                stock.Add((Item)new StardewValley.Object(221, 1, true, config.pinkCake, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Pumpkin Pie"))
                stock.Add((Item)new StardewValley.Object(608, 1, true, config.pumpkinPie, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Bruschetta"))
                stock.Add((Item)new StardewValley.Object(618, 1, true, config.brushetta, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Artichoke Dip"))
                stock.Add((Item)new StardewValley.Object(605, 1, true, config.artichokeDip, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Fiddlehead Risotto"))
                stock.Add((Item)new StardewValley.Object(649, 1, true, config.fiddleheadRisotto, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Lucky Lunch"))
                stock.Add((Item)new StardewValley.Object(204, 1, true, config.luckyLunch, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Roasted Hazelnuts"))
                stock.Add((Item)new StardewValley.Object(607, 1, true, config.roastedHazelnuts, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Cranberry Candy"))
                stock.Add((Item)new StardewValley.Object(612, 1, true, config.cranberryCandy, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Fruit Salad"))
                stock.Add((Item)new StardewValley.Object(610, 1, true, config.fruitSalad, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Stir Fry"))
                stock.Add((Item)new StardewValley.Object(606, 1, true, config.stirFry, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Baked Fish"))
                stock.Add((Item)new StardewValley.Object(198, 1, true, config.bakedFish, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Carp Surprise"))
                stock.Add((Item)new StardewValley.Object(209, 1, true, config.carpSurprise, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Plum Pudding"))
                stock.Add((Item)new StardewValley.Object(604, 1, true, config.plumPudding, 0));
            if (!Game1.player.cookingRecipes.ContainsKey("Poppyseed Muffin"))
                stock.Add((Item)new StardewValley.Object(651, 1, true, config.poppyseedMuffin, 0));
            return stock;
        }

    }
    class ModConfig
    {
        public bool allRecipesUnlockedImmediately;
        //public bool includeOnlyQueenOfSauceRecipes;

        public Int32 troutSoup = 50;
        public Int32 blackberryCobbler = 130;
        public Int32 coleslaw = 172;
        public Int32 mapleBar = 150;
        public Int32 chocolateCake = 100;
        public Int32 glazedYam = 100;
        public Int32 crabCakes = 137;
        public Int32 radishSalad = 150;
        public Int32 completeBreakfast = 175;
        public Int32 pinkCake = 240;
        public Int32 pumpkinPie = 192;
        public Int32 brushetta = 105;
        public Int32 artichokeDip = 105;
        public Int32 fiddleheadRisotto = 175;
        public Int32 luckyLunch = 125;
        public Int32 roastedHazelnuts = 135;
        public Int32 cranberryCandy = 87;
        public Int32 fruitSalad = 225;
        public Int32 stirFry = 167;
        public Int32 bakedFish = 50;
        public Int32 carpSurprise = 75;
        public Int32 plumPudding = 130;
        public Int32 poppyseedMuffin = 125;

        public ModConfig()
        {
            allRecipesUnlockedImmediately = false;
            //includeOnlyQueenOfSauceRecipes = true; maybe in a later version
        }
    }
}

