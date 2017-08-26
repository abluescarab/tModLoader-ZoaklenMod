using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class IchorSack : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Sack");
			Tooltip.SetDefault("Grants immunity to Ichor debuff\n" +
				"Inflicts Ichor debuff for 7 seconds to enemies who damages you\n" +
				"'Its hole spits on you when you are not seeing'");
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
			player.buffImmune[69] = true;
		}
	}
}