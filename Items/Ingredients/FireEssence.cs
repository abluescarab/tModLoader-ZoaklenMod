using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class FireEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Core");
			Tooltip.SetDefault("'A red smoke comes out of this stone'");
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
			recipe.AddIngredient(ItemID.HelFire);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cascade);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunfury);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellwingBow);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Flamethrower);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EldMelter);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Flamelash);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlowerofFire);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ImpStaff);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}