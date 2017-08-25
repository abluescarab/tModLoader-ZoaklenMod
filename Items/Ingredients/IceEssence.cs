using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class IceEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ice Core";
			item.width = 23;
			item.height = 25;
			item.maxStack = 99;
			AddTooltip("'A blue smoke comes out of this stone'");
			item.value = 100000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amarok);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Frostbrand);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceSickle);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NorthPole);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBoomerang);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBow);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BlizzardStaff);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlowerofFrost);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(3, 11);
		}
	}
}