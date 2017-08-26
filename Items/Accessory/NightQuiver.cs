using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	[AutoloadEquip(EquipType.Back)]
	public class NightQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Quiver");
			Tooltip.SetDefault("Increases movement speed after being struck\n" +
				"Allows the ability to climb and dash\n" +
				"Gives a chance to dodge attacks\n" +
				"Increases arrow damage by 20% and greatly increases arrow speed\n" +
				"10% increased ranged critical strike chance\n" +
				"20% chance to not consume arrows\n" +
				"Permanent arrow buffs");
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
			player.arrowDamage += 0.2f;
			player.rangedCrit += 10;
			player.blackBelt = true;
			player.dash = 1;
			player.spikedBoots = 2;
			player.panic = true;
			player.AddBuff(BuffID.Archery, 2, true);
			player.AddBuff(BuffID.AmmoReservation, 2, true);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowQuiver"));
			recipe.AddIngredient(ItemID.ArcheryPotion, 30);
			recipe.AddIngredient(ItemID.AmmoReservationPotion, 30);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}