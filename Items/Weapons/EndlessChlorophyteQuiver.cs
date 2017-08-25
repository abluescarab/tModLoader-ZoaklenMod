using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class EndlessChlorophyteQuiver : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ChlorophyteArrow);
			item.name = "Endless Chlorophyte Quiver";
			item.maxStack = 1;
			item.consumable = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteArrow, 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}