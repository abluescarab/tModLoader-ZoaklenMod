using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using ZoaklenMod.Items;

namespace ZoaklenMod
{
	public class ZoaklenMod : Mod
	{
		private double zoaklenKeyTime;
        public ZoaklenMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

		public override void Load()
		{
			RegisterHotKey("ZoaklenMod Active Buffs", "Z");
			Filters.Scene["ZoaklenMod:NeonHigh"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.15f, 0.6f, 0.15f).UseOpacity(0.6f), EffectPriority.High);
			SkyManager.Instance["ZoaklenMod:NeonHigh"] = new NeonHighSky();
			Filters.Scene["ZoaklenMod:NeonMedium"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.8f, 0.6f, 0f).UseOpacity(0.3f), EffectPriority.High);
			SkyManager.Instance["ZoaklenMod:NeonMedium"] = new NeonMediumSky();
			Filters.Scene["ZoaklenMod:NeonLow"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.8f, 0.2f, 0.2f).UseOpacity(0.4f), EffectPriority.High);
			SkyManager.Instance["ZoaklenMod:NeonLow"] = new NeonLowSky();
		}

		public override void Unload()
		{
			// Does nothing...
		}
		
		private void Teleport(Vector2 newPos, int Style = 0, int extraInfo = 0)
		{
			Player player = Main.player[Main.myPlayer];
			try
			{
				player.grappling[0] = -1;
				player.grapCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
					{
						Main.projectile[i].Kill();
					}
				}
				int extraInfo2 = 0;
				if (Style == 4)
				{
					extraInfo2 = player.lastPortalColorIndex;
				}
				float num = Vector2.Distance(player.position, newPos);
				player.position = newPos;
				player.fallStart = (int)(player.position.Y / 16f);
				if (player.whoAmI == Main.myPlayer)
				{
					if (num < new Vector2((float)Main.screenWidth, (float)Main.screenHeight).Length() / 2f + 100f)
					{
						int time = 0;
						if (Style == 1)
						{
							time = 10;
						}
						Main.SetCameraLerp(0.1f, time);
					}
					else
					{
						Main.BlackFadeIn = 255;
						Lighting.BlackOut();
						Main.screenLastPosition = Main.screenPosition;
						Main.screenPosition.X = player.position.X + (float)(player.width / 2) - (float)(Main.screenWidth / 2);
						Main.screenPosition.Y = player.position.Y + (float)(player.height / 2) - (float)(Main.screenHeight / 2);
						Main.quickBG = 10;
					}
					if (Main.mapTime < 5)
					{
						Main.mapTime = 5;
					}
					Main.maxQ = true;
					Main.renderNow = true;
				}
				if (Style == 4)
				{
					player.lastPortalColorIndex = extraInfo;
					extraInfo2 = player.lastPortalColorIndex;
					player.portalPhysicsFlag = true;
					player.gravity = 0f;
				}
				for (int j = 0; j < 3; j++)
				{
					player.UpdateSocialShadow();
				}
				player.oldPosition = player.position;
				player.teleportTime = 1f;
				player.teleportStyle = Style;
			}
			catch
			{
			}
		}
		
		public override void HotKeyPressed(string name)
		{
			if (name == "ZoaklenMod Active Buffs")
			{
				bool StellarSet = false;
				bool StellarGear = false;
				Player player = Main.player[Main.myPlayer];
				for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
				{
					if(player.armor[l].type == this.ItemType("NinjaSkills"))
					{
						StellarGear = true;
						break;
					}
				}
				if(StellarGear && player.armor[0].type == this.ItemType("StellarNinjaHelmet") && player.armor[1].type == this.ItemType("StellarNinjaBreastplate") && player.armor[2].type == this.ItemType("StellarNinjaLeggings"))
				{
					StellarSet = true;
				}
				PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(this, "PlayerChanges");
				if(StellarSet && modPlayer.stockedTeleports > 0)
				{
					Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
					Vector2 vector9;
					vector9.X = (float)Main.mouseX + Main.screenPosition.X;
					vector9.Y = (float)Main.mouseY + Main.screenPosition.Y;
					float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
					float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
					Vector2 vector14;
					vector14.X = (float)Main.mouseX + Main.screenPosition.X;
					if (player.gravDir == 1f)
					{
						vector14.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)player.height;
					}
					else
					{
						vector14.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
					}
					vector14.X -= (float)(player.width / 2);
					if (vector14.X > 50f && vector14.X < (float)(Main.maxTilesX * 16 - 50) && vector14.Y > 50f && vector14.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int num245 = (int)(vector14.X / 16f);
						int num246 = (int)(vector14.Y / 16f);
						if ((Main.tile[num245, num246].wall != 87 || (double)num246 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(vector14, player.width, player.height))
						{
							if(Math.Abs(Main.time - zoaklenKeyTime) > 90)
							{
								for (int num648 = 0; num648 < 20; num648++)
								{
									int num649 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 1.5f);
									Main.dust[num649].velocity *= 1.4f;
								}
								for (int num650 = 0; num650 < 10; num650++)
								{
									int num651 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2.5f);
									Main.dust[num651].noGravity = true;
									Main.dust[num651].velocity *= 5f;
									num651 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
									Main.dust[num651].velocity *= 3f;
								}
								zoaklenKeyTime = Main.time;
								modPlayer.stockedTeleports--;
								player.rocketTime += player.rocketTimeMax/2;
								player.rocketDelay = 0;
								player.rocketFrame = false;
								player.Teleport(vector14, 1, 0);
								NetMessage.SendData(65, -1, -1, "", 0, (float)player.whoAmI, vector14.X, vector14.Y, 1, 0, 0);
								for (int num648 = 0; num648 < 20; num648++)
								{
									int num649 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 1.5f);
									Main.dust[num649].velocity *= 1.4f;
								}
								for (int num650 = 0; num650 < 10; num650++)
								{
									int num651 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2.5f);
									Main.dust[num651].noGravity = true;
									Main.dust[num651].velocity *= 5f;
									num651 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
									Main.dust[num651].velocity *= 3f;
								}
								Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 14);
								Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 15);
							}
						}
					}
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronBar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Shuriken, 30);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LeadBar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Shuriken, 30);
			recipe.AddRecipe();
		}
				
		public static bool NoInvasion(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
		}

		public static bool NoBiome(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
		}

		public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
		}

		public static bool NoZone(NPCSpawnInfo spawnInfo)
		{
			return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
		}

		public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
		}

		public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
		}

		public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
		}

		public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
		}
	}
}