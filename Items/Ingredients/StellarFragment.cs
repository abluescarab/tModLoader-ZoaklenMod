using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoaklenMod.Items.Ingredients
{
	public class StellarFragment : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stellar Fragment";
			item.width = 16;
			item.height = 14;
			item.maxStack = 999;
			AddTooltip("'It is pulsing out'");
			item.value = 100;
			item.rare = 9;
			item.scale = 1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);			
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentStardust);			
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentStardust);			
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale)
		{
			item.scale -= 0.02f;
			if(item.scale <= 0.5f)
			{
				item.scale = 1f;
			}
			scale = Math.Abs(item.scale);
			return true;
		}
		
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			item.scale -= 0.02f;
			if(item.scale <= 0.5f)
			{
				item.scale = 1f;
			}
			scale = Math.Abs(item.scale);
			return true;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			Lighting.AddLight(item.position, Microsoft.Xna.Framework.Color.Gold.ToVector3());
			gravity = 0.5f;
			maxFallSpeed = 0.0f;
		}
	}
}