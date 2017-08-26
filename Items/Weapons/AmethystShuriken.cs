using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class AmethystShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Shuriken");
			Tooltip.SetDefault("'We'll ever save the day'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.damage = 13;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("AmethystShuriken");
			item.crit = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Amethyst);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}