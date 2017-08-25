using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class ShadowQuiver : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Shadow Quiver";
			item.width = 24;
			item.height = 28;
			AddTooltip("Increases movement speed after being struck");
			AddTooltip("Allows the ability to climb and dash");
			AddTooltip("Gives a chance to dodge attacks");
			AddTooltip("Increases arrow damage by 10% and greatly increases arrow speed");
			AddTooltip("20% chance to not consume arrows");
			item.value = 100000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicQuiver = true;
			player.arrowDamage += 0.1f;
			player.blackBelt = true;
			player.dash = 1;
			player.spikedBoots = 2;
			player.panic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.PanicNecklace);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}