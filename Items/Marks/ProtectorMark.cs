using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Marks
{
	public class ProtectorMark : MarkBase
	{
		int cD;

		public override void MarkStaticDefaults()
		{
			DisplayName.SetDefault("Protector Mark");
			Tooltip.SetDefault("Greatly increases your defense");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 4));
		}

		public override void MarkDefaults()
		{
			item.width = 18;
			item.height = 34;
			item.value = 5000000;
			item.rare = -11;
			markId = 3;
		}

		public override void MarkEffect(Player player)
		{
			player.statDefense += 20; // 10 > 30
			player.statDefense += (int)((player.statDefense * 1.25f) - player.statDefense); // 30 > 45
			if(cD > 128)
			{
				cD = 0;
			}
			cD++;

			float dN = (float)(cD);

			int level = 0;
			if(cD >= 0)
			{
				level = 0;
			}
			if(cD >= 32)
			{
				level = 1;
			}
			if(cD >= 64)
			{
				level = 2;
			}
			if(cD >= 96)
			{
				level = 3;
			}

			if(level == 0)
			{
				int dust1 = Dust.NewDust(new Vector2(player.Center.X - 32, player.Center.Y + ((dN % 32f)*1.4f)), 6, 6, 67, 0f, 0f, 6, default(Color), 2f);
				Main.dust[dust1].noGravity = true;
			}
			else if(level == 1)
			{
				int dust1 = Dust.NewDust(new Vector2(player.Center.X + ((dN % 32f)*1.4f), player.Center.Y + 32), 6, 6, 67, 0f, 0f, 6, default(Color), 2f);
				Main.dust[dust1].noGravity = true;
			}
			else if(level == 2)
			{
				int dust1 = Dust.NewDust(new Vector2(player.Center.X + 32, player.Center.Y - ((dN % 32f)*1.4f)), 6, 6, 67, 0f, 0f, 6, default(Color), 2f);
				Main.dust[dust1].noGravity = true;
			}
			else if(level == 3)
			{
				int dust1 = Dust.NewDust(new Vector2(player.Center.X - ((dN % 32f)*1.4f), player.Center.Y - 32), 6, 6, 67, 0f, 0f, 6, default(Color), 2f);
				Main.dust[dust1].noGravity = true;
			}

			/*for(int i = 0;i < dusts;i++)
			{
				int dust1 = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 6, 6, 67, 0f, 0f, 6, default(Color), 1f);
				Main.dust[dust1].noGravity = true;
				Main.dust[dust1].velocity.X = (float)Main.rand.Next(-16, 17);
				Main.dust[dust1].velocity.Y = (float)Main.rand.Next(-16, 17);
			}*/
		}
	}
}