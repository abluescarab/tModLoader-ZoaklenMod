using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class PaladinHelmet : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Paladin Helmet";
			AddTooltip("15% increased throwing velocity");
			item.value = 10000;
			item.rare = 9;
			item.defense = 17;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownVelocity += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PaladinBreastplate") && legs.type == mod.ItemType("PaladinLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string bonus = "Attackers also take full damage, increases maximum health by 40 and grants extra damage to boomerangs";
			player.thorns = 1.0f;
			player.turtleThorns = true;
			player.statLifeMax2 += 40;
			player.setBonus = bonus;
			player.AddBuff(BuffID.Shine, 2, false);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}