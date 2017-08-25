using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class AmberShuriken : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.name = "Amber Shuriken";
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.1f;
			item.damage = 21;
			item.autoReuse = false;
			item.toolTip = "'Dinossaur-made shurikens'";
			item.shoot = mod.ProjectileType("AmberShuriken");
			item.crit = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Amber);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}