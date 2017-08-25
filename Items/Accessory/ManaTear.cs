using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class ManaTear : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Mana Tear";
			item.width = 24;
			item.height = 24;
			AddTooltip("Increases maximum mana by 60");
			AddTooltip("Increases mana regeneration rate");
			AddTooltip("10% reduced mana usage");
			AddTooltip("Automatically uses mana potion when needed");
			AddTooltip("15% increased magic damage");
			AddTooltip("Increases pickup range for mana stars");
			AddTooltip("Restores mana when damaged");
			AddTooltip("Permanent magic buffs");
			AddTooltip("'You secretly stealed the Dryad's tear'");
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