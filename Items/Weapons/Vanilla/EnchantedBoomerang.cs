using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons.Vanilla
{
	public class EnchantedBoomerang : ModItem
	{
		int originalType = ItemID.EnchantedBoomerang;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thrown Enchanted Boomerang");
			Tooltip.SetDefault("Right-click to change damage type");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(originalType);
			item.melee = false;
			item.magic = false;
			item.ranged = false;
			item.thrown = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, originalType, 1, false, 0, false, false);
			Main.item[num].Prefix((int)item.prefix);
			Main.item[num].newAndShiny = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ThrowingMastery"));
			recipe.AddIngredient(originalType);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}