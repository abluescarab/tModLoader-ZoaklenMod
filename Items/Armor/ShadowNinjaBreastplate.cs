using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShadowNinjaBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Ninja Breastplate");
			Tooltip.SetDefault("20% increased throwing damage");
		}

		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = 5;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NinjaShirt);
			recipe.AddIngredient(ItemID.SoulofNight, 9);
			recipe.AddIngredient(mod.ItemType("ShadowEssence"), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}