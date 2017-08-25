using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Marks
{
	public class AssassinMark : MarkBase
	{
		public override void MarkDefaults()
		{
			item.name = "Assassin Mark";
			item.width = 18;
			item.height = 34;
			AddTooltip("Increases damage by 50%");
			item.value = 5000000;
			item.rare = -11;
			markId = 1;
		}

		public override void MarkEffect(Player player)
		{
			player.thrownDamage *= 1.5f;
			player.magicDamage *= 1.5f;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;

			float posX;
			if(player.direction > 0)
			{
				posX = player.position.X + (player.direction) + 20;
			}
			else
			{
				posX = player.position.X + (player.direction) - 20;
			}
			float posY = player.position.Y+(Main.rand.Next(-8, 32));
			Vector2 pos = new Vector2(posX, posY);
			int dust = Dust.NewDust(pos, 8, 8, 59, (player.velocity.X) + (player.direction * -32), 0f, 5, default(Color), 2.5f);
			Main.dust[dust].noGravity = true;
		}

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(6, 10);
		}
	}
}