using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ZoaklenMod.Items.Ingredients
{
	public class MoonFragment : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Moon Fragment";
			item.width = 16;
			item.height = 14;
			item.maxStack = 999;
			AddTooltip("'Seems to have some imbued power'");
			item.value = 10000;
			item.rare = 10;
		}
		
		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(10, 3);
		}
	}
}