using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class ShadowEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Core");
			Tooltip.SetDefault("'A purple smoke comes out of this stone'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 11));
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 27;
			item.maxStack = 99;
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
	}
}