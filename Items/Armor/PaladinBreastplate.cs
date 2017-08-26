using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PaladinBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Breastplate");
			Tooltip.SetDefault("15% increased throwing damage");
		}

		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = 9;
			item.defense = 21;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}