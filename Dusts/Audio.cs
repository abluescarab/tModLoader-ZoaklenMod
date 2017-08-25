using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Dusts
{
	public class Audio : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.color = new Color(255, 255, 255);
			dust.alpha = 1;
			dust.velocity *= 0.2f;
			dust.noGravity = true;
			dust.noLight = false;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.05f;
			int oldAlpha = dust.alpha;
			dust.alpha = (int)(dust.alpha * 1.2);
			if (dust.alpha == oldAlpha)
			{
				dust.alpha++;
			}
			if (dust.alpha >= 255)
			{
				dust.alpha = 255;
				dust.active = false;
			}
			return false;
		}
	}
}