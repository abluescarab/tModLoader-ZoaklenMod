using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class FrozenShinyStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Shiny Stone");
			Tooltip.SetDefault("Greatly increases health regen when not moving\n" +
				"Puts a shell around the owner when below 50% life that reduces damage\n" +
				"Provides life regeneration and reduces the cooldown of healing potions\n" +
				"Summons spores over time that will damage enemies");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.damage = 40;
			item.summon = true;
			item.value = 100000;
			item.rare = 8;
			item.expert = true;
			item.accessory = true;
			item.lifeRegen = 1;
		}

		public override void UpdateEquip(Player player)
		{
			player.shinyStone = true;
			player.pStone = true;
			player.endurance += 0.1f;

			int slot = -1;
			for(int i = 3; i < 8 + player.extraAccessorySlots; i++)
			{
				if(player.armor[i].type == item.type)
				{
					slot = i;
					break;
				}
			}
			if(!player.hideVisual[slot])
			{
				player.sporeSac = true;
				SporeSac(player);
			}
		}

		private int CalculateDamage(Player player)
		{
			float damage = (float)item.damage;
			damage *= player.minionDamage;
			return (int)damage;
		}

		private void SporeSac(Player player)
		{
			int damage = CalculateDamage(player);
			float knockBack = 1.5f;
			if(Main.rand.Next(15) == 0)
			{
				int num = 0;
				for(int i = 0; i < 1000; i++)
				{
					if(Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && (Main.projectile[i].type == 567 || Main.projectile[i].type == 568))
					{
						num++;
					}
				}
				if(Main.rand.Next(15) >= num && num < 10)
				{
					int num2 = 50;
					int num3 = 24;
					int num4 = 90;
					for(int j = 0; j < num2; j++)
					{
						int num5 = Main.rand.Next(200 - j * 2, 400 + j * 2);
						Vector2 center = player.Center;
						center.X += (float)Main.rand.Next(-num5, num5 + 1);
						center.Y += (float)Main.rand.Next(-num5, num5 + 1);
						if(!Collision.SolidCollision(center, num3, num3) && !Collision.WetCollision(center, num3, num3))
						{
							center.X += (float)(num3 / 2);
							center.Y += (float)(num3 / 2);
							if(Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
							{
								int num6 = (int)center.X / 16;
								int num7 = (int)center.Y / 16;
								bool flag = false;
								if(Main.rand.Next(3) == 0 && Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
								{
									flag = true;
								}
								else
								{
									center.X -= (float)(num4 / 2);
									center.Y -= (float)(num4 / 2);
									if(Collision.SolidCollision(center, num4, num4))
									{
										center.X += (float)(num4 / 2);
										center.Y += (float)(num4 / 2);
										flag = true;
									}
								}
								if(flag)
								{
									for(int k = 0; k < 1000; k++)
									{
										if(Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].aiStyle == 105 && (center - Main.projectile[k].Center).Length() < 48f)
										{
											flag = false;
											break;
										}
									}
									if(flag && Main.myPlayer == player.whoAmI)
									{
										Projectile.NewProjectile(center.X, center.Y, 0f, 0f, 567 + Main.rand.Next(2), damage, knockBack, player.whoAmI, 0f, 0f);
										return;
									}
								}
							}
						}
					}
				}
			}
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.FrozenTurtleShell);
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.SporeSac);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}