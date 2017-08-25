using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class MagicSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magic Skyblade";
			item.rare = 7;
			item.useSound = 1;
			item.useStyle = 1;
			item.useAnimation = 12;
			item.useTime = 12;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.scale = 1.1f;
			item.toolTip = "'A holy aura comes from this sword'";
			item.width = 38;
			item.height = 38;
			item.damage = 50;
			item.melee = true;
			item.autoReuse = true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			for(int num258 = 0; num258 < 2; num258++)
			{
				int num259 = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 64, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 1f);
				Main.dust[num259].noGravity = true;
				Dust expr_C4C3_cp_0 = Main.dust[num259];
				expr_C4C3_cp_0.velocity.X = expr_C4C3_cp_0.velocity.X * 2f;
				Dust expr_C4E3_cp_0 = Main.dust[num259];
				expr_C4E3_cp_0.velocity.Y = expr_C4E3_cp_0.velocity.Y * 2f;
			}
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if(player.altFunctionUse == 2)
			{
				damage = 0;
				knockBack = 0f;
			}
		}

		public override bool UseItem(Player player)
		{
			int damage = player.GetWeaponDamage(player.inventory[player.selectedItem]);
			if(player.altFunctionUse == 2)
			{
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				float num200 = num78;
				float num201 = num79;
				num200 += (float)Main.rand.Next(-40, 41) * 0.05f;
				num201 += (float)Main.rand.Next(-32, 33) * 0.05f;
				Vector2 vector12 = vector2 + Vector2.Normalize(new Vector2(num200, num201).RotatedBy((double)(-1.57079637f * (float)player.direction), default(Vector2))) * 6f;
				int proj = Projectile.NewProjectile(vector12.X, vector12.Y, num200, num201, 459, (int)(damage*0.3), 0f, player.whoAmI);
				Main.projectile[proj].penetrate = 1;
				if(num78 < 0)
				{
					player.direction = -1;
				}
				else
				{
					player.direction = 1;
				}
			}
			return true;
		}

		public override void UseStyle(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				item.useAnimation = 30;
			}
			else
			{
				item.useAnimation = 12;
			}
		}

		public override bool UseItemFrame(Player player)
		{
			return true;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.position, Microsoft.Xna.Framework.Color.LightGoldenrodYellow.ToVector3());
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.NightsEdge);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.Obsidian, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}