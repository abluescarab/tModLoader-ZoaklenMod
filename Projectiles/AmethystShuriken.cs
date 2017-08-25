using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class AmethystShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Amethyst Shuriken";
			projectile.penetrate = 1;
			projectile.width = 22;
			projectile.thrown = true;
			projectile.height = 22;
			projectile.damage = 25;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Pink.ToVector3());
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}