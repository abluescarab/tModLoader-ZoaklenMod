using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Marks
{
	public class BullseyeMark : MarkBase
	{
		public override void MarkStaticDefaults()
		{
			DisplayName.SetDefault("Bullseye Mark");
			Tooltip.SetDefault("Doubles critical hit damage\n" +
				"Reduces critical strike chance by 20%");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 6));
		}

		public override void MarkDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 5000000;
			item.rare = -11;
			markId = 2;
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(modPlayer.markActivated)
			{
				damage *= 2;
			}
		}

		public override void MarkEffect(Player player)
		{
			player.thrownCrit -= 20;
			player.magicCrit -= 20;
			player.meleeCrit -= 20;
			player.rangedCrit -= 20;

			float num1005 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1006 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1007 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1008 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1009 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1010 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1011 = num1008;
			for(int num1012 = 0; num1012 < 10; num1012++)
			{
				int num1013 = 60;
				float scaleFactor15 = num1011;
				if(num1012 > 50)
				{
					scaleFactor15 = num1009;
				}
				if(num1012 > 100)
				{
					scaleFactor15 = num1008;
				}
				if(num1012 > 150)
				{
					scaleFactor15 = num1010;
				}
				int num1014 = Dust.NewDust(player.position, 6, 6, num1013, 0f, 0f, 6, default(Color), 1f);
				Vector2 vector123 = Main.dust[num1014].velocity;
				Main.dust[num1014].position = player.Center;
				vector123.Normalize();
				vector123 *= scaleFactor15;
				if(num1012 > 30)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				}
				else if(num1012 > 20)
				{
					vector123.X *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1005, default(Vector2));
				}
				else if(num1012 > 10)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1006, default(Vector2));
				}
				Main.dust[num1014].velocity *= 0.2f;
				Main.dust[num1014].velocity += vector123;
				if(num1012 <= 40)
				{
					Main.dust[num1014].scale = 2f;
					Main.dust[num1014].noGravity = true;
					Main.dust[num1014].fadeIn = Main.rand.NextFloat() * 2f;
					if(Main.rand.Next(4) == 0)
					{
						Main.dust[num1014].fadeIn = 2.5f;
					}
					Main.dust[num1014].noLight = true;
					if(num1012 < 20)
					{
						Main.dust[num1014].position += Main.dust[num1014].velocity * 20f;
						Main.dust[num1014].velocity *= -1f;
					}
				}
			}
		}
	}
}