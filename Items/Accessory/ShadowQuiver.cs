using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	[AutoloadEquip(EquipType.Back)]
	public class ShadowQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Quiver");
			Tooltip.SetDefault("Increases movement speed after being struck\n" +
				"Allows the ability to climb and dash\n" +
				"Gives a chance to dodge attacks\n" +
				"Increases arrow damage by 10% and greatly increases arrow speed\n" +
				"20% chance to not consume arrows");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 100000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicQuiver = true;
			player.arrowDamage += 0.1f;
			player.blackBelt = true;
			player.dash = 1;
			player.spikedBoots = 2;
			player.panic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.PanicNecklace);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}