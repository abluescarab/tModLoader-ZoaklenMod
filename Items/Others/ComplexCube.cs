using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class ComplexCube : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Complex Cube";
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.toolTip = "Summons the techno doom";
			item.value = 100;
			item.rare = 11;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("MagicalCube"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MagicalCube"));
			Main.NewText("The cube gets bigger, and it's not happy.", 32, 255, 32);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 10);
			recipe.AddIngredient(mod.ItemType("StellarFragment"), 3);
			recipe.AddIngredient(ItemID.FragmentSolar, 3);
			recipe.AddIngredient(ItemID.FragmentStardust, 3);
			recipe.AddIngredient(ItemID.FragmentNebula, 3);
			recipe.AddIngredient(ItemID.FragmentVortex, 3);
		}
	}
}