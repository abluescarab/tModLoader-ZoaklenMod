using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class TeraCardGlove : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tera Card Glove");
			Tooltip.SetDefault("20% increased cards damage\n" +
				"50% chance to not consume thrown cards\n" +
				"Hidden critical strike chance with cards");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 1000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CardGlove"));
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.LifeFruit);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}