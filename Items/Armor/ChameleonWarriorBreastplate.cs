using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class ChameleonWarriorBreastplate : ModItem
	{
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			if(Main.gameMenu || !((PlayerChanges)drawPlayer.GetModPlayer(mod, "PlayerChanges")).chameleonMode)
			{
				color = new Color(43, 163, 80);
			}
			else
			{
				BiomeInformations biome = new BiomeInformations();
				biome.player = drawPlayer;
				biome.UpdateInfos();
				color = biome.color;
			}
		}

		public override void ArmorArmGlowMask(Player drawPlayer, float shadow, ref int glowMask, ref Color color)
		{
			if(Main.gameMenu)
			{
				color = new Color(43, 163, 80);
			}
			else
			{
				BiomeInformations biome = new BiomeInformations();
				biome.player = drawPlayer;
				biome.UpdateInfos();
				color = biome.color;
			}
		}

		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Chameleon Warrior Breastplate";
			AddTooltip("6% increased throwing damage");
			AddTooltip("8% increased throwing critical strike chance");
			item.value = 240000;
			item.rare = 7;
			item.defense = 17;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.06f;
			player.thrownCrit += 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}