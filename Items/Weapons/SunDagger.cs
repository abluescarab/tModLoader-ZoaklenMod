using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SunDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.name = "Sun Dagger";
			item.width = 30;
			item.height = 30;
			item.rare = 8;
			item.shootSpeed *= 1.2f;
			item.damage = 70;
			item.autoReuse = true;
			item.useTime = 9;
			item.useAnimation = 9;
			item.toolTip = "'Super hot, super hot'";
			item.shoot = mod.ProjectileType("SunDagger");
			item.crit = 10;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 4);
			recipe.AddIngredient(mod.ItemType("FireEssence"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 111);
			recipe.AddRecipe();
		}
	}
}