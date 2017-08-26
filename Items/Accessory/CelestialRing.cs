using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class CelestialRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Ring");
			Tooltip.SetDefault("Increases pickup range for mana stars\n" +
				"Restores mana when damaged\n" +
				"15% increased magic damage\n" +
				"Minor increase to several stats\n" +
				"'It have a moon engraved'");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 100000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.manaMagnet = true;
			player.magicCuffs = true;
			player.magicDamage += 0.15f;
			player.lifeRegen += 2;
			player.statDefense += 4;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.meleeCrit += 2;
			player.rangedDamage += 0.1f;
			player.rangedCrit += 2;
			player.magicDamage += 0.1f;
			player.magicCrit += 2;
			player.pickSpeed -= 0.15f;
			player.minionDamage += 0.1f;
			player.minionKB += 0.5f;
			player.thrownDamage += 0.1f;
			player.thrownCrit += 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialCuffs);
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.CelestialStone);
			recipe.AddIngredient(ItemID.DiamondRing);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.DiamondRing);
			recipe.AddRecipe();

		}
	}
}