using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class VanillaCustomizations : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if(item.type == ItemID.Bananarang ||
				item.type == ItemID.BloodyMachete ||
				item.type == ItemID.DayBreak ||
				item.type == ItemID.EnchantedBoomerang ||
				item.type == ItemID.Flamarang ||
				item.type == ItemID.FruitcakeChakram ||
				item.type == ItemID.IceBoomerang ||
				item.type == ItemID.LightDisc ||
				item.type == ItemID.MagicDagger ||
				item.type == ItemID.PossessedHatchet ||
				item.type == ItemID.ScourgeoftheCorruptor ||
				item.type == ItemID.ThornChakram ||
				item.type == ItemID.VampireKnives ||
				item.type == ItemID.WoodenBoomerang ||
				item.type == ItemID.PaladinsHammer ||
				item.type == ItemID.ShadowFlameKnife ||
				item.type == ItemID.ToxicFlask ||
				item.type == ItemID.FlyingKnife)
			{
				tooltips.Add(new TooltipLine(mod, "RightClickDamageTypeChange", "Right-click to change damage type"));
			}

			if(item.type == ItemID.Cannonball)
			{
				item.ammo = 162;
			}

			if(item.type == ItemID.GladiatorHelmet)
			{
				item.defense = 5;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "20% increased throwing critical strike chance"));
			}
			if(item.type == ItemID.GladiatorBreastplate)
			{
				item.defense = 9;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "20% increased throwing damage"));
			}
			if(item.type == ItemID.GladiatorLeggings)
			{
				item.defense = 4;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "10% increased movement speed"));
			}
			if(item.type == ItemID.MagicDagger)
			{
				item.damage = 35;
				item.autoReuse = true;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "Does not consume on use"));
			}

			if(item.type == ItemID.ObsidianHelm)
			{
				item.defense = 6;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "15% increased throwing velocity"));
			}
			if(item.type == ItemID.ObsidianShirt)
			{
				item.defense = 10;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "15% increased throwing damage"));
			}
			if(item.type == ItemID.ObsidianPants)
			{
				item.defense = 4;
				item.rare = 3;
				tooltips.Add(new TooltipLine(mod, "ZoaklenMod", "25 % increased throwing critical strike chance"));
			}
		}

		public override bool CanRightClick(Item item)
		{
			if(IsThrowableItem(item))
			{
				return true;
			}
			return false;
		}

		public override void RightClick(Item item, Player player)
		{
			int t = item.type;
			if(t == ItemID.Bananarang)
			{
				player.QuickSpawnItem(mod.ItemType("Bananarang"));
			}
			else if(t == ItemID.BloodyMachete)
			{
				player.QuickSpawnItem(mod.ItemType("BloodyMachete"));
			}
			else if(t == ItemID.DayBreak)
			{
				player.QuickSpawnItem(mod.ItemType("DayBreak"));
			}
			else if(t == ItemID.EnchantedBoomerang)
			{
				player.QuickSpawnItem(mod.ItemType("EnchantedBoomerang"));
			}
			else if(t == ItemID.Flamarang)
			{
				player.QuickSpawnItem(mod.ItemType("Flamarang"));
			}
			else if(t == ItemID.FruitcakeChakram)
			{
				player.QuickSpawnItem(mod.ItemType("FruitcakeChakram"));
			}
			else if(t == ItemID.IceBoomerang)
			{
				player.QuickSpawnItem(mod.ItemType("IceBoomerang"));
			}
			else if(t == ItemID.LightDisc)
			{
				player.QuickSpawnItem(mod.ItemType("LightDisc"));
			}
			else if(t == ItemID.MagicDagger)
			{
				player.QuickSpawnItem(mod.ItemType("MagicDagger"));
			}
			else if(t == ItemID.PossessedHatchet)
			{
				player.QuickSpawnItem(mod.ItemType("PossessedHatchet"));
			}
			else if(t == ItemID.ScourgeoftheCorruptor)
			{
				player.QuickSpawnItem(mod.ItemType("ScourgeOfTheCorruptor"));
			}
			else if(t == ItemID.ThornChakram)
			{
				player.QuickSpawnItem(mod.ItemType("ThornChakram"));
			}
			else if(t == ItemID.VampireKnives)
			{
				player.QuickSpawnItem(mod.ItemType("VampireKnives"));
			}
			else if(t == ItemID.WoodenBoomerang)
			{
				player.QuickSpawnItem(mod.ItemType("WoodenBoomerang"));
			}
			else if(t == ItemID.PaladinsHammer)
			{
				player.QuickSpawnItem(mod.ItemType("PaladinsHammer"));
			}
			else if(t == ItemID.ShadowFlameKnife)
			{
				player.QuickSpawnItem(mod.ItemType("ShadowflameKnife"));
			}
			else if(t == ItemID.ToxicFlask)
			{
				player.QuickSpawnItem(mod.ItemType("ToxicFlask"));
			}
			else if(t == ItemID.FlyingKnife)
			{
				player.QuickSpawnItem(mod.ItemType("FlyingKnife"));
			}
		}

		private bool IsThrowableItem(Item item)
		{
			int t = item.type;
			if(t == ItemID.Bananarang || t == ItemID.BloodyMachete || t == ItemID.DayBreak || t == ItemID.EnchantedBoomerang || t == ItemID.Flamarang || t == ItemID.FruitcakeChakram || t == ItemID.IceBoomerang || t == ItemID.LightDisc || t == ItemID.MagicDagger || t == ItemID.PossessedHatchet || t == ItemID.ScourgeoftheCorruptor || t == ItemID.ThornChakram || t == ItemID.VampireKnives || t == ItemID.WoodenBoomerang || t == ItemID.PaladinsHammer || t == ItemID.ShadowFlameKnife || t == ItemID.ToxicFlask || t == ItemID.FlyingKnife)
			{
				return true;
			}
			return false;
		}

		public override void UpdateEquip(Item item, Player player)
		{
			if(item.type == ItemID.ObsidianHelm)
			{
				player.thrownVelocity += 15;
			}
			else if(item.type == ItemID.ObsidianShirt)
			{
				player.thrownDamage += 0.15f;
			}
			else if(item.type == ItemID.ObsidianPants)
			{
				player.thrownCrit += 25;
			}
			else if(item.type == ItemID.GladiatorHelmet)
			{
				player.thrownCrit += 20;
			}
			else if(item.type == ItemID.GladiatorBreastplate)
			{
				player.thrownDamage += 0.2f;
			}
			else if(item.type == ItemID.GladiatorLeggings)
			{
				player.moveSpeed += 0.1f;
			}
		}

		public override bool ConsumeAmmo(Item item, Player player)
		{
			if(player.armor[0].type == mod.ItemType("HiddenShooterHood") && player.armor[1].type == mod.ItemType("HiddenShooterCoat") && player.armor[2].type == mod.ItemType("HiddenShooterPants"))
			{
				if(Main.rand.Next(2) == 0)
				{
					return false;
				}
			}
			bool quiver = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("OddQuiver"))
				{
					quiver = true;
					break;
				}
			}
			if(quiver && item.ammo == 1 && Main.rand.Next(10) == 0)
			{
				return false;
			}
			return true;
		}

		public override string IsArmorSet(Item head, Item body, Item legs)
		{
			if(head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
			{
				return "Obsidian";
			}
			if(head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings)
			{
				return "Gladiator";
			}
			return "";
		}

		public override void UpdateArmorSet(Player player, string set)
		{
			if(set == "Obsidian")
			{
				player.setBonus = "33% chance to not consume thrown item";
				player.thrownCost33 = true;
			}
			if(set == "Gladiator")
			{
				player.setBonus = "Javelins causes 15% more damage and reduces enemies speed";
			}
		}

		public override void GetWeaponDamage(Item item, Player player, ref int damage)
		{
			bool cardBonus = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("CardGlove"))
				{
					cardBonus = true;
					break;
				}
			}
			bool cardBonus2 = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("TeraCardGlove"))
				{
					cardBonus2 = true;
					break;
				}
			}
			if(cardBonus && player.inventory[player.selectedItem].Name.Contains("Card"))
			{
				damage = (int)(damage * 1.1f);
			}
			if(cardBonus2 && player.inventory[player.selectedItem].Name.Contains("Card"))
			{
				damage = (int)(damage * 1.2f);
			}
			if(SuperBees(player) && BeeItem(item))
			{
				damage = (int)(damage * 2f);
			}
			int t = item.type;
			if(player.armor[0].type == mod.ItemType("PaladinHelmet") && player.armor[1].type == mod.ItemType("PaladinBreastplate") && player.armor[2].type == mod.ItemType("PaladinLeggings") && (item.type == ItemID.PaladinsHammer || item.type == mod.ItemType("PaladinsHammer") || t == ItemID.Bananarang || t == ItemID.BloodyMachete || t == ItemID.EnchantedBoomerang || t == ItemID.Flamarang || t == ItemID.FruitcakeChakram || t == ItemID.IceBoomerang || t == ItemID.LightDisc || t == ItemID.PossessedHatchet || t == ItemID.ThornChakram || t == ItemID.WoodenBoomerang || t == mod.ItemType("Bananarang") || t == mod.ItemType("BloodyMachete") || t == mod.ItemType("EnchantedBoomerang") || t == mod.ItemType("Flamarang") || t == mod.ItemType("FruitcakeChakram") || t == mod.ItemType("IceBoomerang") || t == mod.ItemType("LightDisc") || t == mod.ItemType("PossessedHatchet") || t == mod.ItemType("ThornChakram") || t == mod.ItemType("WoodenBoomerang")))
			{
				damage = (int)(damage * 1.5f);
			}
			if(player.armor[0].type == ItemID.GladiatorHelmet && player.armor[1].type == ItemID.GladiatorBreastplate && player.armor[2].type == ItemID.GladiatorLeggings && (item.type == ItemID.Javelin || item.type == ItemID.BoneJavelin))
			{
				damage = (int)(damage * 1.15f);
			}
		}

		private bool SuperBees(Player player)
		{
			bool have = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("BeeEnrager"))
				{
					have = true;
					break;
				}
			}
			return have;
		}

		private bool BeeItem(Item item)
		{
			string t = item.Name;
			if(t.Contains("Bee") || t.Contains("Wasp") || t.Contains("Hornet"))
			{
				return true;
			}
			return false;
		}

		public override void UpdateInventory(Item item, Player player)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			string t = item.Name;
			if(item.type == ItemID.MasterBait)
			{
				if(Main.rand.Next(10) == 0)
				{
					item.SetNameOverride("Marina Joyce");
				}
				else
				{
					item.SetNameOverride("Master Bait");
				}
			}

			if((t.Contains("Card")))
			{
				if(modPlayer.activeMark == 4 && modPlayer.markActivated)
				{
					if(item.type != mod.ItemType("CyberCardA"))
					{
						item.useTime = 10;
						item.useAnimation = 10;
					}
					else
					{
						item.useTime = 8;
						item.useAnimation = 8;
					}
				}
				else
				{
					if(item.type != mod.ItemType("CyberCardA"))
					{
						item.useTime = 15;
						item.useAnimation = 15;
					}
					else
					{
						item.useTime = 12;
						item.useAnimation = 12;
					}
				}
			}
		}

		public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if(SuperBees(player) && BeeItem(item))
			{
				damage = (int)(damage * 2f);
			}
			if(crit && player.armor[0].type == mod.ItemType("HiddenShooterHood") && player.armor[1].type == mod.ItemType("HiddenShooterCoat") && player.armor[2].type == mod.ItemType("HiddenShooterPants"))
			{
				damage = (int)(damage * 1.5f);
			}
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(crit && modPlayer.activeMark == 2 && modPlayer.markActivated)
			{
				damage = (int)(damage * 2f);
			}
			if(player.armor[0].type == ItemID.GladiatorHelmet && player.armor[1].type == ItemID.GladiatorBreastplate && player.armor[2].type == ItemID.GladiatorLeggings && (item.type == ItemID.Javelin || item.type == ItemID.BoneJavelin))
			{
				target.AddBuff(BuffID.Slow, 300, true);
			}
			if(target.FindBuffIndex(mod.BuffType("Virus")) != -1)
			{
				damage = (int)(damage * 1.2f);
			}
		}

		public override bool AltFunctionUse(Item item, Player player)
		{
			if(item.type == ItemID.DaedalusStormbow)
			{
				return true;
			}
			return false;
		}
	}
}