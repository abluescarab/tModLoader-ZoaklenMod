using Terraria.ModLoader;

namespace ZoaklenMod.Items.Ingredients
{
	public class PaladinBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Bar");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 14;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 9;
		}
	}
}