using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class GhostShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Ghost Shuriken";
			projectile.penetrate = 1;
			projectile.light = 8;
			projectile.aiStyle = 5;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 60;
			projectile.alpha = 128;
			projectile.tileCollide = false;
			aiType = ProjectileID.Shuriken;
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
		}
		
		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if(item.melee)
			{
				crit += player.meleeCrit;
			}
			else if(item.magic)
			{
				crit += player.magicCrit;
			}
			else if(item.ranged)
			{
				crit += player.rangedCrit;
			}
			else if(item.thrown)
			{
				crit += player.thrownCrit;
			}
			return crit;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}