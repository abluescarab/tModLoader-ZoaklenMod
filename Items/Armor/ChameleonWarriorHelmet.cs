using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class ChameleonWarriorHelmet : ModItem
	{
		BiomeInformations biome = new BiomeInformations();

		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			if(Main.gameMenu || !((PlayerChanges)drawPlayer.GetModPlayer(mod, "PlayerChanges")).chameleonMode)
			{
				color = new Color(43, 163, 80);
			}
			else
			{
				biome.player = drawPlayer;
				biome.UpdateInfos();
				color = biome.color;
			}
		}

		public override void SetDefaults()
		{
			item.name = "Chameleon Warrior Helmet";
			AddTooltip("16% increased throwing damage");
			item.value = 300000;
			item.rare = 7;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.yoraiz0rDarkness = true;
			player.thrownDamage += 0.16f;
			biome.player = player;
		}

		public override void UpdateVanity(Player player, EquipType type)
		{
			if(player.armor[10].type == item.type && player.armor[11].type == mod.ItemType("ChameleonWarriorBreastplate") && player.armor[12].type == mod.ItemType("ChameleonWarriorLeggings"))
			{
				((PlayerChanges)player.GetModPlayer(mod, "PlayerChanges")).chameleonMode = true;
			}
			player.yoraiz0rDarkness = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ChameleonWarriorBreastplate") && legs.type == mod.ItemType("ChameleonWarriorLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			modPlayer.chameleonMode = true;
			if(biome.name == "Pacific Place")
			{
				player.statDefense += 4;
				player.thrownDamage += 0.05f;
			}
			else if(biome.name == "Space" || biome.name == "Sky")
			{
				player.wingTimeMax = (int)(player.wingTimeMax * 1.5f);
			}
			else if(biome.name == "Underworld")
			{
				player.fireWalk = true;
				player.lavaMax += 60;
			}
			else if(biome.name == "Dungeon")
			{
				Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
				player.lifeRegen += 3;
			}
			else if(biome.name == "Caverns")
			{
				Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
			}
			else if(biome.name == "Crimson" || biome.name == "Corruption")
			{
				player.lifeRegen += 5;
				player.thrownCrit += 5;
			}
			else if(biome.name == "Hallow")
			{
				player.loveStruck = true;
				player.thrownDamage += 0.1f;
			}
			else if(biome.name == "Mushroom")
			{
				player.shroomiteStealth = true;
				player.thrownDamage += ((1f - player.stealth) * 0.3f);
				player.thrownCrit += (int)(((1f - player.stealth) * 0.1f) * 100f);
				player.rangedDamage -= ((1f - player.stealth) * 0.6f);
				player.rangedCrit -= (int)(((1f - player.stealth) * 0.1f) * 100f);
			}
			else if(biome.name == "Desert")
			{
				player.detectCreature = true;
				player.noFallDmg = true;
			}
			else if(biome.name == "Snow")
			{
				player.buffImmune[46] = true;
				player.buffImmune[47] = true;
			}
			else if(biome.name == "Ocean")
			{
				player.AddBuff(BuffID.Sonar, 2, true);
				player.accDivingHelm = true;
			}
			else if(biome.name == "Jungle")
			{
				player.crystalLeaf = true;
				player.endurance += 0.05f;
				player.honey = true;
			}
			string bonus = "You instantly adapts to any biome";
			player.setBonus = bonus;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = biome.player;
			if(((PlayerChanges)player.GetModPlayer(mod, "PlayerChanges")).chameleonMode)
			{
				biome.UpdateInfos();
				TooltipLine tp = new TooltipLine(mod, "CurrentBiome", "Current Biome: " + biome.name);
				tp.overrideColor = biome.color;
				tooltips.Add(tp);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}