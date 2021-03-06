using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HiddenShooterCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hidden Shooter Coat");
			Tooltip.SetDefault("15% increased throwing and ranged damage\n" +
				"Enemies will focus other person if possible");
		}

		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = 6;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.15f;
			player.rangedDamage += 0.15f;
			player.aggro -= 99999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 26);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 26);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}