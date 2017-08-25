using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NightQuiver : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Night Quiver";
			item.width = 24;
			item.height = 28;
			AddTooltip("Increases movement speed after being struck");
			AddTooltip("Allows the ability to climb and dash");
			AddTooltip("Gives a chance to dodge attacks");
			AddTooltip("Increases arrow damage by 20% and greatly increases arrow speed");
			AddTooltip("10% increased ranged critical strike chance");
			AddTooltip("20% chance to not consume arrows");
			AddTooltip("Permanent arrow buffs");
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