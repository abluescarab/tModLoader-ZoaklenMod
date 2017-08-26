using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class TheHallowsEve : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hallow's Eve");
			Tooltip.SetDefault("'The rude arrowstorm'\n" +
				"33% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.autoReuse = true;
			item.useAnimation = 18;
			item.useTime = 6;
			item.width = 10;
			item.height = 40;
			item.useAmmo = 1;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
			item.damage = 40;
			item.shootSpeed = 12.5f;
			item.noMelee = true;
			item.scale *= 1.2f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.ranged = true;
			item.rare = 7;
			item.knockBack = 1.5f;
		}

		public override bool ConsumeAmmo(Player player)
		{
			if(Main.rand.Next(3) == 0)
			{
				return false;
			}
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			speedX += (float)Main.rand.Next(-4, 5);
			speedY += (float)Main.rand.Next(-4, 5);
			if(type == 1)
			{
				type = mod.ProjectileType("HallowedArrow");
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DaedalusStormbow);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}