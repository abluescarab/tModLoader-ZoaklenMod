using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChameleonWarriorLeggings : ModItem
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

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chameleon Warrior Leggings");
			Tooltip.SetDefault("10% increased throwing critical strike chance\n" +
				"7% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 180000;
			item.rare = 7;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 10;
			player.moveSpeed += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}