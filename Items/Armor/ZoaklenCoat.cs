using System.Collections.Generic;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	public class ZoaklenCoat : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Zoaklen's Coat";
			AddTooltip("'Made in Brazil'");
			item.width = 34;
			item.height = 26;
			item.vanity = true;
			item.value = 60606;
			item.rare = 7;
		}
	}
}