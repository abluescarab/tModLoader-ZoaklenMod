using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class PacPellets : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Pac Pellets";
			projectile.penetrate = -1;
			projectile.aiStyle = 1;
			projectile.width = 10;
			projectile.height = 10;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 30;
			projectile.tileCollide = false;
			projectile.noDropItem = true;
			projectile.minion = true;
			aiType = 14;
		}
		
		public override void AI()
		{
			for(int i = 0;i < 256;i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.timeLeft > 0 && proj.type == mod.ProjectileType("Pacman") && proj.Distance(projectile.Center) < 30)
				{
					projectile.Kill();
				}
			}
		}
	}
}