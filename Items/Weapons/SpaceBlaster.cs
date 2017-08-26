using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class SpaceBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Blaster");
			Tooltip.SetDefault("'Headshots the Brain of Cthulhu'");
		}

		public override void SetDefaults()
		{
			item.crit += 25;
			item.width = 70;
			item.height = 26;
			item.shoot = 10;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useAmmo = 14;
			item.UseSound = SoundID.Item40;
			item.useStyle = 5;
			item.damage = 185;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.value = 200000;
			item.knockBack = 8f;
			item.rare = 10;
			item.ranged = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
			float num117 = 0.314159274f;
			int num118 = 3;
			Vector2 vector7 = new Vector2(num78, num79);
			vector7.Normalize();
			vector7 *= 40f;
			bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector7, 0, 0);
			for(int num119 = 0; num119 < num118; num119++)
			{
				float num120 = (float)num119 - ((float)num118 - 1f) / 2f;
				Vector2 value9 = vector7.RotatedBy((double)(num117 * num120), default(Vector2));
				if(!flag11)
				{
					value9 -= vector7;
				}
				int num121 = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, num78, num79, type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[num121].noDropItem = true;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.IllegalGunParts, 5);
			recipe.AddIngredient(mod.ItemType("MoonFragment"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}