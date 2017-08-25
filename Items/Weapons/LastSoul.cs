using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class LastSoul : ModItem
	{
		public override void SetDefaults()
		{
			item.rare = 10;
			item.mana = 100;
			item.channel = true;
			item.damage = 300;
			item.useStyle = 5;
			item.name = "Last Soul";
			item.shootSpeed = 20f;
			item.shoot = mod.ProjectileType("LastSoul");
			item.width = 26;
			item.height = 28;
			item.useSound = 28;
			item.useAnimation = 18;
			item.useTime = 40;
			item.noMelee = true;
			item.knockBack = 6f;
			item.toolTip = "'Casts a controllable soul'";
			item.value = 200000;
			item.magic = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LastPrism);
			recipe.AddIngredient(ItemID.RainbowRod);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}