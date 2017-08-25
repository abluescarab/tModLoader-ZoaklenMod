using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class StellarCard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stellar Card";
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 3;
			item.maxStack = 999;
			item.consumable = true;
			item.shootSpeed = 15.0f;
			item.useSound = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 5000;
			item.damage = 85;
			item.thrown = true;
			item.autoReuse = true;
			item.toolTip = "'Even more indiscreet'";
			item.shoot = mod.ProjectileType("StellarCard");
			item.crit = 6;
		}

		public override bool ConsumeItem(Player player)
		{
			bool cardBonus = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("CardGlove"))
				{
					cardBonus = true;
					break;
				}
			}
			if(cardBonus && Main.rand.Next(3) == 0)
			{
				return false;
			}
			bool cardBonus2 = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("TeraCardGlove"))
				{
					cardBonus2 = true;
					break;
				}
			}
			if(cardBonus2 && Main.rand.Next(2) == 0)
			{
				return false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DeckCard"), 333);
			recipe.AddIngredient(mod.ItemType("StellarFragment"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}