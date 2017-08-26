using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class SuspiciousLookingJoystick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Looking Joystick");
			Tooltip.SetDefault("'Reward for defeating the techno doom'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CompanionCube);
			item.rare = 10;
			item.shoot = mod.ProjectileType("PracticalCube");
			item.buffType = mod.BuffType("PracticalCube");
		}

		public override void UseStyle(Player player)
		{
			if(player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}