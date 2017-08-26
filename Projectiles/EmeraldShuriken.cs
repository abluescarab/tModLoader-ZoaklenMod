using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class EmeraldShuriken : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Shuriken");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.penetrate = 2;
			projectile.width = 22;
			projectile.height = 22;
			projectile.damage = 31;
			projectile.thrown = true;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Green.ToVector3());
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}