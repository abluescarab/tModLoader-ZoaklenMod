using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Marks
{
	public class StealthMark : MarkBase
	{
		float currentTick;

		public override void MarkStaticDefaults()
		{
			DisplayName.SetDefault("Stealth Mark");
			Tooltip.SetDefault("100% critical strike chance with ninja related items");
			Main.ReferenceEquals(item.type, new DrawAnimationVertical(30, 2));
		}

		public override void MarkDefaults()
		{
			item.width = 16;
			item.height = 14;
			item.value = 1000000;
			item.rare = -11;
			markId = 5;
		}

		public override void MarkEffect(Player player)
		{
			int t = player.inventory[player.selectedItem].type;
			string itemname = player.inventory[player.selectedItem].Name;
			if(itemname.Contains("Shuriken") || itemname.Contains("Kunai"))
			{
				player.thrownCrit = 100;

				currentTick += 0.1f;
				if(currentTick > 1f)
				{
					currentTick = 0f;
				}
				int num1013 = 54;
				float num1007 = 6.28318548f*currentTick;
				int num1014 = Dust.NewDust(player.position, 6, 6, num1013, 0f, 0f, 6, default(Color), 1.5f);
				Main.dust[num1014].noGravity = true;
				Vector2 vector123 = Main.dust[num1014].velocity;
				Main.dust[num1014].position = player.Center;
				vector123.Normalize();
				vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				vector123.X *= 0.5f;
				vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				vector123.Y *= 0.5f;
				vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				Main.dust[num1014].velocity *= 0.2f;
				Main.dust[num1014].velocity += vector123;
				Main.dust[num1014].noGravity = true;
				Main.dust[num1014].position += Main.dust[num1014].velocity * 50f;
				Main.dust[num1014].velocity *= 0f;
			}
		}
	}
}