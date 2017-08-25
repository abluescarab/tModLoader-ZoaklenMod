using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class HallowedArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Hallowed Arrow";
			item.shootSpeed = 0.5f;
			item.shoot = mod.ProjectileType("HallowedArrow");
			item.damage = 12;
			item.width = 14;
			item.height = 32;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 3f;
			item.rare = 7;
			item.value = 1000;
			item.ranged = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 111);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.CrystalShard, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}