using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class StellarNinjaLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Ninja Leggings");
			Tooltip.SetDefault("20% increased throwing critical strike chance\n" +
				"You are now light as a ninja.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = -11;
			item.defense = 16;
		}

		public override void UpdateEquip(Player player)
		{
			player.accRunSpeed = 10f;
			player.moveSpeed += 1.5f;
			player.rocketBoots += 1;
			player.pickSpeed *= 0.33f;
			player.thrownCrit += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(null, "StellarFragment", 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}