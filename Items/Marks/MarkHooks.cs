using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Marks
{
	public class MarkHooks : GlobalItem
	{
		public override bool UseItem(Item item, Player player)
		{
			if((item.potion && item.healLife > 0) || (item.type == ItemID.LifeCrystal && player.name == "Tester"))
			{
				PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
				modPlayer.markFrames = 0;
				modPlayer.markActivated = true;
			}
			return false;
		}
	}
}