using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class RubyShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Shuriken");
			Tooltip.SetDefault("'The blood never soil it'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.15f;
			item.damage = 23;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("RubyShuriken");
			item.crit = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}