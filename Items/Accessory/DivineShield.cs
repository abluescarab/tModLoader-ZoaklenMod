using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class DivineShield : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Shield);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Divine Shield";
			item.width = 24;
			item.height = 24;
			AddTooltip("Absorbs 25% of damage done to players on your team");
			AddTooltip("Only active above 25% life");
			AddTooltip("Grants immunity to knockback and fire blocks");
			AddTooltip("Grants immunity to most debuffs");
			AddTooltip("Puts a shell around the owner when below 50% life that reduces damage");
			AddTooltip2("'Also grants immunity to myopia'");
			item.value = 100000;
			item.rare = 9;
			item.defense = 10;
			item.accessory = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.buffImmune[46] = true;
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
		}
				
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(ItemID.PaladinsShield);
			recipe.AddIngredient(ItemID.FrozenTurtleShell);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}