using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class CyberCardC : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Cyber Card";
			projectile.penetrate = 1;
			projectile.thrown = true;
			projectile.aiStyle = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.noDropItem = true;
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.Bullet;
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
			crit = true;
			}
		}
		
		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if(item.melee)
			{
			crit += player.meleeCrit;
			}
			else if(item.magic)
			{
			crit += player.magicCrit;
			}
			else if(item.ranged)
			{
			crit += player.rangedCrit;
			}
			else if(item.thrown)
			{
			crit += player.thrownCrit;
			}
			return crit;
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if(projectile.frameCounter % 2 == 0)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].velocity.X += projectile.velocity.X/2f;
				Main.dust[dust].velocity.Y += projectile.velocity.Y/2f;
			}
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			
			float num138 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
			float num139 = projectile.localAI[0];
			if (num139 == 0f)
			{
				projectile.localAI[0] = num138;
				num139 = num138;
			}
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			float num140 = projectile.position.X;
			float num141 = projectile.position.Y;
			float num142 = 300f;
			bool flag4 = false;
			int num143 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int num144 = 0; num144 < 200; num144++)
				{
					if (Main.npc[num144].CanBeChasedBy(projectile, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num144 + 1)))
					{
						float num145 = Main.npc[num144].position.X + (float)(Main.npc[num144].width / 2);
						float num146 = Main.npc[num144].position.Y + (float)(Main.npc[num144].height / 2);
						float num147 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num145) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num146);
						if (num147 < num142 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num144].position, Main.npc[num144].width, Main.npc[num144].height))
						{
						num142 = num147;
						num140 = num145;
						num141 = num146;
						flag4 = true;
						num143 = num144;
						}
					}
				}
				if (flag4)
				{
					projectile.ai[1] = (float)(num143 + 1);
				}
				flag4 = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num148 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num148].active && Main.npc[num148].CanBeChasedBy(projectile, true) && !Main.npc[num148].dontTakeDamage)
				{
					float num149 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
					float num150 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
					float num151 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num149) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num150);
					if (num151 < 1000f)
					{
						flag4 = true;
						num140 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
						num141 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag4 = false;
			}
			if (flag4)
			{
				float num152 = num139;
				Vector2 vector13 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num153 = num140 - vector13.X;
				float num154 = num141 - vector13.Y;
				float num155 = (float)Math.Sqrt((double)(num153 * num153 + num154 * num154));
				num155 = num152 / num155;
				num153 *= num155;
				num154 *= num155;
				int num156 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num156 - 1) + num153) / (float)num156;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num156 - 1) + num154) / (float)num156;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			for(int i = 0;i < 10;i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
				Main.dust[dust].velocity.X += (int)(-((projectile.velocity.X/2f)+Main.rand.Next(-8, 9)));
				Main.dust[dust].velocity.Y += (int)(-((projectile.velocity.Y/2f)+Main.rand.Next(-8, 9)));
			}
			projectile.type = 0;
			return true;
		}
	}
}