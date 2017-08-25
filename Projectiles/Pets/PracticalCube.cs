using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles.Pets
{
	public class PracticalCube : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CompanionCube);
			projectile.name = "Practical Cube";
			aiType = ProjectileID.CompanionCube;
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.companionCube = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.dead)
			{
				modPlayer.practicalCube = false;
			}
			if(modPlayer.practicalCube)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}