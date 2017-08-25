using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class DiamondShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Diamond Shuriken";
			projectile.penetrate = 3;
			projectile.light = 8;
			projectile.width = 22;
			projectile.height = 22;
			projectile.damage = 38;
			projectile.ignoreWater = true;
			projectile.thrown = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}