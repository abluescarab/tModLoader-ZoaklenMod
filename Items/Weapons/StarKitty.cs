using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class StarKitty : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Star Kitty";
			item.damage = 160;
			item.melee = true;
			item.width = 52;
			item.height = 60;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.rare = 10;
			item.useSound = 1;
			item.autoReuse = true;
			item.toolTip = "'Cat lovers only'";
			item.shoot = mod.ProjectileType("StarKitty");
			item.shootSpeed = 15;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			int randomX = Main.rand.Next(-300, 300);
			int randomY = Main.rand.Next(-300, 300);
			if(Main.rand.Next(2) == 0)
			{
				randomX -= Main.maxScreenW / 2 + randomX;
			}
			else
			{
				randomX += Main.maxScreenW / 2 - randomX;
			}
			if(Main.rand.Next(2) == 0)
			{
				randomY -= Main.maxScreenH / 2 + randomY;
			}
			else
			{
				randomY += Main.maxScreenH / 2 - randomY;
			}
			randomX += (int)player.position.X;
			randomY += (int)player.position.Y;
			float velocityX = target.position.X - randomX;
			float velocityY = target.position.Y - randomY;
			int meow = Projectile.NewProjectile(randomX, randomY, velocityX/48, velocityY/48, ProjectileID.Meowmere, damage, knockBack, player.whoAmI, 0f, 0f);
			Main.projectile[meow].aiStyle = 1;
			Main.projectile[meow].tileCollide = false;
			Main.projectile[meow].penetrate = 1;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}