using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class ExplosiveCard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Explosive Card";
			item.useStyle = 3;
			item.width = 13;
			item.height = 20;
			item.rare = 4;
			item.maxStack = 999;
			item.consumable = true;
			item.shootSpeed = 10.0f;
			item.useSound = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 200;
			item.damage = 34;
			item.thrown = true;
			item.autoReuse = true;
			item.toolTip = "'Suspicious looking card'";
			item.shoot = mod.ProjectileType("ExplosiveCard");
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

		public override DrawAnimation GetAnimation()
		{
			return new Terraria.DataStructures.DrawAnimationVertical(30, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DeckCard"), 25);
			recipe.AddIngredient(ItemID.ExplosivePowder);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}