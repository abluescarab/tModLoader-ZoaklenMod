using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class CyberCardD : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber Card (Viper)");
			Tooltip.SetDefault("Passive: Debuffs the target a lot");
		}

		public override void SetDefaults()
		{
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 10;
			item.consumable = false;
			item.shootSpeed = 10.0f;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 50;
			item.damage = 200;
			item.thrown = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CyberCardD");
			item.crit = 6;
		}

		public override bool ConsumeItem(Player player)
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
			if(cardBonus && Main.rand.Next(3) == 0)
			{
				return false;
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
			if(cardBonus2 && Main.rand.Next(2) == 0)
			{
				return false;
			}
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			bool returnValue = base.CanUseItem(player);
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.altFunctionUse == 2)
			{
				if(modPlayer.lastChange <= 0)
				{
					int stack = player.inventory[player.selectedItem].stack;
					player.inventory[player.selectedItem].stack = -1;
					player.inventory[player.selectedItem].active = false;
					int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("CyberCardE"), stack, false, 0, false, false);
					Main.item[num].newAndShiny = false;
					Main.player[Main.myPlayer].itemTime = 30;
					returnValue = false;
					modPlayer.lastChange = 15;
				}
			}
			return returnValue;
		}

		private int FindPlayerItemSlot(int type, Player player)
		{
			for(int i = 0; i < 59; i++)
			{
				if(player.inventory[i].type == type)
				{
					return i;
				}
			}
			return -1;
		}
	}
}