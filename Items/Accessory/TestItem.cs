using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class TestItem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Test Item";
			item.width = 24;
			item.height = 24;
			AddTooltip("Currently godmoding");
			item.value = 420;
			item.rare = -11;
			item.accessory = true;
			item.defense = 10000;
			item.lifeRegen = 1000;
		}
	}
}