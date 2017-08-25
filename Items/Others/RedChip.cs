using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class RedChip : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Red Chip";
			item.width = 24;
			item.height = 16;
			item.toolTip = "Summons a rideable neon bull mount";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 2;
			item.useSound = 79;
			item.noMelee = true;
			item.mountType = mod.MountType("NeonBull");
		}
	}
}