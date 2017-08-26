using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class PhantasmalGun : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantasmal Missile");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.VortexBeater);
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.VortexBeater;
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float num;
			num = 0f;
			if(projectile.spriteDirection == -1)
			{
				num = 3.14159274f;
			}
			projectile.ai[0] += 1f;
			int num33 = 0;
			if(projectile.ai[0] >= 40f)
			{
				num33++;
			}
			if(projectile.ai[0] >= 80f)
			{
				num33++;
			}
			if(projectile.ai[0] >= 120f)
			{
				num33++;
			}
			int num34 = 5;
			int num35 = 0;
			projectile.ai[1] -= 1f;
			bool flag13 = false;
			int num36 = -1;
			if(projectile.ai[1] <= 0f)
			{
				projectile.ai[1] = (float)(num34 - num35 * num33);
				flag13 = true;
				int num37 = (int)projectile.ai[0] / (num34 - num35 * num33);
				if(num37 % 7 == 0)
				{
					num36 = 0;
				}
			}
			projectile.frameCounter += 1 + num33;
			if(projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if(projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
			if(flag13 && Main.myPlayer == projectile.owner)
			{
				bool flag14 = player.channel && player.HasAmmo(player.inventory[player.selectedItem], true) && !player.noItems && !player.CCed;
				int num38 = 14;
				float scaleFactor9 = 14f;
				int weaponDamage = player.GetWeaponDamage(player.inventory[player.selectedItem]);
				float weaponKnockback = player.inventory[player.selectedItem].knockBack;
				if(flag14)
				{
					player.PickAmmo(player.inventory[player.selectedItem], ref num38, ref scaleFactor9, ref flag14, ref weaponDamage, ref weaponKnockback, false);
					weaponKnockback = player.GetWeaponKnockback(player.inventory[player.selectedItem], weaponKnockback);
					float scaleFactor10 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					Vector2 value16 = vector;
					Vector2 value17 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - value16;
					if(player.gravDir == -1f)
					{
						value17.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - value16.Y;
					}
					Vector2 vector18 = Vector2.Normalize(value17);
					if(float.IsNaN(vector18.X) || float.IsNaN(vector18.Y))
					{
						vector18 = -Vector2.UnitY;
					}
					vector18 *= scaleFactor10;
					vector18 = vector18.RotatedBy(Main.rand.NextDouble() * 0.13089969754219055 - 0.065449848771095276, default(Vector2));
					if(vector18.X != projectile.velocity.X || vector18.Y != projectile.velocity.Y)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity = vector18;
					for(int m = 0; m < 1; m++)
					{
						Vector2 spinningpoint2 = Vector2.Normalize(projectile.velocity) * scaleFactor9;
						spinningpoint2 = spinningpoint2.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
						if(float.IsNaN(spinningpoint2.X) || float.IsNaN(spinningpoint2.Y))
						{
							spinningpoint2 = -Vector2.UnitY;
						}
						Projectile.NewProjectile(value16.X, value16.Y, spinningpoint2.X, spinningpoint2.Y, num38, weaponDamage, weaponKnockback, projectile.owner, 0f, 0f);
					}
					if(num36 == 0)
					{
						num38 = 616;
						scaleFactor9 = 8f;
						for(int n = 0; n < 1; n++)
						{
							Vector2 spinningpoint3 = Vector2.Normalize(projectile.velocity) * scaleFactor9;
							spinningpoint3 = spinningpoint3.RotatedBy(Main.rand.NextDouble() * 0.39269909262657166 - 0.19634954631328583, default(Vector2));
							if(float.IsNaN(spinningpoint3.X) || float.IsNaN(spinningpoint3.Y))
							{
								spinningpoint3 = -Vector2.UnitY;
							}
							Projectile.NewProjectile(value16.X, value16.Y, spinningpoint3.X, spinningpoint3.Y, num38, weaponDamage + 20, weaponKnockback * 1.25f, projectile.owner, 0f, 0f);
						}
					}
				}
				else
				{
					projectile.Kill();
				}
			}
		}
	}
}