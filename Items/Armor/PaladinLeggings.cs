using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class PaladinLeggings : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.name = "Paladin Leggings";
			AddTooltip("15% increased throwing critical strike chance");
			item.value = 10000;
			item.rare = 9;
			item.defense = 13;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}