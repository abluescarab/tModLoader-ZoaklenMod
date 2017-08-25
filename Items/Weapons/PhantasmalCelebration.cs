using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class PhantasmalCelebration : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Phantasm);
			item.name = "Phantasm Buster";
			item.damage = 30;
			item.rare = 10;
			item.noUseGraphic = false;
			item.toolTip = "'There is a secret cannon on it'";
			item.shoot = mod.ProjectileType("PhantasmalCelebration");
			item.value = Item.sellPrice(0, 50, 0, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num78 = (float)Main.mouseX + Main.screenPosition.X - position.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
			int num73 = player.GetWeaponDamage(player.inventory[player.selectedItem]);
			float num74 = player.inventory[player.selectedItem].knockBack;
			int bow = Projectile.NewProjectile(position.X, position.Y, num78, num79, mod.ProjectileType("PhantasmalCelebration"), num73, num74, player.whoAmI, 0f, 0f);
			int gun = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, mod.ProjectileType("PhantasmalGun"), num73, num74, player.whoAmI, (float)(5 * Main.rand.Next(0, 20)), 0f);
			Main.projectile[gun].alpha = 0;
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(12, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Phantasm);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}