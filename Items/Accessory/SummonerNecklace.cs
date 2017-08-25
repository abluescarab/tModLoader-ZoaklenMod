using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class SummonerNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Invoker Emblem";
			item.width = 24;
			item.height = 24;
			AddTooltip("Increases your max number of minions by 3");
			AddTooltip("30% increased minion damage");
			AddTooltip("Permanent summoning buffs");
			AddTooltip("'If the pygmies know what you did'");
			item.value = 100000;
			item.rare = 6;
			item.accessory = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 3;
			player.minionDamage += 0.3f;
			player.AddBuff(BuffID.Summoning, 2, true);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PygmyNecklace);
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.PapyrusScarab);
			recipe.AddIngredient(ItemID.SummoningPotion, 30);
			recipe.AddTile(TileID.BewitchingTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}