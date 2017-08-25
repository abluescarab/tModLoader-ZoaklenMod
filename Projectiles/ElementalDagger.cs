using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class ElementalDagger : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.MagicDagger);
			projectile.name = "ElementalDagger";
			projectile.penetrate = 1;
			projectile.width = 14;
			projectile.height = 28;
			Main.projFrames[projectile.type] = 9;
			projectile.damage = 40;
			projectile.thrown = true;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.light = 0;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 600, true);
			target.AddBuff(BuffID.OnFire, 600, true);
			target.AddBuff(BuffID.Frostburn, 600, true);
		}

		public override bool PreAI()
		{
			projectile.alpha = 0;
			projectile.frameCounter++;
			if(projectile.frameCounter >= 10)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 9;
			}
			return true;
		}

		public override void AI()
		{
			int effect;
			int randomNum = Main.rand.Next(0, 3);
			if(randomNum == 0)
			{
				effect = 27;
				Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Purple.ToVector3());
			}
			else if(randomNum == 1)
			{
				effect = 6;
				Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Orange.ToVector3());
			}
			else
			{
				effect = 15;
				Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.AliceBlue.ToVector3());
			}
			Color color = new Color();
			int dust = Dust.NewDust(projectile.position, 4, 4, effect, (projectile.velocity.X) + (projectile.direction * 3), projectile.velocity.Y, 100, color, 1.5f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0.7f;
		}
	}
}