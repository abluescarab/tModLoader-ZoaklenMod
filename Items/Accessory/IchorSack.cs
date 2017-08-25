using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class IchorSack : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ichor Sack";
			item.width = 24;
			item.height = 24;
			AddTooltip("Grants immunity to Ichor debuff");
			AddTooltip("Inflicts Ichor debuff for 7 seconds to enemies who damages you");
			AddTooltip2("'Its hole spits on you when you are not seeing'");
			item.value = 100000;
			item.rare = 4;
			item.accessory = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.buffImmune[69] = true;
		}
	}
}