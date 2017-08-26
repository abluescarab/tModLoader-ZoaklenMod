using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class MoonFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Fragment");
			Tooltip.SetDefault("'Seems to have some imbued power'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 3));
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 14;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 10;
		}
	}
}