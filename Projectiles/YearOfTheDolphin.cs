using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class YearOfTheDolphin : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Year Of The Dolphin");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Phantasm);
			Main.projFrames[projectile.type] = 6;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Phantasm;
			return true;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if(projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 6;
			}
			Player player = Main.player[projectile.owner];
			float num;
			num = 0f;
			if(projectile.spriteDirection == -1)
			{
				num = 3.14159274f;
			}

			int num39 = 0;
			if(projectile.ai[0] >= 40f)
			{
				num39++;
			}
			if(projectile.ai[0] >= 80f)
			{
				num39++;
			}
			if(projectile.ai[0] >= 120f)
			{
				num39++;
			}
			int num40 = 24;
			int num41 = 2;

			projectile.ai[1] -= 1f;

			bool flag15 = false;
			if(projectile.ai[1] <= 0f)
			{
				projectile.ai[1] = (float)(num40 - num41 * num39);
				flag15 = true;
				int arg_1F5C_0 = (int)projectile.ai[0] / (num40 - num41 * num39);
			}

			bool flag16 = player.channel && player.HasAmmo(player.inventory[player.selectedItem], true) && !player.noItems && !player.CCed;

			if(flag15 && Main.myPlayer == projectile.owner)
			{
				int num42 = 14;
				float scaleFactor11 = 14f;
				Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
				int weaponDamage2 = player.GetWeaponDamage(player.inventory[player.selectedItem]);
				float weaponKnockback2 = player.inventory[player.selectedItem].knockBack;
				if(flag16)
				{
					player.PickAmmo(player.inventory[player.selectedItem], ref num42, ref scaleFactor11, ref flag16, ref weaponDamage2, ref weaponKnockback2, false);
					weaponKnockback2 = player.GetWeaponKnockback(player.inventory[player.selectedItem], weaponKnockback2);
					float scaleFactor12 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					Vector2 vector19 = vector;
					Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector19;
					if(player.gravDir == -1f)
					{
						value18.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector19.Y;
					}
					Vector2 value19 = Vector2.Normalize(value18);
					if(float.IsNaN(value19.X) || float.IsNaN(value19.Y))
					{
						value19 = -Vector2.UnitY;
					}
					value19 *= scaleFactor12;
					if(value19.X != projectile.velocity.X || value19.Y != projectile.velocity.Y)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity = value19 * 0.55f;
					for(int num43 = 0; num43 < 4; num43++)
					{
						Vector2 vector20 = Vector2.Normalize(projectile.velocity) * scaleFactor11 * (0.6f + Main.rand.NextFloat() * 0.8f);
						if(float.IsNaN(vector20.X) || float.IsNaN(vector20.Y))
						{
							vector20 = -Vector2.UnitY;
						}
						Vector2 vector21 = vector19 + Utils.RandomVector2(Main.rand, -15f, 15f);
						int num44 = Projectile.NewProjectile(vector21.X, vector21.Y, vector20.X, vector20.Y, num42, weaponDamage2, weaponKnockback2, projectile.owner, 0f, 0f);
						Main.projectile[num44].noDropItem = true;
					}
				}
				else
				{
					projectile.Kill();
				}
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			projectile.alpha = 0;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
		}
	}
}