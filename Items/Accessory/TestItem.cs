using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class TestItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Test Item");
			Tooltip.SetDefault("Currently godmoding");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 420;
			item.rare = -11;
			item.accessory = true;
			item.defense = 10000;
			item.lifeRegen = 1000;
		}
	}
}