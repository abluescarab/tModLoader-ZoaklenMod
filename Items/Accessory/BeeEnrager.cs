using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class BeeEnrager : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Rotten Beehive";
			item.width = 26;
			item.height = 26;
			AddTooltip("Enrages your bees");
			item.value = 100000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.strongBees = true;
		}

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(30, 4);
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