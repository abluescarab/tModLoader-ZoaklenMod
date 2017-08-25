using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles.Minions
{
	public class Invader1 : InvaderAI
	{
		public override void CustomDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void Attack()
		{
			int a2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y+5, 0, 10f, mod.ProjectileType("Invader2Shot"), (int)(projectile.damage * 0.4f), 0, 0);
		}
	}
}