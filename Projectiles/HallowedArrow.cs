using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class HallowedArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.name = "Hallowed Arrow";
			projectile.width = 14;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.damage = 12;
			projectile.light = 0.4f;
		}
		
		public override void AI()
		{
			int dust = Dust.NewDust(new Vector2((float)projectile.Center.X+Main.rand.Next(-4,5), (float)projectile.Center.Y+Main.rand.Next(-4,5)), projectile.width, projectile.height, 71, projectile.velocity.X*0.1f, projectile.velocity.Y * 0.1f, 100, default(Color), 1f);
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Orchid.ToVector3());
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}