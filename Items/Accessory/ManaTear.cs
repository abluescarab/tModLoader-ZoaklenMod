using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class ManaTear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Tear");
			Tooltip.SetDefault("Increases maximum mana by 60\n" +
				"Increases mana regeneration rate\n" +
				"10% reduced mana usage\n" +
				"Automatically uses mana potion when needed\n" +
				"15% increased magic damage\n" +
				"Increases pickup range for mana stars\n" +
				"Restores mana when damaged\n" +
				"Permanent magic buffs\n" +
				"'You secretly stealed the Dryad's tear'");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 100000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 60;
			player.manaRegenDelayBonus++;
			player.manaRegenBonus += 25;
			player.manaCost -= 0.1f;
			player.manaFlower = true;
			player.magicDamage += 0.15f;
			player.manaMagnet = true;
			player.magicCuffs = true;
			player.AddBuff(BuffID.ManaRegeneration, 2, true);
			player.AddBuff(BuffID.MagicPower, 2, true);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.MagicCuffs);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.MagicPowerPotion, 30);
			recipe.AddIngredient(ItemID.ManaRegenerationPotion, 30);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}