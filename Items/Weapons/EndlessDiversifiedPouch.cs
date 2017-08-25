using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class EndlessDiversifiedPouch : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ChlorophyteBullet);
			item.name = "Endless Diversified Pouch";
			item.toolTip = "Shoots random types of bullets";
			item.damage = 20;
			item.maxStack = 1;
			item.consumable = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EndlessCrystalPouch"));
			recipe.AddIngredient(mod.ItemType("EndlessChlorophytePouch"));
			recipe.AddIngredient(mod.ItemType("EndlessLuminitePouch"));
			recipe.AddIngredient(mod.ItemType("EndlessIchorPouch"));
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateInventory(Player player)
		{
			item.shoot = GetRandomBullet();
		}

		private int GetRandomBullet()
		{
			int arrow = 1;
			switch(Main.rand.Next(4))
			{
				case 0:
					arrow = 89;
					break;
				case 1:
					arrow = 207;
					break;
				case 2:
					arrow = 638;
					break;
				case 3:
					arrow = 279;
					break;
			}
			return arrow;
		}
	}
}