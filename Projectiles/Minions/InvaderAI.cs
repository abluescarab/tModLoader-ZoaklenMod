using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles.Minions
{
	public abstract class InvaderAI : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.name = "Invader";
			projectile.width = 16;
			projectile.height = 16;
			Main.projFrames[projectile.type] = 2;
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
			CustomDefaults();
		}
		
		public virtual void CustomDefaults()
		{
		}
		
		public virtual void Attack()
		{
		}
		
		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if (player.dead)
			{
				modPlayer.invaderMinion = false;
			}
			if (modPlayer.invaderMinion)
			{
				projectile.timeLeft = 2;
			}
			projectile.alpha = 0;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 80)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
			projectile.rotation = 0;
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
				if(npc.active && !npc.friendly && player.Distance(npc.Center) < minDistance && player.Distance(npc.Center) < 500f && npc.lifeMax > 5 && !npc.dontTakeDamage)
				{
					if(npc.type == NPCID.MoonLordCore && eyesAlive)
					{
						continue;
					}
					target = i;
					minDistance = player.Distance(npc.Center);
				}
			}
			int thisId = 1;
			for(int i = 0;i < 256;i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.name.Contains("Invader"))
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
			
			int invaders = GetTotalInvaders(player);
			
			if(target != -1)
			{
				NPC npc = Main.npc[target];
				
				if(npc.position.Y - (30 * thisId) < projectile.Center.Y)
				{
					projectile.position.Y--;
				}
				else if(npc.position.Y - (30 * thisId) > projectile.Center.Y)
				{
					projectile.position.Y++;
				}
				
				if(npc.Center.X < projectile.Center.X)
				{
					projectile.position.X--;
				}
				else if(npc.Center.X > projectile.Center.X)
				{
					projectile.position.X++;
				}
			
				if(Math.Abs(projectile.Center.X - npc.Center.X) < 100)
				{
					if(projectile.frameCounter % 79 == 0 && projectile.frame == 1)
					{
						Attack();
					}
				}
			}
			else
			{
				thisId--;
				invaders--;
				int groupQuantity = (int)Math.Floor((float)invaders / 5f);
				if(player.Center.X - getFormPosition(thisId, groupQuantity).X < projectile.Center.X)
				{
					projectile.position.X--;
				}
				else if(player.Center.X - getFormPosition(thisId, groupQuantity).X > projectile.Center.X)
				{
					projectile.position.X++;
				}
				
				if(player.Center.Y - getFormPosition(thisId, groupQuantity).Y < projectile.Center.Y)
				{
					projectile.position.Y--;
				}
				else if(player.Center.Y - getFormPosition(thisId, groupQuantity).Y > projectile.Center.Y)
				{
					projectile.position.Y++;
				}
			}
		}
		
		private Vector2 getFormPosition(int tId, int total)
		{
			Vector2 final;
			float ftId = (float)tId;
			int groupId = (int)Math.Floor(ftId/5f);
			groupId = (int)Math.Floor((float)tId/5f);
			int groupT = total;
			final.X = groupId*30-groupT*15;
			final.Y = ((ftId % 5f)+1)*30;
			return final;
		}
		
		private int GetTotalInvaders(Player player)
		{
			return (player.ownedProjectileCounts[mod.ProjectileType("Invader1")] + player.ownedProjectileCounts[mod.ProjectileType("Invader2")] + player.ownedProjectileCounts[mod.ProjectileType("Invader3")]);
		}
	}
}