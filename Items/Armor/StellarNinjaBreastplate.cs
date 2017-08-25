using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class StellarNinjaBreastplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Stellar Ninja Breastplate";
			AddTooltip("30% increased throwing damage");
			AddTooltip("You are now resistant as a ninja.");
			item.value = 10000;
			item.rare = -11;
			item.defense = 22;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.3f;
			player.noKnockback = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient("Luminite Bar", 16);
			recipe.AddIngredient(null, "StellarFragment", 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}