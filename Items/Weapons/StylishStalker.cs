using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class StylishStalker : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stylish Stalker";
			item.width = 60;
			item.height = 22;
			item.shoot = 162;
			item.useTime = 60;
			item.useAnimation = 60;
			item.autoReuse = true;
			item.useAmmo = 162;
			item.useSound = 11;
			item.useStyle = 5;
			item.damage = 300;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.value = 200000;
			item.knockBack = 10f;
			item.rare = 9;
			item.ranged = true;
			AddTooltip("'Boom, deadshot.'");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarCannon);
			recipe.AddIngredient(ItemID.Cannon);
			recipe.AddIngredient(ItemID.IllegalGunParts, 5);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}