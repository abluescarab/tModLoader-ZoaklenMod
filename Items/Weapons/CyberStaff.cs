using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	//imported from my tAPI mod because I'm lazy
	public class CyberStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arcade Staff");
			Tooltip.SetDefault("'Press left click to insert a coin'");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("Invader");
			item.shootSpeed = 0f;
			item.buffType = mod.BuffType("Invader");
			item.buffTime = 3600;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				item.shoot = mod.ProjectileType("Pacman");
				item.buffType = mod.BuffType("Pacman");
			}
			else
			{
				item.shoot = mod.ProjectileType("Invader" + Main.rand.Next(1, 4));
				item.buffType = mod.BuffType("Invader");
			}
			return base.CanUseItem(player);
		}

	}
}