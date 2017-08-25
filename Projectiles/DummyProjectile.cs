using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class DummyProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Dummy Projectile";
			projectile.penetrate = 0;
			projectile.width = 1;
			projectile.height = 1;
			projectile.damage = 0;
			projectile.ignoreWater = false;
			projectile.friendly = true;
			projectile.timeLeft = 2;
			projectile.light = 0;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}