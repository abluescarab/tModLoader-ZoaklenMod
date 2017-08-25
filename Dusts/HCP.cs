using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Dusts
{
	public class HCP : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.color = new Color(255, 255, 255);
		}

		public override bool MidUpdate(Dust dust)
		{
			dust.rotation = 0f;
			dust.alpha += 3;
			if(dust.alpha >= 255)
			{
				dust.alpha = 255;
				dust.active = false;
			}
			dust.color = new Color(255, 255, 255);
			return false;
		}
	}
}