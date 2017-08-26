using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HiddenShooterPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hidden Shooter Pants");
			Tooltip.SetDefault("50% chance to not consume thrown or ranged ammo");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 6;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCost50 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}