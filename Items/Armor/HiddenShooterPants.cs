using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class HiddenShooterPants : ModItem
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
			item.name = "Hidden Shooter Pants";
			AddTooltip("50% chance to not consume thrown or ranged ammo");
			item.value = 10000;
			item.rare = 6;
			item.defense = 9;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCost50 = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}