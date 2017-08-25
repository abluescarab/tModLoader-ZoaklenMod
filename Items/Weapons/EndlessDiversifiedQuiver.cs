using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class EndlessDiversifiedQuiver : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.HolyArrow);
			item.name = "Endless Diversified Quiver";
			item.toolTip = "Shoots random types of arrows";
			item.damage = 20;
			item.maxStack = 1;
			item.consumable = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EndlessHolyQuiver"));
			recipe.AddIngredient(mod.ItemType("EndlessChlorophyteQuiver"));
			recipe.AddIngredient(mod.ItemType("EndlessJesterQuiver"));
			recipe.AddIngredient(mod.ItemType("EndlessIchorQuiver"));
			recipe.AddIngredient(mod.ItemType("EndlessLuminiteQuiver"));
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void UpdateInventory(Player player)
		{
			item.shoot = GetRandomArrow();
		}
		
		private int GetRandomArrow()
		{
			int arrow = 1;
			switch(Main.rand.Next(5))
			{
				case 0:
					arrow = 639;
					break;
				case 1:
					arrow = 225;
					break;
				case 2:
					arrow = 5;
					break;
				case 3:
					arrow = 278;
					break;
				case 4:
					arrow = 91;
					break;
			}
			return arrow;
		}
	}
}