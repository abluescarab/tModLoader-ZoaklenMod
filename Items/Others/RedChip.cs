using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Others
{
	public class RedChip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Chip");
			Tooltip.SetDefault("Summons a rideable neon bull mount");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 16;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("NeonBull");
		}
	}
}