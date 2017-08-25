using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class CyberCut : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Cyber Cut";
			projectile.penetrate = -1;
			projectile.aiStyle = 1;
			projectile.width = 8;
			projectile.height = 8;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 200;
			projectile.tileCollide = false;
			projectile.noDropItem = true;
			projectile.melee = true;
			projectile.alpha = 255;
			aiType = 14;
			projectile.extraUpdates = 100;
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
			target.AddBuff(mod.BuffType("Virus"), 600, true);
			int a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(-1.5f, -1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(-1.5f, 1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(1.5f, -1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(1.5f, 1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(0f, 1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(0f, -1.5f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(1.5f, 0f);
			Main.dust[a].color = new Color(0, 255, 255);
			a = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 0.75f);
			Main.dust[a].velocity = new Vector2(-1.5f, 0f);
			Main.dust[a].color = new Color(0, 255, 255);
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
	
		public bool Touching(Player player)
		{
			return (projectile.Distance(player.Center) < 50);
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.alpha = 255;
			int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("Neon"), 0f, 0f, 0, new Color(0, 255, 255), 1f);
			Main.dust[dust].velocity = Vector2.Zero;
			Main.dust[dust].color = new Color(0, 255, 255);
			if(Touching(player))
			{
				projectile.Kill();
			}
		}
	}
}