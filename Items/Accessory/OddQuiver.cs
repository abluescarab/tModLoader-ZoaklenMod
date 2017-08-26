using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class OddQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odd Quiver");
			Tooltip.SetDefault("Increases arrow damage by 5%\n" +
				"10% chance to not consume arrow");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 10000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.arrowDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 500);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 500);
			recipe.AddIngredient(ItemID.LeadBar, 5);
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}