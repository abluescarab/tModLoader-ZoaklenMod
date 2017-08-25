using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class ShadowNinjaLeggings : ModItem
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
			item.name = "Shadow Ninja Leggings";
			AddTooltip("20% increased throwing critical strike chance");
			item.value = 10000;
			item.rare = 5;
			item.defense = 13;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 20;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NinjaPants);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(mod.ItemType("ShadowEssence"), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}