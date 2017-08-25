using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SkyBreaker : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.DayBreak);
			item.name = "Sky Breaker";
			item.rare = 10;
			item.width = 30;
			item.height = 30;
			item.shootSpeed *= 1.1f;
			item.damage = 100;
			item.autoReuse = true;
			item.useTime = 20;
			item.toolTip = "'Drop it like a bass'";
			item.shoot = mod.ProjectileType("SkyBreakerSpear");
			item.crit = 10;
			item.value = Item.sellPrice(0, 50, 0, 0);
		}
		
		public override bool CanRightClick()
		{
			return true;
		}
		
		public override void RightClick(Player player)
		{
			int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("SkyBreakerT"), 1, false, 0, false, false);
			Main.item[num].Prefix((int)item.prefix);
			Main.item[num].newAndShiny = false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarEruption);
			recipe.AddIngredient(ItemID.DayBreak);
			recipe.AddIngredient(ItemID.NorthPole);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}