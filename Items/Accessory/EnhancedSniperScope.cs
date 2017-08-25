using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class EnhancedSniperScope : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enhanced Sniper Scope";
			item.width = 24;
			item.height = 28;
			AddTooltip("Increases view range for guns (right click to zoom out)");
			AddTooltip("10% increased ranged damage and critical strike chance");
			AddTooltip("Permanent arrow buffs");
			item.value = 100000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 10;
			player.rangedDamage += 0.1f;
			player.AddBuff(BuffID.Archery, 2, true);
			player.AddBuff(BuffID.AmmoReservation, 2, true);
			Item sl = player.inventory[player.selectedItem];
			if(sl.useAmmo == 14 || sl.useAmmo == 311 || sl.useAmmo == 323 || sl.useAmmo == 23 || sl.useAmmo == 771)
			{
				player.scope = true;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.ArcheryPotion, 30);
			recipe.AddIngredient(ItemID.AmmoReservationPotion, 30);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}