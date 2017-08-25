using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class TerrariaBronzePlate : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 4;
			item.useAnimation = 45;
			item.useTime = 45;
			item.rare = 3;
			item.name = "Terraria Bronze Plate";
			item.width = 18;
			item.height = 28;
			item.autoReuse = true;
			AddTooltip("'Thanks for downloading ZoaklenMod'");
			item.value = 420;
		}
		
		public override bool UseItem(Player player)
		{
			if(player.itemTime == 0 && player.itemAnimation > 0)
			{
				for(int i = 0;i < 3;i++)
				{
					Vector2 pos = new Vector2(player.Center.X + Main.rand.Next(-4, 5), player.Center.Y + Main.rand.Next(-16, -8));
					int dust = Dust.NewDust(pos, 6, 6, Main.rand.Next(59, 66), 0f, 0f, 6, default(Color), 2f);
					Main.dust[dust].velocity.X = (pos.X-player.Center.X)/Main.rand.Next(-16, 17);
					Main.dust[dust].noGravity = false;
					Main.dust[dust].velocity.Y = (pos.Y-player.Center.Y)/4;
				}
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 30);
			recipe.AddIngredient(ItemID.TinBar, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}