using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NeoGlasses : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Chosen Glasses");
			Tooltip.SetDefault("'Enter the matrix'");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = 6;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.accOreFinder = true;
			player.detectCreature = true;
			Lighting.AddLight(player.position, Microsoft.Xna.Framework.Color.Green.ToVector3());
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunglasses);
			recipe.AddIngredient(ItemID.MiningHelmet);
			recipe.AddIngredient(ItemID.SpelunkerPotion, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}