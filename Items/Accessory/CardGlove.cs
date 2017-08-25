using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class CardGlove : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetDefaults()
		{
			item.name = "Card Glove";
			item.width = 24;
			item.height = 24;
			AddTooltip("10% increased cards damage");
			AddTooltip("33% chance to not consume thrown cards");
			item.value = 1000;
			item.rare = 4;
			item.accessory = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 3);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}