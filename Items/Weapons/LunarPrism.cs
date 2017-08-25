using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class LunarPrism : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Lunar Prism";
			item.useStyle = 5;
			item.useAnimation = 10;
			item.useTime = 10;
			item.reuseDelay = 5;
			item.shootSpeed = 30f;
			item.knockBack = 0f;
			item.width = 16;
			item.height = 16;
			item.damage = 150;
			item.useSound = 13;
			item.shoot = 633;
			item.mana = 15;
			item.rare = 10;
			item.value = Item.sellPrice(10, 0, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.magic = true;
			item.channel = true;
		}
	}
}