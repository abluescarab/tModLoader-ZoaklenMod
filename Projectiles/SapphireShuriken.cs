using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class SapphireShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Sapphire Shuriken";
			projectile.penetrate = 2;
			projectile.width = 22;
			projectile.height = 22;
			projectile.damage = 29;
			projectile.ignoreWater = true;
			projectile.thrown = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
		}
		public override void AI()
		{
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Blue.ToVector3());
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}