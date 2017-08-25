using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Dusts
{
	public class Neon : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.2f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.color = GetNeonColor();
		}
		
		public override bool MidUpdate(Dust dust)
		{
			int oldAlpha = dust.alpha;
			dust.alpha = (int)(dust.alpha * 1.1f);
			if(dust.alpha == oldAlpha)
			{
				dust.alpha += 3;
			}
			dust.scale = 1f;
			dust.velocity.Y -= 0.2f;
			if(dust.alpha >= 255)
			{
				dust.alpha = 255;
				dust.active = false;
			}
			return false;
		}
		
		private Color GetNeonColor()
		{
			int r = 0, g = 0, b = 0;
			while((r == 255 && g == 255 && b == 255) || (r == 0 && g == 0 && b == 0))
			{
				if(Main.rand.Next(0, 2) == 0)
				{
					r = 255;
				}
				else
				{
					r = 0;
				}
				
				if(Main.rand.Next(0, 2) == 0)
				{
					g = 255;
				}
				else
				{
					g = 0;
				}
				
				if(Main.rand.Next(0, 2) == 0)
				{
					b = 255;
				}
				else
				{
					b = 0;
				}
			}
			
			Color neon = new Color(r, g, b);
			return neon;
		}
	}
}