using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class PhoenixBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.rare = 6;
			item.useSound = 1;
			item.useStyle = 1;
			item.useAnimation = 16;
			item.useTime = 16;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.name = "Phoenix Blade";
			item.scale = 1.05f;
			item.width = 50;
			item.height = 58;
			item.toolTip = "'Imagine all the people reviving'";
			item.damage = 60;
			item.melee = true;
			item.autoReuse = true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			for(int num258 = 0; num258 < 2; num258++)
			{
				int num259 = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 6, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[num259].noGravity = true;
				Dust expr_C4C3_cp_0 = Main.dust[num259];
				expr_C4C3_cp_0.velocity.X = expr_C4C3_cp_0.velocity.X * 2f;
				Dust expr_C4E3_cp_0 = Main.dust[num259];
				expr_C4E3_cp_0.velocity.Y = expr_C4E3_cp_0.velocity.Y * 2f;
			}
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300, true);
			int cursedId = target.HasBuff(BuffID.CursedInferno);
			if(cursedId >= 0)
			{
				damage = (int)(damage * 2f);
				for(int i = 0; i < 5; i++)
				{
					if(target.buffType[i] == BuffID.CursedInferno)
					{
						target.buffTime[i] -= 30;
						break;
					}
				}
			}
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
				for(int i = 0; i < 3; i++)
				{
					float num200 = num78;
					float num201 = num79;
					num200 += (float)Main.rand.Next(-40, 41) * 0.05f;
					num201 += (float)Main.rand.Next(-512, 513) * 0.05f;
					Vector2 vector12 = vector2 + Vector2.Normalize(new Vector2(num200, num201).RotatedBy((double)(-1.57079637f * (float)player.direction), default(Vector2))) * 6f;
					int proj = Projectile.NewProjectile(vector12.X, vector12.Y, num200, num201, 376, (int)(damage*(1.25/3.0)), 0f, player.whoAmI);
					Main.projectile[proj].penetrate = 1;
				}
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
				item.useStyle = 2;
			}
			else
			{
				item.useStyle = 1;
			}
		}

		public override bool UseItemFrame(Player player)
		{
			return true;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.position, Microsoft.Xna.Framework.Color.Orange.ToVector3());
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddIngredient(mod.ItemType("FireEssence"), 15);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}