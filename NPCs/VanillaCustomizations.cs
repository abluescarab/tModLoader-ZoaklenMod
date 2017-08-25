using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.NPCs
{
	public class VanillaCustomizations : GlobalNPC
	{
		public override void ResetEffects(NPC npc)
		{
			npc.GetModInfo<NPCChanges>(mod).virus = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if(npc.GetModInfo<NPCChanges>(mod).virus)
			{
				if(npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 125;
				if(damage < 25)
				{
					damage = 25;
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if(npc.GetModInfo<NPCChanges>(mod).virus)
			{
				int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Neon"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
				Main.dust[dust].velocity *= 1.8f;
				Main.dust[dust].velocity.Y -= 0.5f;
				Lighting.AddLight(npc.position, Main.dust[dust].color.R / 255, Main.dust[dust].color.G / 255, Main.dust[dust].color.B / 255);
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if(type == 207)
			{
				shop.item[nextSlot].SetDefaults(ItemID.TeamDye);
				nextSlot++;
			}
			if(type == 17)
			{
				if(Main.pumpkinMoon)
				{
					shop.item[nextSlot++].SetDefaults(mod.ItemType("ZoaklenCoat"));
				}
				for(int k = 0; k < 255; k++)
				{
					Player player = Main.player[k];
					if(player.active)
					{
						for(int j = 0; j < player.inventory.Length; j++)
						{
							if(player.inventory[j].type == ItemID.PlatinumCoin && player.inventory[j].stack >= 5)
							{
								shop.item[31].SetDefaults(mod.ItemType("AssassinMark"));
								shop.item[32].SetDefaults(mod.ItemType("BullseyeMark"));
								shop.item[33].SetDefaults(mod.ItemType("ProtectorMark"));
								shop.item[34].SetDefaults(mod.ItemType("StealthMark"));
							}
							if(player.inventory[j].type == ItemID.PlatinumCoin && player.inventory[j].stack >= 2)
							{
								shop.item[30].SetDefaults(mod.ItemType("DiamondMark"));
							}
						}
					}
				}
			}
		}

		public override void NPCLoot(NPC npc)
		{
			if(npc.type == NPCID.GreekSkeleton)
			{
				if(Main.rand.Next(100) < 25)
				{
					int drop = 0;
					switch(Main.rand.Next(3))
					{
						case 0:
							{
								drop = ItemID.GladiatorHelmet;
								break;
							}
						case 1:
							{
								drop = ItemID.GladiatorBreastplate;
								break;
							}
						case 2:
							{
								drop = ItemID.GladiatorLeggings;
								break;
							}
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, drop);
				}
			}
			if(npc.type == NPCID.MoonLordCore)
			{
				int quantity = 0;
				if(Main.expertMode)
				{
					quantity = Main.rand.Next(13, 26);
				}
				else
				{
					quantity = Main.rand.Next(6, 17);
				}
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoonFragment"), quantity);
			}
			if(npc.type == NPCID.Paladin)
			{
				int min = 1, max = 2;
				if(Main.expertMode)
				{
					min++;
					max++;
				}
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinBar"), Main.rand.Next(min, max + 1));
				if(Main.rand.Next(100) < 10)
				{
					int itemid = -1;
					switch(Main.rand.Next(3))
					{
						case 0:
							{
								itemid = mod.ItemType("PaladinHelmet");
								break;
							}
						case 1:
							{
								itemid = mod.ItemType("PaladinBreastplate");
								break;
							}
						case 2:
							{
								itemid = mod.ItemType("PaladinLeggings");
								break;
							}
					}
					if(itemid != -1)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, itemid);
					}
				}
			}
			if(npc.type == NPCID.WallofFlesh)
			{
				if(Main.rand.Next(100) < 20)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NinjaEmblem"));
				}
			}
			if(npc.type == NPCID.Creeper)
			{
				if(Main.rand.Next(100) < 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreeperStaff"));
				}
			}
			if(npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
			{
				if(Main.rand.Next(100) < 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrbStaff"));
				}
			}
			if(npc.type == NPCID.IchorSticker)
			{
				if(Main.rand.Next(100) < 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorSack"));
				}
			}
			if(npc.type == NPCID.Clinger)
			{
				if(Main.rand.Next(100) < 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedEye"));
				}
			}
			if(npc.type == NPCID.GoblinSummoner)
			{
				if(Main.rand.Next(100) < 33)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameStaff"));
				}
			}
		}
	}
}