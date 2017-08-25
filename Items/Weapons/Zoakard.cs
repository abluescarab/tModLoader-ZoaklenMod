using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class Zoakard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Zoakard";
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 10;
			item.maxStack = 1;
			item.consumable = false;
			item.shootSpeed = 15.0f;
			item.useSound = 1;
			item.useAnimation = 12;
			item.useTime = 12;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 5000;
			item.damage = 4000;
			item.thrown = true;
			item.autoReuse = true;
			item.toolTip = "'Whoa!'";
			item.toolTip2 = "> Cheat item";
			item.shoot = mod.ProjectileType("Zoakard");
			item.crit = 33;
		}
	}
}