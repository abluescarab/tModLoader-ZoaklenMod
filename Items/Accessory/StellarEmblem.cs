using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class StellarEmblem : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Emblem");
			Tooltip.SetDefault("25% increased throwing damage");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NinjaEmblem"));
			recipe.AddIngredient(mod.ItemType("StellarFragment"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}