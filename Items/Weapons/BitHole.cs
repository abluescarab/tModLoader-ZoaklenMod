using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class BitHole : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bit Hole");
			Tooltip.SetDefault("'Even the light can't escape'");
		}

		public override void SetDefaults()
		{
			item.crit += 4;
			item.width = 52;
			item.height = 34;
			item.shoot = mod.ProjectileType("BitHoleMissile");
			item.useTime = 120;
			item.useAnimation = 120;
			item.useAmmo = 771;
			item.UseSound = SoundID.Item42;
			item.useStyle = 5;
			item.damage = 300;
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.value = 200000;
			item.knockBack = 8f;
			item.rare = 10;
			item.ranged = true;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("BitHoleMissile");
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, -8);
		}
	}
}