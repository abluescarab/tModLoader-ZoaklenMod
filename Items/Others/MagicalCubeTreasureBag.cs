using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class MagicalCubeTreasureBag : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Treasure Bag";
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.toolTip = "Right Click to open";
			item.expert = true;
			item.rare = 10;
			bossBagNPC = mod.NPCType("MagicalCube");
		}

		public override void UpdateInventory(Player player)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			string weapType = "random";
			if(modPlayer.damageType == 0)
			{
				weapType = "melee";
			}
			else if(modPlayer.damageType == 1)
			{
				weapType = "magic";
			}
			else if(modPlayer.damageType == 2)
			{
				weapType = "ranged";
			}
			else if(modPlayer.damageType == 3)
			{
				weapType = "summon";
			}
			else if(modPlayer.damageType == 4)
			{
				weapType = "throwing";
			}
			item.toolTip2 = "Currently holding a " + weapType + " item type";
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			int wep = -1;
			if(modPlayer.damageType == 0)
			{
				wep = mod.ItemType("BlinkBlade");
			}
			else if(modPlayer.damageType == 1)
			{
				wep = mod.ItemType("TechSmite");
			}
			else if(modPlayer.damageType == 2)
			{
				wep = mod.ItemType("BitCannon");
			}
			else if(modPlayer.damageType == 3)
			{
				wep = mod.ItemType("CyberStaff");
			}
			else if(modPlayer.damageType == 4)
			{
				wep = mod.ItemType("CyberCardA");
			}
			else
			{
				switch(Main.rand.Next(0, 5))
				{
					case 0:
						wep = mod.ItemType("BlinkBlade");
						break;
					case 1:
						wep = mod.ItemType("TechSmite");
						break;
					case 2:
						wep = mod.ItemType("BitCannon");
						break;
					case 3:
						wep = mod.ItemType("CyberStaff");
						break;
					case 4:
						wep = mod.ItemType("CyberCardA");
						break;
				}
			}
			player.QuickSpawnItem(wep);
			player.QuickSpawnItem(mod.ItemType("SuspiciousLookingJoystick"));
		}
	}
}