using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class CursedEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Eye");
			Tooltip.SetDefault("Grants immunity to Cursed Inferno debuff\n" +
				"Inflicts Cursed Inferno debuff for 7 seconds to enemies who damages you\n" +
				"'It spits on you everytime you blink'");
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
			player.buffImmune[39] = true;
		}
	}
}