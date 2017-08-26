using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class TechSmite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tech Smite");
			Tooltip.SetDefault("'* Do you think even the worst person can change...?'");
		}

		public override void SetDefaults()
		{
			item.rare = 10;
			item.mana = 50;
			item.channel = true;
			item.damage = 500;
			item.useStyle = 1;
			item.width = 26;
			item.height = 24;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 61;
			item.noUseGraphic = true;
			item.shoot = 1;
			item.shootSpeed = 0f;
			item.noMelee = true;
			item.useTime = 61;
			item.noMelee = true;
			item.knockBack = 6f;
			item.value = 200000;
			item.autoReuse = true;
			item.magic = true;
		}

		public override void UseStyle(Player player)
		{
			Vector2 vector15 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			if(player.direction != 1)
			{
				vector15.X = (float)player.bodyFrame.Width - vector15.X;
			}
			if(player.gravDir != 1f)
			{
				vector15.Y = (float)player.bodyFrame.Height - vector15.Y;
			}
			vector15 -= new Vector2((float)(player.bodyFrame.Width - player.width), (float)(player.bodyFrame.Height - 42)) / 2f;
			Vector2 position17 = player.RotatedRelativePoint(player.position + vector15, true) - player.velocity;
			for(int num247 = 0; num247 < 1; num247++)
			{
				Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, mod.DustType("Neon"), (float)(player.direction * 2), 0f, 100, default(Color), 0.5f)];
				dust.position = position17;
				dust.velocity *= 0f;
				dust.noGravity = true;
				dust.fadeIn = 1f;
				dust.color = new Color(0, 255, 255);
				dust.velocity += player.velocity;
				if(Main.rand.Next(2) == 0)
				{
					dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
					dust.scale += Main.rand.NextFloat();
					if(Main.rand.Next(2) == 0)
					{
						dust.customData = player;
					}
				}
			}

			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 cursor;
			cursor.X = (float)Main.mouseX + Main.screenPosition.X;
			cursor.Y = (float)Main.mouseY + Main.screenPosition.Y;
			if(player.itemAnimation == 60)
			{
				Projectile.NewProjectile(cursor.X, 30, 0, 5, mod.ProjectileType("CyberInstaF"), player.GetWeaponDamage(item), 0, 0);
			}
			else if(player.itemAnimation == 40)
			{
				Projectile.NewProjectile(cursor.X + (float)Main.rand.Next(-128, -33), 30, 0, 5, mod.ProjectileType("CyberInstaF"), player.GetWeaponDamage(item), 0, 0);
			}
			else if(player.itemAnimation == 20)
			{
				Projectile.NewProjectile(cursor.X + (float)Main.rand.Next(32, 129), 30, 0, 5, mod.ProjectileType("CyberInstaF"), player.GetWeaponDamage(item), 0, 0);
			}
		}

		public Vector2 CalculateCenter(Dust dust)
		{
			return new Vector2(dust.position.X + 2, dust.position.Y + 2);
		}

		public override void HoldStyle(Player player)
		{
			Vector2 vector15 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			if(player.direction != 1)
			{
				vector15.X = (float)player.bodyFrame.Width - vector15.X;
			}
			if(player.gravDir != 1f)
			{
				vector15.Y = (float)player.bodyFrame.Height - vector15.Y;
			}
			vector15 -= new Vector2((float)(player.bodyFrame.Width - player.width), (float)(player.bodyFrame.Height - 42)) / 2f;
			Vector2 position17 = player.RotatedRelativePoint(player.position + vector15, true) - player.velocity;
			for(int num247 = 0; num247 < 1; num247++)
			{
				Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, mod.DustType("Neon"), (float)(player.direction * 2), 0f, 100, default(Color), 0.5f)];
				dust.position = position17;
				dust.velocity *= 0f;
				dust.noGravity = true;
				dust.fadeIn = 1f;
				dust.color = new Color(0, 255, 255);
				dust.velocity += player.velocity;
				if(Main.rand.Next(2) == 0)
				{
					dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
					dust.scale += Main.rand.NextFloat();
					if(Main.rand.Next(2) == 0)
					{
						dust.customData = player;
					}
				}
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			/*Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 cursor;
			cursor.X = (float)Main.mouseX + Main.screenPosition.X;
			cursor.Y = (float)Main.mouseY + Main.screenPosition.Y;
			if(player.itemAnimation % 10 == 0)
			{
				Projectile.NewProjectile(cursor.X, 30, 0, 5, mod.ProjectileType("CyberInstaF"), damage, 0, 0);
			}*/
			return false;
		}
	}
}