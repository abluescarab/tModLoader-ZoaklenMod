using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class StardustEmblem : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetDefaults()
		{
			item.name = "Stardust Emblem";
			item.width = 24;
			item.height = 24;
			AddTooltip("25% increased summon damage");
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.25f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}