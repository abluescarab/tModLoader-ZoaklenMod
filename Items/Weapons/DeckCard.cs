using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class DeckCard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deck Card");
			Tooltip.SetDefault("'The Ecaflips not even seen you stealing'");
		}

		public override void SetDefaults()
		{
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 2;
			item.maxStack = 999;
			item.consumable = true;
			item.shootSpeed = 10.0f;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 50;
			item.damage = 10;
			item.thrown = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DeckCard");
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
			recipe.AddIngredient(ItemID.Cobweb);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}