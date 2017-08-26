using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowNinjaHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Ninja Helmet");
			Tooltip.SetDefault("20% increased throwing velocity");
		}

		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = 5;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownVelocity += 0.2f;
			if(true)
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
				Color color = new Color(0, 255, 255);
				Vector2 eyePos = Vector2.Lerp(vector5, vector4, 1f / (float)num4);
				if(player.mount.Active && !player.mount.Cart)
				{
					eyePos.Y -= MountHeightDeloc(player);
				}
				if(Main.rand.Next(0, 10) == 0)
				{
					Dust edust = Main.dust[Dust.NewDust(player.Center, 0, 0, 67, 0f, 0f, 0, color, 0.75f)];
					int randX = Main.rand.Next(-2, 3);
					int randY = Main.rand.Next(-2, 3);
					Vector2 deloc = new Vector2(randX, randY);
					edust.position = eyePos;
					edust.velocity = new Vector2(-randX, -randY);
					edust.noGravity = true;
				}
				Lighting.AddLight(eyePos, Microsoft.Xna.Framework.Color.Cyan.ToVector3());
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

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ShadowNinjaBreastplate") && legs.type == mod.ItemType("ShadowNinjaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string bonus = "50% chance to not consume thrown item, major life regeneration and invisibility on stand still";
			player.lifeRegen += 5;
			player.thrownCost50 = true;
			if(player.stealth < 0.5f)
			{
				player.stealth = 0.5f;
			}
			player.thrownDamage += ((1f - player.stealth) * 0.6f) * 2f;
			player.thrownCrit += (int)((((1f - player.stealth) * 0.1f) * 100f) * 2f);
			player.rangedDamage -= ((1f - player.stealth) * 0.6f) * 2f;
			player.rangedCrit -= (int)((((1f - player.stealth) * 0.1f) * 100f) * 2f);
			player.shroomiteStealth = true;
			player.setBonus = bonus;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NinjaHood);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(mod.ItemType("ShadowEssence"), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}