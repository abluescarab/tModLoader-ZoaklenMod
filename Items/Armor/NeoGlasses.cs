using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class NeoGlasses : ModItem
	{
		int frameCounter = 0;
	
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "The Chosen Glasses";
			item.width = 20;
			item.height = 20;
			item.rare = 6;
			AddTooltip("'Enter the matrix'");
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.accOreFinder = true;
			player.detectCreature = true;
			Lighting.AddLight(player.position, Microsoft.Xna.Framework.Color.Green.ToVector3());
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunglasses);
			recipe.AddIngredient(ItemID.MiningHelmet);
			recipe.AddIngredient(ItemID.SpelunkerPotion, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}