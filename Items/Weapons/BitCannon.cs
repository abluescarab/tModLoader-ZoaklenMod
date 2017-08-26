using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class BitCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bit Cannon");
			Tooltip.SetDefault("'Let me hurt you a bit'");
		}

		public override void SetDefaults()
		{
			item.crit += 25;
			item.width = 38;
			item.height = 20;
			item.shoot = 10;
			item.useTime = 2;
			item.useAnimation = 8;
			item.useAmmo = 14;
			item.UseSound = SoundID.Item42;
			item.useStyle = 5;
			item.damage = 100;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.value = 200000;
			item.knockBack = 8f;
			item.rare = 10;
			item.ranged = true;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			speedY += (float)Main.rand.Next(-4, 5);
			speedX += (float)Main.rand.Next(-4, 5);
			type = mod.ProjectileType("CyberBit");
			damage = (int)(damage * 0.5f);
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -8);
		}
	}
}