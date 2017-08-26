using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class Zoakard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zoakard");
			Tooltip.SetDefault("'Whoa!'\n" +
				"> Cheat item");
		}

		public override void SetDefaults()
		{
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 10;
			item.maxStack = 1;
			item.consumable = false;
			item.shootSpeed = 15.0f;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 12;
			item.useTime = 12;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 5000;
			item.damage = 4000;
			item.thrown = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Zoakard");
			item.crit = 33;
		}
	}
}