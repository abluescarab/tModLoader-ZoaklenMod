using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ZoaklenCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zoaklen's Coat");
			Tooltip.SetDefault("'Made in Brazil'");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 26;
			item.vanity = true;
			item.value = 60606;
			item.rare = 7;
		}
	}
}