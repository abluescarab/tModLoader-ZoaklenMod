using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class StellarShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Shuriken");
			Tooltip.SetDefault("Soul-imbued weapon");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.width = 36;
			item.height = 36;
			item.rare = 10;
			item.noMelee = true;
			item.useStyle = 1;
			item.useAnimation = 10;
			item.knockBack = 0.0F;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("StellarShuriken");
			item.shootSpeed *= 2.0f;
			item.damage = 80;
			item.useTime = 10;
			item.autoReuse = true;
			item.crit = 25;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StellarFragment");
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 111);
			recipe.AddRecipe();
		}
	}
}