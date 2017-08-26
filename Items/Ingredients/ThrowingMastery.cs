using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class ThrowingMastery : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Mastery");
			Tooltip.SetDefault("Right-click the mentioned item to convert its damage to throwing\n" +
				"* This is not a material");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 14;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 5;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 100);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}