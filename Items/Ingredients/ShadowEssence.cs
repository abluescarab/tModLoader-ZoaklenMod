using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Ingredients
{
	public class ShadowEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shadow Core";
			item.width = 20;
			item.height = 27;
			item.maxStack = 99;
			AddTooltip("'A purple smoke comes out of this stone'");
			item.value = 100000;
			item.rare = 5;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowFlameKnife);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowFlameBow);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowbeamStaff);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowFlameHexDoll);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowflameStaff"));
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
		
		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(3, 11);
		}
	}
}