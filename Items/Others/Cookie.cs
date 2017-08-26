using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class Cookie : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cookie");
			Tooltip.SetDefault("'Clap along if you feel...'");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item2;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.buffType = 26;
			item.buffTime = 14400;
			item.value = 1000;
			item.rare = 3;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.Sunflower, 14400, true);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 3);
			recipe.AddIngredient(ItemID.Seed, 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}