using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class Invader3Shot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invader Shot");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.width = 4;
			projectile.height = 8;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 45;
			projectile.tileCollide = false;
			projectile.noDropItem = true;
			projectile.minion = true;
			aiType = 14;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			target.AddBuff(mod.BuffType("Virus"), 600, true);
		}
	}
}