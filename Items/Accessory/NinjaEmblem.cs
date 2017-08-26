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

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja Emblem");
			Tooltip.SetDefault("15% increased throwing damage");
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
			player.thrownDamage += 0.15f;
		}
	}
}