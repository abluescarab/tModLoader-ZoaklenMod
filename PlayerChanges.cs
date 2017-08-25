using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod
{
	public class PlayerChanges : ModPlayer
	{
		public bool shadowOrbMinion = false;
		public bool creeperMinion = false;
		public bool sfaMinion = false;
		public bool invaderMinion = false;
		public bool pacMinion = false;
		public bool practicalCube = false;

		public int damageType = -1;

		public bool markActivated = false;
		public int markFrames = 0;
		public int activeMark = -1;
		public int markDuration = 300;

		public bool virus = false;
		public int lastChange = 0;

		public bool blinkDashing = false;
		public int blinkDashingCounter = 0;

		public int stockedTeleports = 0;
		public float stTick = 0f;

		public bool chameleonMode = false;

		public override void ResetEffects()
		{
			shadowOrbMinion = false;
			creeperMinion = false;
			sfaMinion = false;
			invaderMinion = false;
			pacMinion = false;
			practicalCube = false;
			virus = false;
			chameleonMode = false;
			if(blinkDashingCounter > 0)
			{
				blinkDashingCounter--;
			}
			else
			{
				blinkDashing = false;
			}
			if(lastChange > 0)
			{
				lastChange--;
			}
			if(stockedTeleports > 3)
			{
				stockedTeleports = 3;
			}
			if(!StellarNinja(player))
			{
				stockedTeleports = 0;
			}
		}

		public override void UpdateDead()
		{
			virus = false;
			stockedTeleports = 0;
		}

		public override void UpdateBadLifeRegen()
		{
			if(virus)
			{
				if(player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 5;
			}
		}

		public override void PreUpdate()
		{
			if(blinkDashing)
			{
				for(int i = 0; i < 200; i++)
				{
					NPC npc = Main.npc[i];
					if(npc.active && !npc.friendly && player.Distance(npc.Center) < 100f)
					{
						player.ApplyDamageToNPC(npc, Main.rand.Next(280, 320), 0.5f, player.direction, true);
					}
				}
			}
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref string deathText)
		{
			if(blinkDashing)
			{
				return false;
			}
			return true;
		}

		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if(chameleonMode)
			{
				BiomeInformations biome = new BiomeInformations();
				biome.player = player;
				biome.UpdateInfos();
				if(biome.name == "Sky")
				{
					a = 180;
				}
			}
			if(virus)
			{
				if(Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
				{
					int dust = Dust.NewDust(drawInfo.position + new Vector2(Main.rand.Next(-6, 7), 10f), player.width + 4, player.height + 4, mod.DustType("Neon"), player.velocity.X, player.velocity.Y, 100, default(Color), 0.75f);
					Main.dust[dust].velocity.Y += 3f;
					Main.playerDrawDust.Add(dust);
				}
				fullBright = true;
			}
			if(stockedTeleports > 0)
			{
				stTick += 0.005f;
				if(stTick > 1f)
				{
					stTick = 0f;
				}
				float num1007 = stTick * 6.28318548f;
				int dust = Dust.NewDust(drawInfo.position, player.width + 4, player.height + 4, 64, player.velocity.X, player.velocity.Y, 100, default(Color), (float)(1f + stockedTeleports/3f));
				Vector2 vector123 = Main.dust[dust].velocity;
				Main.dust[dust].position = player.Center;
				vector123.Normalize();
				vector123 *= 30f;
				vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				Main.dust[dust].velocity.X = 0f;
				Main.dust[dust].velocity.Y = 0f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].position += vector123;
				Main.dust[dust].fadeIn = 0.001f;
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.dye[1].dye, player);
				Main.playerDrawDust.Add(dust);
				fullBright = true;
			}
		}

		public override void PostUpdateEquips()
		{
			if(player.armor[0].type == mod.ItemType("HiddenShooterHood") && (player.inventory[player.selectedItem].ranged || player.inventory[player.selectedItem].thrown))
			{
				player.scope = true;
			}
			if(player.inventory[player.selectedItem].type == mod.ItemType("SpaceBlaster"))
			{
				player.scope = true;
			}
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("FrozenShinyStone"))
				{
					if((double)player.statLife <= (double)player.statLifeMax2 * 0.5)
					{
						player.AddBuff(62, 5, true);
					}
				}
				if(player.armor[l].type == mod.ItemType("DivineShield"))
				{
					if((double)player.statLife <= (double)player.statLifeMax2 * 0.5)
					{
						player.AddBuff(62, 5, true);
					}
					player.noKnockback = true;
					if((double)player.statLife > (double)player.statLifeMax2 * 0.25)
					{
						if(player.whoAmI == Main.myPlayer)
						{
							//player.paladinGive = true;
						}
						if(player.miscCounter % 5 == 0)
						{
							int myPlayer = Main.myPlayer;
							if(Main.player[myPlayer].team == player.team && player.team != 0)
							{
								float num3 = player.position.X - Main.player[myPlayer].position.X;
								float num4 = player.position.Y - Main.player[myPlayer].position.Y;
								float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
								if(num5 < 800f)
								{
									Main.player[myPlayer].AddBuff(43, 10, true);
								}
							}
						}
					}
				}
			}
		}

		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(!player.armor[l].expertOnly || Main.expertMode)
				{
					if(player.armor[l].type == mod.ItemType("IchorSack"))
					{
						npc.AddBuff(BuffID.Ichor, 420, false);
					}
					if(player.armor[l].type == mod.ItemType("CursedEye"))
					{
						npc.AddBuff(BuffID.CursedInferno, 420, false);
					}
				}
			}
		}

		public override void UpdateBiomeVisuals()
		{
			bool haveSky = NPC.AnyNPCs(mod.NPCType("MagicalCube"));
			int magicalCubeID = -1;
			for(int i = 0; i < 200; i++)
			{
				if(Main.npc[i].active && Main.npc[i].type == mod.NPCType("MagicalCube"))
				{
					magicalCubeID = i;
					break;
				}
			}
			if(magicalCubeID != -1)
			{
				NPC npc = Main.npc[magicalCubeID];
				int stage = GetStage(npc);
				if(stage == 2)
				{
					player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonLow", haveSky, player.Center);
				}
				else if(stage == 1)
				{
					player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonMedium", haveSky, player.Center);
				}
				else
				{
					player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonHigh", haveSky, player.Center);
				}
			}
			else
			{
				player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonLow", false, player.Center);
				player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonMedium", false, player.Center);
				player.ManageSpecialBiomeVisuals("ZoaklenMod:NeonHigh", false, player.Center);
			}
		}

		private int GetStage(NPC npc)
		{
			int stage = 0;
			float hp = (float)(npc.life);
			float hpM = (float)(npc.lifeMax);
			float hpP = hp/hpM;
			if(!npc.lavaImmune)
			{
				stage = 0;
			}
			else if(npc.lavaImmune && hpP > 0.5f)
			{
				stage = 1;
			}
			else
			{
				stage = 2;
			}
			return stage;
		}

		/*public override Texture2D GetMapBackgroundImage()
		{
			return mod.GetTexture("NeonBackground");
		}*/

		private bool StellarNinja(Player player)
		{
			bool have = false;
			if(player.armor[0].type == mod.ItemType("StellarNinjaHelmet") && player.armor[1].type == mod.ItemType("StellarNinjaBreastplate") && player.armor[2].type == mod.ItemType("StellarNinjaLeggings"))
			{
				have = true;
			}
			return have;
		}
	}
}