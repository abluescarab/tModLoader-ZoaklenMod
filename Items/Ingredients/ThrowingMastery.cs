using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class ThrowingMastery : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Throwing Mastery";
			item.width = 16;
			item.height = 14;
			item.maxStack = 99;
			AddTooltip("Right-click the mentioned item to convert its damage to throwing");
			AddTooltip2("* This is not a material");
			item.value = 10000;
			item.rare = 5;
		}

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(30, 2);
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