using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ZoaklenMod.Items.Accessory
{
	public class HardCoded : ModItem
	{
		int frameCounter = 0;
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Wings);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Hard Coded";
			item.width = 26;
			item.height = 38;
			item.toolTip = "'This can't be simplified'";
			item.value = 300000;
			item.rare = 10;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			frameCounter++;
			player.wingTimeMax = 240;
			if(!hideVisual)
			{
				if(frameCounter >= 15)
				{
					frameCounter = 0;
					int deloc = 0;
					if(player.direction < 0)
					{
						deloc = Main.rand.Next(12, 25);
					}
					else
					{
						deloc = Main.rand.Next(-24, -11);
					}
					int randY = Main.rand.Next(-16, 17);
					int dust = Dust.NewDust(new Vector2(player.Center.X + deloc, player.Center.Y + randY), 6, 6, mod.DustType("HCP"), (float)(deloc * 0.1f), (float)(randY * 0.1f), 15, default(Color), 1f);
					Main.dust[dust].noGravity = true;
				}
			}
		}

		public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2.5f;
		}
	}
}