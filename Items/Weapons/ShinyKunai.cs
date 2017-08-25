using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class ShinyKunai : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shiny Kunai";
			item.useStyle = 1;
			item.width = 26;
			item.height = 26;
			item.rare = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.shootSpeed = 15.0f;
			item.useSound = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 1000;
			item.damage = 75;
			item.thrown = true;
			item.autoReuse = true;
			item.toolTip = "'Midas is envying you right now'";
			item.shoot = mod.ProjectileType("ShinyKunai");
			item.crit = 10;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"));
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 99);
			recipe.AddRecipe();
		}
	}
}