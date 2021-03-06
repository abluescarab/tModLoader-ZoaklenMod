using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	//imported from my tAPI mod because I'm lazy
	public class CreeperStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creeper Staff");
			Tooltip.SetDefault("Summons a creeper to fight for you.");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("Creeper");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("Creeper");
			item.buffTime = 3600;
		}
	}
}