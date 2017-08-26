using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class PracticalCube : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Practical Cube");
			Description.SetDefault("'Still evil, but it is cute, so you pet it'");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<PlayerChanges>(mod).practicalCube = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("PracticalCube")] <= 0;
			if(petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PracticalCube"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}