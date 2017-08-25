using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NinjaSkills : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stellar Ninja Soul";
			item.width = 24;
			item.height = 28;
			AddTooltip("15% increased throwing damage, velocity and critical strike chance");
			AddTooltip("Increases armor penetration by 5");
			AddTooltip("Allows player ability to dash");
			AddTooltip("Double tap into a direction");
			AddTooltip("May confuse nearby enemies after being struck");
			AddTooltip("Increases length of invincibility after taking damage");
			item.value = 10000;
			item.rare = 10;
			item.defense = 8;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
			player.thrownDamage += 0.15f;
			player.thrownVelocity += 0.15f;
			player.armorPenetration += 5;
			player.dash = 1;
			player.blackBelt = true;
			player.spikedBoots = 2;
			player.longInvince = true;
			player.brainOfConfusion = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NinjaKnuckles"));
			recipe.AddIngredient(mod.ItemType("NinjaAmulet"));
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(5, 19);
		}
	}
}