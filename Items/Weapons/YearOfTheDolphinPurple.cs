using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class YearOfTheDolphinPurple : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SDMG);
			item.name = "Year Of The Dolphin (Purple)";
			item.rare = 10;
			item.shootSpeed *= 1.1f;
			item.damage = 80;
			item.shoot = 14;
			item.autoReuse = true;
			item.useAmmo = 14;
			item.channel = true;
			item.toolTip = "'Let's grove tonight'";
			item.toolTip2 = "66% chance to not consume ammo";
			item.value = Item.sellPrice(0, 50, 0, 0);
		}

		public override bool ConsumeAmmo(Player player)
		{
			if(Main.rand.Next(3) != 0)
			{
				return false;
			}
			return true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("YearOfTheDolphinYellow"), 1, false, 0, false, false);
			Main.item[num].Prefix((int)item.prefix);
			Main.item[num].newAndShiny = false;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num78 = (float)Main.mouseX + Main.screenPosition.X - position.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
			int num73 = player.GetWeaponDamage(player.inventory[player.selectedItem]);
			float num74 = player.inventory[player.selectedItem].knockBack;
			float num117 = 0.314159274f;
			int num118 = 1;
			Vector2 vector7 = new Vector2(num78, num79);
			vector7.Normalize();
			vector7 *= 40f;
			bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector7, 0, 0);
			int num71 = item.shoot;
			if(type == 14)
			{
				type = 284;
				num71 = 284;
			}
			for(int num119 = 0; num119 < num118; num119++)
			{
				float num120 = (float)num119 - ((float)num118 - 1f) / 2f;
				Vector2 value9 = vector7.RotatedBy((double)(num117 * num120), default(Vector2));
				if(!flag11)
				{
					value9 -= vector7;
				}
				int num121 = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, num78, num79, num71, num73, num74, player.whoAmI, 0f, 0f);
				Main.projectile[num121].noDropItem = true;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SDMG);
			recipe.AddIngredient(ItemID.FireworksLauncher);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}