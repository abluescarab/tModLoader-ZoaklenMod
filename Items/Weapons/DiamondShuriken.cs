using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class DiamondShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Shuriken");
			Tooltip.SetDefault("'Shine bright like a diamond'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.2f;
			item.damage = 25;
			item.useTime -= 1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("DiamondShuriken");
			item.crit = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}