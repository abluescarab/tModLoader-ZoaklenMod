using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class CursedEye : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cursed Eye";
			item.width = 24;
			item.height = 24;
			AddTooltip("Grants immunity to Cursed Inferno debuff");
			AddTooltip("Inflicts Cursed Inferno debuff for 7 seconds to enemies who damages you");
			AddTooltip2("'It spits on you everytime you blink'");
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