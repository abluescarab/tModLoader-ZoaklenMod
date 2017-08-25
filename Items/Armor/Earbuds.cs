using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class Earbuds : ModItem
	{
		int frameCounter = 0;

		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Earbuds";
			item.width = 20;
			item.height = 20;
			item.rare = 8;
			item.vanity = true;
			AddTooltip("\"TF2 represent!\"");
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}

		public override void UpdateVanity(Player player, EquipType type)
		{
			frameCounter++;
			if(frameCounter >= 20)
			{
				frameCounter = 0;
				Color color = new Color();
				float posX;
				if(player.direction > 0)
				{
					posX = player.position.X + (player.direction);
				}
				else
				{
					posX = player.position.X + (player.direction) + 16;
				}
				Vector2 pos = new Vector2(posX, player.position.Y);
				int dust = Dust.NewDust(pos, 10, 12, mod.DustType("Audio"), (player.velocity.X) + (player.direction * -3), player.velocity.Y, 100, color, 1.5f);
				Main.dust[dust].noGravity = true;
			}
			if(player.armor[11].type == mod.ItemType("ZoaklenCoat"))
			{
				int num = 0;
				num += player.bodyFrame.Y / 56;
				if(num >= Main.OffsetsPlayerHeadgear.Length)
				{
					num = 0;
				}
				Vector2 vector = new Vector2((float)(3 * player.direction - ((player.direction == 1) ? 1 : 0)), -11.5f * player.gravDir) + Vector2.UnitY * player.gfxOffY + player.Size / 2f + Main.OffsetsPlayerHeadgear[num];
				Vector2 vector2 = new Vector2((float)(3 * player.shadowDirection[1] - ((player.direction == 1) ? 1 : 0)), -11.5f * player.gravDir) + player.Size / 2f + Main.OffsetsPlayerHeadgear[num];
				Vector2 vector3 = Vector2.Zero;
				if(player.mount.Active && player.mount.Cart)
				{
					int num2 = Math.Sign(player.velocity.X);
					if(num2 == 0)
					{
						num2 = player.direction;
					}
					vector3 = new Vector2(MathHelper.Lerp(0f, -8f, player.fullRotation / 0.7853982f), MathHelper.Lerp(0f, 2f, Math.Abs(player.fullRotation / 0.7853982f))).RotatedBy((double)player.fullRotation, default(Vector2));
					if(num2 == Math.Sign(player.fullRotation))
					{
						vector3 *= MathHelper.Lerp(1f, 0.6f, Math.Abs(player.fullRotation / 0.7853982f));
					}
				}
				if(player.fullRotation != 0f)
				{
					vector = vector.RotatedBy((double)player.fullRotation, player.fullRotationOrigin);
					vector2 = vector2.RotatedBy((double)player.fullRotation, player.fullRotationOrigin);
				}
				Vector2 vector4 = player.position + vector + vector3;
				Vector2 vector5 = player.oldPosition + vector2 + vector3;
				int num4 = (int)Vector2.Distance(vector4, vector5) / 3 + 1;
				if(Vector2.Distance(vector4, vector5) % 3f != 0f)
				{
					num4++;
				}
				Color color = new Color(185, 164, 0);
				Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 182, 0f, 0f, 0, color, 1f)];
				dust.position = Vector2.Lerp(vector5, vector4, 1f / (float)num4);
				if(player.mount.Active && !player.mount.Cart)
				{
					dust.position.Y -= MountHeightDeloc(player);
				}
				dust.velocity = Vector2.Zero;
				dust.noGravity = true;
				dust.fadeIn = 0.01f;
				for(int i = 0; i < 3; i++)
				{
					Dust edust = Main.dust[Dust.NewDust(player.Center, 0, 0, 182, 0f, 0f, 0, color, 0.5f)];
					int randX = Main.rand.Next(4, 17);
					if(player.direction < 0)
					{
						randX *= -1;
					}
					int randY = Main.rand.Next(-8, 8);
					Vector2 deloc = new Vector2(randX, randY);
					edust.position = dust.position + deloc;
					edust.velocity = new Vector2(-randX / 5, -randY / 5);
					edust.noGravity = true;
					edust.fadeIn = 0.01f;
				}
			}
		}

		private float MountHeightDeloc(Player player)
		{
			float deloc = 10;
			switch(player.miscEquips[3].type)
			{
				case 3260:
					{
						deloc = 10f;
						break;
					}
				case 2491:
					{
						deloc = 12f;
						break;
					}
				case 2430:
					{
						deloc = 10f;
						break;
					}
				case 2429:
					{
						deloc = 4.5f;
						break;
					}
				case 2428:
					{
						deloc = 4.5f;
						break;
					}
				case 3367:
					{
						deloc = 2f;
						break;
					}
				case 2768:
					{
						deloc = -2f;
						break;
					}
				case 1914:
					{
						deloc = 18f;
						break;
					}
				case 2502:
					{
						deloc = 9.5f;
						break;
					}
				case 2771:
					{
						deloc = 9.5f;
						break;
					}
				case 2769:
					{
						deloc = 9.5f;
						break;
					}
			}
			return deloc;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TeamDye, 2);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}