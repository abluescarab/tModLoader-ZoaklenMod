using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NinjaKnuckles : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetDefaults()
		{
			item.name = "Ninja Knuckles";
			item.width = 24;
			item.height = 24;
			item.value = 100000;
			item.defense = 6;
			item.rare = 8;
			AddTooltip("Increases armor penetration by 5");
			AddTooltip("4% increased damage and critical strike chance");
			AddTooltip2("'Punch them at the super sonic speed'");
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.armorPenetration += 5;
			player.meleeCrit += 4;
			player.magicCrit += 4;
			player.rangedCrit += 4;
			player.thrownCrit += 4;
			player.meleeDamage += 0.04f;
			player.magicDamage += 0.04f;
			player.rangedDamage += 0.04f;
			player.thrownDamage += 0.04f;
			player.minionDamage += 0.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FleshKnuckles);
			recipe.AddIngredient(ItemID.PutridScent);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}