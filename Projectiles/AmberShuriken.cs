using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class AmberShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Amber Shuriken";
			projectile.penetrate = 3;
			projectile.width = 22;
			projectile.height = 22;
			projectile.damage = 33;
			projectile.thrown = true;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Orange.ToVector3());
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}