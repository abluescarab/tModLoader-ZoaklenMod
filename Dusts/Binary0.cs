using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Dusts
{
	public class Binary0 : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			//dust.color = new Color(0, 255, 0);
			dust.alpha = 1;
			dust.velocity *= 0.2f;
			dust.noGravity = true;
			dust.noLight = true;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			int oldAlpha = dust.alpha;
			dust.alpha = (int)(dust.alpha * 2.1f);
			if(dust.alpha == oldAlpha)
			{
				dust.alpha++;
			}
			if(dust.alpha >= 255)
			{
				dust.alpha = 255;
				dust.active = false;
			}
			return false;
		}
	}
}