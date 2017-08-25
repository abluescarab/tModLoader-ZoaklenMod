using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class HiddenShooterHood : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Hidden Shooter Hood";
			AddTooltip("15% increased throwing and ranged critical strike chance");
			AddTooltip("Enables zoom out (right click) with throwing and ranged weapons");
			item.value = 10000;
			item.rare = 6;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
			player.rangedCrit += 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("HiddenShooterCoat") && legs.type == mod.ItemType("HiddenShooterPants");
		}

		public override void UpdateArmorSet(Player player)
		{
			string bonus = "Permanent Warmth buff, immunity to Chilled and Frozen debuffs and increases critical strike damage by 50%";
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.AddBuff(BuffID.Warmth, 2, true);
			player.setBonus = bonus;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}