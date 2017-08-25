using Terraria;

namespace ZoaklenMod.Projectiles.Minions
{
	public class Invader3 : InvaderAI
	{
		public override void CustomDefaults()
		{
			projectile.width = 24;
			projectile.height = 16;
		}

		public override void Attack()
		{
			int a2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y+5, 0, 10f, mod.ProjectileType("Invader3Shot"), (int)(projectile.damage * 0.4f), 0, 0);
		}
	}
}