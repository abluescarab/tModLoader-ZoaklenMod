using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class StellarNinjaBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Ninja Breastplate");
			Tooltip.SetDefault("30% increased throwing damage\n" +
				"You are now resistant as a ninja.");
		}

		public override void SetDefaults()
		{
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
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(null, "StellarFragment", 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}