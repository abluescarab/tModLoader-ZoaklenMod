using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class FiresparkBoots : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Shoes);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Firespark Boots";
			item.width = 24;
			item.height = 28;
			AddTooltip("Allows flight, hyper fast running and extra mobility on ice");
			AddTooltip("Grants immunity to Chilled and Frozen debuffs");
			AddTooltip("Grants 5 seconds of immunity to lava");
			AddTooltip("Increases movement speed after being struck");
			AddTooltip("Provides the ability to walk over liquids");
			AddTooltip("Permanent Swiftness buff");
			AddTooltip2("'Moonwalking would be a terrible idea'");
			item.value = 100000;
			item.rare = 8;
			item.accessory = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			if(Math.Abs(player.velocity.X) > 6f && player.velocity.Y == 0.0 && !player.mount.Active && !player.mount.Cart)
			{
				float posX;
				if(player.direction > 0)
				{
					posX = player.position.X+(player.direction);
				}
				else
				{
					posX = player.position.X+(player.direction)+16;
				}
				Vector2 pos = new Vector2(posX, player.position.Y+36);
				int dust = Dust.NewDust(pos, 8, 8, 6, (player.velocity.X) + (player.direction * -3), player.velocity.Y+44, 0, default(Color), 4f);
				int slot = -1;
				for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
				{
					if(player.armor[l].type == item.type)
					{
						slot = l;
						break;
					}
				}
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.dye[slot].dye, player);
				Main.dust[dust].noGravity = true;
			}
			player.accRunSpeed = 9.0f;
			player.rocketBoots += 1;
			player.moveSpeed += 0.12f;
			player.iceSkate = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.noFallDmg = true;
			player.lavaMax += 300;
			player.panic = true;
			player.waterWalk = true;
			player.fireWalk = true;
			player.AddBuff(BuffID.Swiftness, 2, true);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(ItemID.LavaWaders);
			recipe.AddIngredient(ItemID.PanicNecklace);
			recipe.AddIngredient(ItemID.SwiftnessPotion, 30);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}