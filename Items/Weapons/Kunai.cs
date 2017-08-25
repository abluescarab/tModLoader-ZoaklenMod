using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class Kunai : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Kunai";
			item.useStyle = 1;
			item.width = 26;
			item.height = 26;
			item.rare = 6;
			item.maxStack = 999;
			item.consumable = true;
			item.shootSpeed = 15.0f;
			item.useSound = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 1000;
			item.damage = 27;
			item.thrown = true;
			item.autoReuse = true;
			item.toolTip = "'Death from above'";
			item.shoot = mod.ProjectileType("Kunai");
			item.crit = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar);
			recipe.AddIngredient(ItemID.Cobweb, 2);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar);
			recipe.AddIngredient(ItemID.Cobweb, 2);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}