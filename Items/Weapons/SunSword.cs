using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SunSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sun Sword");
			Tooltip.SetDefault("'Even more hot.'");
		}

		public override void SetDefaults()
		{
			item.damage = 83;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.scale = 1.2f;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Sun");
			item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 12);
			recipe.AddIngredient(mod.ItemType("FireEssence"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}