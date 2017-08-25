using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class EmeraldShuriken : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.name = "Emerald Shuriken";
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.15f;
			item.damage = 19;
			item.autoReuse = false;
			item.toolTip = "'Better than only money'";
			item.shoot = mod.ProjectileType("EmeraldShuriken");
			item.crit = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}