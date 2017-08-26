using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class ShinyKunai : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiny Kunai");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 3;
			projectile.aiStyle = 1;
			projectile.width = 26;
			projectile.height = 26;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.noDropItem = false;
			projectile.thrown = true;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
		}

		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if(item.melee)
			{
				crit += player.meleeCrit;
			}
			else if(item.magic)
			{
				crit += player.magicCrit;
			}
			else if(item.ranged)
			{
				crit += player.rangedCrit;
			}
			else if(item.thrown)
			{
				crit += player.thrownCrit;
			}
			return crit;
		}

		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
			for(int i = 0; i < 3; i++)
			{
				int num111 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num111].velocity.X = (projectile.velocity.X * -0.05f) + Main.rand.Next(-4, 5);
				Main.dust[num111].velocity.Y = (projectile.velocity.Y * -0.05f) + Main.rand.Next(-4, 5);
				Main.dust[num111].noGravity = false;
			}
			return true;
		}

		public override void AI()
		{
			projectile.rotation -= 0.9f;
			bool flag3 = false;
			if(projectile.tileCollide)
			{
				Vector2 velocity = projectile.velocity;
				bool flag4 = true;
				int num25 = -1;
				int num26 = -1;
				Vector2 position = projectile.position;
				int num27 = (num25 != -1) ? num25 : projectile.width;
				int num28 = (num26 != -1) ? num26 : projectile.height;
				if(num26 != -1 || num25 != -1)
				{
					position = new Vector2(projectile.position.X + (float)(projectile.width / 2) - (float)(num27 / 2), projectile.position.Y + (float)(projectile.height / 2) - (float)(num28 / 2));
				}

				if(!projectile.wet)
				{
					projectile.velocity = Collision.TileCollision(position, projectile.velocity, num27, num28, flag4, flag4, 1);
					if(!Main.projPet[projectile.type])
					{
						Vector4 vector = Collision.SlopeCollision(position, projectile.velocity, num27, num28, 0f, true);
						Vector2 value2 = projectile.position - position;
						if(position.X != vector.X)
						{
							flag3 = true;
						}
						if(position.Y != vector.Y)
						{
							flag3 = true;
						}
						if(projectile.velocity.X != vector.Z)
						{
							flag3 = true;
						}
						if(projectile.velocity.Y != vector.W)
						{
							flag3 = true;
						}
						position.X = vector.X;
						position.Y = vector.Y;
						projectile.position = position + value2;
						projectile.velocity.X = vector.Z;
						projectile.velocity.Y = vector.W;
					}
				}
				if(velocity != projectile.velocity)
				{
					flag3 = true;
				}
				if(flag3)
				{
					if(projectile.penetrate > 0)
					{
						Main.PlaySound(21, (int)projectile.position.X, (int)projectile.position.Y, 10);
						if(projectile.velocity.X != velocity.X)
						{
							projectile.velocity.X = -velocity.X * 0.75f;
						}
						if(projectile.velocity.Y != velocity.Y)
						{
							projectile.velocity.Y = -velocity.Y * 0.75f;
						}
						for(int i = 0; i < 5; i++)
						{
							int num111 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 64, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num111].velocity.X = Main.rand.Next(-6, 7);
							Main.dust[num111].velocity.Y = Main.rand.Next(-6, 7);
						}
					}
					else
					{
						Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
					}
					for(int i = 0; i < 3; i++)
					{
						int num111 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 64, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num111].velocity.X = (projectile.velocity.X * -0.05f) + Main.rand.Next(-4, 5);
						Main.dust[num111].velocity.Y = (projectile.velocity.Y * -0.05f) + Main.rand.Next(-4, 5);
						Main.dust[num111].noGravity = false;
					}
				}
			}
		}
	}
}