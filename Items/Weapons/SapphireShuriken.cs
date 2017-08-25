using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SapphireShuriken : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.name = "Sapphire Shuriken";
			item.width = 22;
			item.height = 22;
			item.rare = 2;
			item.shootSpeed *= 1.1f;
			item.damage = 17;
			item.autoReuse = false;
			item.toolTip = "'The sky is blue, sapphires are too'";
			item.shoot = mod.ProjectileType("SapphireShuriken");
			item.crit = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shuriken, 50);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}