using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class Pacman : ModProjectile
	{
		internal int up = 0;
		internal int down = 1;
		internal int left = 2;
		internal int right = 3;
		
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.name = "Pacman";
			projectile.width = 26;
			projectile.height = 26;
			Main.projFrames[projectile.type] = 3;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			projectile.extraUpdates = 10;
		}

		public override void AI()
		{
			// Check conditions
			Player player = Main.player[projectile.owner];
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if (player.dead)
			{
				modPlayer.pacMinion = false;
			}
			if (modPlayer.pacMinion)
			{
				projectile.timeLeft = 2;
			}
			
			projectile.alpha = 0;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 80)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
						
			// Pre-definitions
			int target = -1;
			float minDistance = 9999f;
			bool eyesAlive = false;
			for(int i = 0;i < 200;i++)
			{
				NPC npc = Main.npc[i];
				if(npc.active && (npc.type == NPCID.MoonLordHead || npc.type == NPCID.MoonLordHand) && !npc.dontTakeDamage)
				{
					eyesAlive = true;
					break;
				}
			}
			for(int i = 0;i < 200;i++)
			{
				NPC npc = Main.npc[i];
				if(npc.active && !npc.friendly && projectile.Distance(npc.Center) < minDistance && projectile.Distance(npc.Center) < 600f && npc.lifeMax > 5 && !npc.dontTakeDamage)
				{
					if(npc.type == NPCID.MoonLordCore && eyesAlive)
					{
						continue;
					}
					target = i;
					minDistance = projectile.Distance(npc.Center);
				}
			}
			
			int thisId = 1;
			for(int i = 0;i < 256;i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.type == projectile.type)
				{
					if(proj.identity != projectile.identity)
					{
						thisId++;
					}
					else
					{
						break;
					}
				}
			}

			// AI
			projectile.velocity = Vector2.Zero;
			if(target == -1 || projectile.Distance(player.Center) > 800f)
			{
				if(projectile.Distance(player.Center) > (float)(200f + ((thisId - 1)*30f)))
				{
					float distanceX = Math.Abs(player.Center.X - projectile.Center.X);
					float distanceY = Math.Abs(player.Center.Y - projectile.Center.Y);
					bool xFirst = false;
					if(distanceX > distanceY)
					{
						xFirst = true;
					}
					if(xFirst)
					{
						CheckX(player.Center);
						CheckY(player.Center);
					}
					else
					{
						CheckY(player.Center);
						CheckX(player.Center);
					}
				}
				if(projectile.velocity != Vector2.Zero)
				{
					projectile.rotation = projectile.DirectionTo(projectile.Center + projectile.velocity*10).ToRotation();
				}
			}
			else
			{
				NPC npc = Main.npc[target];
				if(projectile.Distance(npc.Center) > (float)(200f + ((thisId - 1)*30f)))
				{
					float distanceX = Math.Abs(npc.Center.X - projectile.Center.X);
					float distanceY = Math.Abs(npc.Center.Y - projectile.Center.Y);
					bool xFirst = false;
					if(distanceX > distanceY)
					{
						xFirst = true;
					}
					if(xFirst)
					{
						CheckX(npc.Center);
						CheckY(npc.Center);
					}
					else
					{
						CheckY(npc.Center);
						CheckX(npc.Center);
					}
				}
				else
				{
					projectile.rotation = projectile.DirectionTo(npc.Center).ToRotation();
					if(projectile.frameCounter % 79 == 0 && projectile.frame == 0)
					{
						int a2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (projectile.Center.X-npc.Center.X)/30, (projectile.Center.Y-npc.Center.Y)/30, mod.ProjectileType("PacPellets"), projectile.damage, 0, 0);
					}
				}
			}
		}
		
		private void GetRotation()
		{
			if(projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = projectile.DirectionTo(projectile.Center - projectile.velocity).ToRotation();
			}
		}
		
		private void CheckX(Vector2 pos)
		{
			if(projectile.velocity == Vector2.Zero)
			{
				if(pos.X > projectile.Center.X)
				{
					projectile.velocity.X++;
				}
				else if(pos.X < projectile.Center.X)
				{
					projectile.velocity.X--;
				}
			}
		}
		
		private void CheckY(Vector2 pos)
		{
			if(projectile.velocity == Vector2.Zero)
			{
				if(pos.Y > projectile.Center.Y)
				{
					projectile.velocity.Y++;
				}
				else if(pos.Y < projectile.Center.Y)
				{
					projectile.velocity.Y--;
				}
			}
		}
		
		private void SetDirection(int newDir)
		{
			Vector2 newVel = Vector2.Zero;
			switch(newDir)
			{
				case 0:
					newVel = new Vector2(0, -1);
					break;
				case 1:
					newVel = new Vector2(0, 1);
					break;
				case 2:
					newVel = new Vector2(-1, 0);
					break;
				case 3:
					newVel = new Vector2(1, 0);
					break;
			}
			projectile.velocity = newVel;
		}
	}
}