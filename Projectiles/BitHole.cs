using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class BitHole : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Bit Hole";
			projectile.penetrate = -1;
			projectile.width = 60;
			projectile.height = 60;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.noDropItem = true;
			projectile.ranged = true;
			projectile.alpha = 255;
		}
		
		public override bool? CanHitNPC(NPC target)
		{
			return false;
		}
				
		public override void AI()
		{
			for(int i = 0;i < 3;i++)
			{
				Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.Center.X+Main.rand.Next(-30, 31), projectile.Center.Y+Main.rand.Next(-30, 31)), 1, 1, mod.DustType("SNeon"), 0f, 0f, 0, default(Color), 1f)];
				dust.noGravity = true;
			}
			for(int i = 0;i < 200;i++)
			{
				NPC npc = Main.npc[i];
				float dist = npc.Distance(projectile.Center);
				if(npc.active && !npc.boss && !npc.friendly && !npc.dontTakeDamage && dist < 500f)
				{
					Vector2 pushForce = new Vector2((projectile.Center.X - npc.Center.X)/(500-dist), (projectile.Center.Y - npc.Center.Y)/(500-dist));
					npc.velocity += pushForce;
				}
			}
		}
				
		public override bool PreKill(int timeLeft)
		{
			for(int i = 0;i < 20;i++)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-24, 25), Main.rand.Next(-24, 25), mod.ProjectileType("CyberBit"), projectile.damage, 0f, projectile.owner);
			}
			projectile.type = 0;
			return true;
		}
	}
}