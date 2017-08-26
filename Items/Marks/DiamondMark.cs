using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Marks
{
	public class DiamondMark : MarkBase
	{
		public override void MarkStaticDefaults()
		{
			DisplayName.SetDefault("Diamonds Mark");
			Tooltip.SetDefault("Increases cards damage by 30%\n" +
				"Increases cards critical strike chance by 20%\n" +
				"Card attack speed increased by 15%");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 11));
		}

		public override void MarkDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = 2000000;
			item.rare = -11;
			markId = 4;
		}

		public override void MarkEffect(Player player)
		{
			string t = player.inventory[player.selectedItem].Name;
			if(t.Contains("Card"))
			{
				player.thrownCrit += 20;
				player.thrownDamage += 0.3f;
				for(int i = 0; i < 10; i++)
				{
					Vector2 pos = new Vector2(player.Center.X + (32+((i-5)*7)), player.Center.Y + (32-((i-5)*9)));
					int dust = Dust.NewDust(pos, 6, 6, 60, 0f, 0f, 6, default(Color), 2f);
					/*Main.dust[dust].velocity.X = (pos.X-player.Center.X)/-16;
					Main.dust[dust].velocity.Y = (pos.Y-player.Center.Y)/-16;*/
					Main.dust[dust].noGravity = true;
				}
				for(int i = 0; i < 10; i++)
				{
					Vector2 pos = new Vector2(player.Center.X - (32+((i-5)*7)), player.Center.Y + (32-((i-5)*9)));
					int dust = Dust.NewDust(pos, 6, 6, 60, 0f, 0f, 6, default(Color), 2f);
					/*Main.dust[dust].velocity.X = (pos.X-player.Center.X)/-16;
					Main.dust[dust].velocity.Y = (pos.Y-player.Center.Y)/-16;*/
					Main.dust[dust].noGravity = true;
				}
				for(int i = 0; i < 10; i++)
				{
					Vector2 pos = new Vector2(player.Center.X - (32+((i-5)*7)), player.Center.Y - (32-((i-5)*9)));
					int dust = Dust.NewDust(pos, 6, 6, 60, 0f, 0f, 6, default(Color), 2f);
					/*Main.dust[dust].velocity.X = (pos.X-player.Center.X)/-16;
					Main.dust[dust].velocity.Y = (pos.Y-player.Center.Y)/-16;*/
					Main.dust[dust].noGravity = true;
				}
				for(int i = 0; i < 10; i++)
				{
					Vector2 pos = new Vector2(player.Center.X + (32+((i-5)*7)), player.Center.Y - (32-((i-5)*9)));
					int dust = Dust.NewDust(pos, 6, 6, 60, 0f, 0f, 6, default(Color), 2f);
					/*Main.dust[dust].velocity.X = (pos.X-player.Center.X)/-16;
					Main.dust[dust].velocity.Y = (pos.Y-player.Center.Y)/-16;*/
					Main.dust[dust].noGravity = true;
				}
			}
		}
	}
}