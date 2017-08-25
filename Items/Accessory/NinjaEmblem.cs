using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Accessory
{
	public class NinjaEmblem : ModItem
	{
		/*public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Back);
			return true;
		}*/

		public override void SetDefaults()
		{
			item.name = "Ninja Emblem";
			item.width = 24;
			item.height = 24;
			AddTooltip("15% increased throwing damage");
			item.value = 100000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.15f;
		}
	}
}