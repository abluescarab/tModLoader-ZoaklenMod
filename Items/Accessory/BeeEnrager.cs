using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class BeeEnrager : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Beehive");
			Tooltip.SetDefault("Enrages your bees");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 4));
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 100000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.strongBees = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeWax, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.BottledHoney, 10);
			recipe.AddIngredient(ItemID.Hive, 10);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}