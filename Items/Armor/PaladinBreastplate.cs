using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class PaladinBreastplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Paladin Breastplate";
			AddTooltip("15% increased throwing damage");
			item.value = 10000;
			item.rare = 9;
			item.defense = 21;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.15f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}