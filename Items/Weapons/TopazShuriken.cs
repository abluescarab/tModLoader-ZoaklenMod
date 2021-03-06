using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class TopazShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Topaz Shuriken");
			Tooltip.SetDefault("'You told me it was diamonds'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.05f;
			item.damage = 15;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("TopazShuriken");
			item.crit = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Topaz);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}