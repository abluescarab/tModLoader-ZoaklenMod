using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NinjaSkills : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Ninja Soul");
			Tooltip.SetDefault("15% increased throwing damage, velocity and critical strike chance\n" +
				"Increases armor penetration by 5\n" +
				"Allows player ability to dash\n" +
				"Double tap into a direction\n" +
				"May confuse nearby enemies after being struck\n" +
				"Increases length of invincibility after taking damage");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 19));
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
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
	}
}