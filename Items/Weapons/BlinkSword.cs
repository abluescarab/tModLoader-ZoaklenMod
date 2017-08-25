using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class BlinkSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blink Blade";
			item.damage = 340;
			item.melee = true;
			item.width = 34;
			item.height = 36;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.rare = 10;
			item.crit = 10;
			item.holdStyle = 1;
			item.useSound = 1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.noMelee = true;
			item.toolTip = "'The closer you are, the less you see'";
			item.shoot = mod.ProjectileType("CyberCut");
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			bool can = false;
			if(player.altFunctionUse == 2)
			{
				item.noMelee = true;
				item.damage = 340;
				item.useTime = 60;
				item.useAnimation = 60;
				item.crit = 100;
				item.shoot = mod.ProjectileType("CyberCut");
				
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
						if(Collision.CanHit(player.Center, 1, 1, vector14, 1, 1))
						{
							can = true;
						}
					}
					else
					{
						can = false;
					}
				}
				else
				{
					can = false;
				}
			}
			else
			{
				item.noMelee = false;
				item.damage = 200;
				item.useTime = 10;
				item.useAnimation = 10;
				item.shoot = 0;
				item.crit = 4;
				can = true;
			}
			return can;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(player.altFunctionUse == 2)
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
						player.Teleport(vector14, 1, 0);
						NetMessage.SendData(65, -1, -1, "", 0, (float)player.whoAmI, vector14.X, vector14.Y, 1, 0, 0);
					}
				}
			}
			return true;
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
		
		public override void HoldStyle(Player player)
		{
			player.itemLocation = player.Center;
			switch(player.direction)
			{
				case -1:
					player.itemRotation = 109.7f;
					player.itemLocation.X -= 10f;
					break;
				case 1:
					player.itemRotation = 66.2f;
					player.itemLocation.X += 10;
					break;
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}