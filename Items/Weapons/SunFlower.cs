using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SunFlower : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Sun Flower";
			item.damage = 71;
			item.magic = true;
			item.scale = 1.1f;
			item.mana = 12;
			item.width = 36;
			item.height = 38;
			item.toolTip = "'This is like extremely hot'";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 8;
			item.useSound = 20;
			item.autoReuse = true;
		}

		public override bool UseItem(Player player)
		{
			int damage = player.GetWeaponDamage(player.inventory[player.selectedItem]);
			float knockBack = player.GetWeaponKnockback(player.inventory[player.selectedItem], player.inventory[player.selectedItem].knockBack);
			if(player.altFunctionUse != 2)
			{
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				float num200 = num78;
				float num201 = num79;
				num200 += (float)Main.rand.Next(-40, 41) * 0.05f;
				num201 += (float)Main.rand.Next(-32, 33) * 0.05f;
				Vector2 vector12 = vector2 + Vector2.Normalize(new Vector2(num200, num201).RotatedBy((double)(-1.57079637f * (float)player.direction), default(Vector2))) * 6f;
				int proj = Projectile.NewProjectile(vector12.X, vector12.Y, num200, num201, mod.ProjectileType("Sun"), damage, knockBack, player.whoAmI);
				Main.projectile[proj].penetrate = 1;
				if(num78 < 0)
				{
					player.direction = -1;
				}
				else
				{
					player.direction = 1;
				}
			}
			else
			{
				Vector2 value7 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				int num71 = Player.tileTargetX;
				int num72 = Player.tileTargetY + 1;
				float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				float num115 = value7.Y;
				if(num115 > player.Center.Y - 200f)
				{
					num115 = player.Center.Y - 200f;
				}
				for(int num116 = 0; num116 < 3; num116++)
				{
					vector2 = player.Center + new Vector2((float)(-(float)Main.rand.Next(0, 401) * player.direction), -600f);
					vector2.Y -= (float)(100 * num116);
					Vector2 value8 = value7 - vector2;
					if(value8.Y < 0f)
					{
						value8.Y *= -1f;
					}
					if(value8.Y < 20f)
					{
						value8.Y = 20f;
					}
					value8.Normalize();
					value8 *= num72;
					num78 = value8.X;
					num79 = value8.Y;
					float speedX5 = num78;
					float speedY6 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
					Projectile.NewProjectile(vector2.X, vector2.Y, speedX5, speedY6, mod.ProjectileType("Sun"), (int)(damage * 0.4f), knockBack, player.whoAmI);
				}
				if(num78 < 0)
				{
					player.direction = -1;
				}
				else
				{
					player.direction = 1;
				}
			}
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 8);
			recipe.AddIngredient(mod.ItemType("FireEssence"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}