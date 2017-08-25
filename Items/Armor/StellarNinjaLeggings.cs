using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class StellarNinjaLeggings : ModItem
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
			item.name = "Stellar Ninja Leggings";
			AddTooltip("20% increased throwing critical strike chance");
			AddTooltip("You are now light as a ninja.");
			item.value = 10000;
			item.rare = -11;
			item.defense = 16;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.accRunSpeed = 10f;
			player.moveSpeed += 1.5f;
			player.rocketBoots+=1;
			player.pickSpeed *= 0.33f;
			player.thrownCrit += 20;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient("Luminite Bar", 12);
			recipe.AddIngredient(null, "StellarFragment", 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}