using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StellarNinjaHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stellar Ninja Helmet");
			Tooltip.SetDefault("50% chance to not consume thrown item\n" +
				"You are now smart as a ninja.");
		}

		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = -11;
			item.defense = 19;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCost50 = true;
			player.armorPenetration += 10;
			player.noFallDmg = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("StellarNinjaBreastplate") && legs.type == mod.ItemType("StellarNinjaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			Lighting.AddLight(player.position, Microsoft.Xna.Framework.Color.Gold.ToVector3());
			string bonus = "Major life regeneration";
			bool StellarGear = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("NinjaSkills"))
				{
					StellarGear = true;
					break;
				}
			}
			if(StellarGear)
			{
				bonus += " and press [Z] to quick teleport to your cursor position";
			}
			if(player.name == "Zoaklen")
			{
				bonus += "\n'Strange things are happening with you...'";
				player.lifeRegen += 30;
				player.thrownDamage += 0.5f;
				player.AddBuff(BuffID.Shine, 2);
				player.iceBarrier = true;
				player.iceBarrierFrameCounter += 1;
				if(player.iceBarrierFrameCounter > 2)
				{
					player.iceBarrierFrameCounter = 0;
					player.iceBarrierFrame += 1;
					if(player.iceBarrierFrame >= 12)
					{
						player.iceBarrierFrame = 0;
					}
				}
			}
			player.lifeRegen += 4;
			player.setBonus = bonus;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(null, "StellarFragment", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}