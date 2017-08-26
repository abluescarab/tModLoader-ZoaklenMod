using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class CelestialClock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Clock");
			Tooltip.SetDefault("Indefinitely switch between day and night");
		}

		public override void SetDefaults()
		{
			item.useStyle = 4;
			item.useAnimation = 45;
			item.useTime = 45;
			item.rare = 8;
			item.width = 32;
			item.height = 32;
			item.value = 5000000;
		}

		public override bool UseItem(Player player)
		{
			if(player.itemTime == 0 && player.itemAnimation > 0)
			{
				player.itemTime = item.useTime;
				if(Main.dayTime)
				{
					Main.dayTime = false;
				}
				else
				{
					Main.dayTime = true;
				}
				Main.time = 0.0;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sundial);
			recipe.AddIngredient(ItemID.SolarTablet, 5);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}