using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class VanillaCustomizations : GlobalProjectile
	{
		public override Color? GetAlpha(Projectile projectile, Color lightColor)
		{
			int slot = SuperBees(Main.player[projectile.owner]);
			if(slot >= 0 && BeeProj(projectile))
			{
				return Color.Red;
			}
			return null;
		}

		public override bool PreAI(Projectile projectile)
		{
			Player player = Main.player[Main.myPlayer];
			if(player.inventory[player.selectedItem].Name.Contains("Thrown") && !projectile.minion)
			{
				projectile.thrown = true;
				projectile.magic = false;
				projectile.melee = false;
				projectile.ranged = false;
			}
			return true;
		}

		private int SuperBees(Player player)
		{
			int have = -1;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("BeeEnrager"))
				{
					have = l;
					break;
				}
			}
			return have;
		}

		private bool BeeProj(Projectile projectile)
		{
			if(!projectile.active)
			{
				return false;
			}
			string t = projectile.Name;
			if(!t.Contains("Bee") && !t.Contains("Wasp") && !t.Contains("Hornet"))
			{
				return false;
			}
			return true;
		}

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if((projectile.type >= 184 && projectile.type <= 188) || projectile.type == 654)
				return;

			Player player = Main.player[projectile.owner];
			if(SuperBees(player) >= 0 && BeeProj(projectile))
			{
				damage = (int)((damage / 2f) * 2f);
			}
			if(crit && player.armor[0].type == mod.ItemType("HiddenShooterHood") && player.armor[1].type == mod.ItemType("HiddenShooterCoat") && player.armor[2].type == mod.ItemType("HiddenShooterPants"))
			{
				damage = (int)(damage * 1.5f);
			}
			if(target.FindBuffIndex(mod.BuffType("Virus")) != -1)
			{
				damage = (int)(damage * 1.2f);
			}
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(crit && modPlayer.activeMark == 2 && modPlayer.markActivated)
			{
				damage = (int)(damage * 2f);
			}
			if(damage > 0 && projectile.thrown && StellarNinja(player))
			{
				if(Main.rand.Next(20) == 0)
				{
					modPlayer.stockedTeleports++;
				}
			}
			bool cardBonus2 = false;
			for(int l = 3; l < 8 + player.extraAccessorySlots; l++)
			{
				if(player.armor[l].type == mod.ItemType("TeraCardGlove"))
				{
					cardBonus2 = true;
					break;
				}
			}
			if(cardBonus2 && projectile.Name.Contains("Card"))
			{
				if(Main.rand.Next(3) == 0)
				{
					crit = true;
				}
			}
		}

		private bool StellarNinja(Player player)
		{
			bool have = false;
			if(player.armor[0].type == mod.ItemType("StellarNinjaHelmet") && player.armor[1].type == mod.ItemType("StellarNinjaBreastplate") && player.armor[2].type == mod.ItemType("StellarNinjaLeggings"))
			{
				have = true;
			}
			return have;
		}
	}
}