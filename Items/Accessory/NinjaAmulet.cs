using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NinjaAmulet : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetDefaults()
		{
			item.name = "Ninja Amulet";
			item.width = 24;
			item.height = 24;
			AddTooltip("Allows player to dash into an enemy");
			AddTooltip("Double tap into a direction");
			AddTooltip("May confuse nearby enemies after being struck");
			AddTooltip("Increases length of invincibility after taking damage");
			AddTooltip2("'You see your future in its pendant'");
			item.value = 100000;
			item.rare = 6;
			item.knockBack = 9f;
			item.defense = 3;
			item.melee = true;
			item.damage = 25;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.dash = 2;
			player.longInvince = true;
			player.brainOfConfusion = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EoCShield);
			recipe.AddIngredient(ItemID.BrainOfConfusion);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}