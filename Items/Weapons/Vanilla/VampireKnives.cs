using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons.Vanilla
{
	public class VampireKnives : ModItem
	{
		int originalType = ItemID.VampireKnives;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thrown " + item.Name);
			Tooltip.SetDefault("Right-click to change damage type");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(originalType);
			item.melee = false;
			item.magic = false;
			item.ranged = false;
			item.thrown = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
			float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
			int num71 = item.shoot;
			float num72 = item.shootSpeed;
			int num146 = 4;
			if(Main.rand.Next(2) == 0)
			{
				num146++;
			}
			if(Main.rand.Next(4) == 0)
			{
				num146++;
			}
			if(Main.rand.Next(8) == 0)
			{
				num146++;
			}
			if(Main.rand.Next(16) == 0)
			{
				num146++;
			}
			for(int num147 = 0; num147 < num146; num147++)
			{
				float num148 = num78;
				float num149 = num79;
				float num150 = 0.2f * (float)num147;
				num148 += (float)Main.rand.Next(-35, 36) * num150;
				num149 += (float)Main.rand.Next(-35, 36) * num150;
				num80 = (float)Math.Sqrt((double)(num148 * num148 + num149 * num149));
				num80 = num72 / num80;
				num148 *= num80;
				num149 *= num80;
				float x4 = vector2.X;
				float y4 = vector2.Y;
				Projectile.NewProjectile(x4, y4, num148, num149, num71, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, originalType, 1, false, 0, false, false);
			Main.item[num].Prefix((int)item.prefix);
			Main.item[num].newAndShiny = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ThrowingMastery"));
			recipe.AddIngredient(originalType);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}