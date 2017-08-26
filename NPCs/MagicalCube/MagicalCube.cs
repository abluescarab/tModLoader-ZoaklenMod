using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.NPCs.MagicalCube
{
	//ported from my tAPI mod because I'm lazy
	public class MagicalCube : ModNPC
	{
		private static int hellLayer
		{
			get
			{
				return Main.maxTilesY - 200;
			}
		}

		private const int sphereRadius = 300;

		private int subCool
		{
			get
			{
				return (int)npc.ai[0];
			}
			set
			{
				npc.ai[0] = (float)value;
			}
		}

		private float coolDown
		{
			get
			{
				return npc.ai[1];
			}
			set
			{
				npc.ai[1] = value;
			}
		}

		private float rotationSpeed
		{
			get
			{
				return npc.ai[2];
			}
			set
			{
				npc.ai[2] = value;
			}
		}

		private float currentMove
		{
			get
			{
				return npc.ai[3];
			}
			set
			{
				npc.ai[3] = value;
			}
		}

		private int moveTime = 300;
		private int moveTimer = 60;
		private bool currentlyImmune = false;
		private int lastStage = 0;
		internal int laserTimer = 0;
		internal int laser1 = -1;
		internal int laser2 = -1;
		private Vector2 targetPos;
		private int stage;
		private int[] receivedDamage = new int[5];

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magical Cube");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 200000;
			npc.damage = 125;
			npc.defense = 55;
			npc.knockBackResist = 0f;
			npc.width = 208;
			npc.height = 208;
			Main.npcFrameCount[npc.type] = 1;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = false;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SmartDrag");
			bossBag = mod.ItemType("MagicalCubeTreasureBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			bossLifeScale = 1.5f;
			npc.lifeMax = 300000;
			npc.damage = 175;
		}

		public override void AI()
		{
			if(Main.netMode != 1 && npc.localAI[0] == 0f)
			{
				npc.netUpdate = true;
				npc.localAI[0] = 1f;
			}
			coolDown--;
			Player player = Main.player[npc.target];

			if(coolDown <= 0)
			{
				if(!currentlyImmune)
				{
					currentlyImmune = true;
					currentMove = 0;
					coolDown = 120;
					if(ClearNebula(player))
					{
						int a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, 2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, 2f);

						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(0f, 2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(0f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, 0f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, 0f);
						player.statMana = player.statManaMax2 / 2;
					}
				}
				else
				{
					currentlyImmune = false;
					getNextMove();
					subCool = 60;
				}
			}
			npc.rotation += rotationSpeed;
			if(!player.active || player.dead || player.position.Y < hellLayer)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if(!player.active || player.dead || player.position.Y < hellLayer)
				{
					npc.velocity = new Vector2(0f, 10f);
					if(npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}

			player.AddBuff(BuffID.MoonLeech, 2, true);

			if((player.statDefense > 200 || player.lifeRegen > 200) && player.name != "Tester")
			{
				Main.NewText("Cheating will not help.", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was judged"), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
			}

			if(currentlyImmune)
			{
				if(rotationSpeed > 0f)
				{
					rotationSpeed -= 0.005f;
				}
				npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 100, (player.Center.Y - npc.Center.Y) / 100);
			}
			else
			{
				if(rotationSpeed < 0.1f)
				{
					rotationSpeed += 0.01f;
				}
			}

			UpdateStage();

			if(stage == 1 && lastStage == 0)
			{
				Main.NewText("The real battle begins.", 255, 32, 32);
				music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Commando");
			}
			if(stage == 2 && lastStage != 2)
			{
				Main.NewText("You feel the cube's strenght growing.", 255, 0, 0);
				npc.damage += 35;
				npc.defense += 20;
			}

			// -------------------------------------------------------------------------- ATTACKS
			subCool--;
			if(currentMove == 1)
			{
				rotationSpeed = 0.2f;
				if(subCool <= 0 && stage >= 2)
				{
					npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 30, (player.Center.Y - npc.Center.Y) / 30);
				}
			}
			if(currentMove == 2)
			{
				npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 200, (player.Center.Y - npc.Center.Y) / 200);
				BitStorm(player.Center);
			}
			if(currentMove == 3)
			{
				npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 150, (player.Center.Y - npc.Center.Y) / 150);
				BitBeam(player.Center);
			}
			if(currentMove == 4)
			{
				npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 300, (player.Center.Y - npc.Center.Y) / 300);
				rotationSpeed = 0.01f;
				if(subCool <= 0)
				{
					BitExplosion(player.Center);
				}
			}
			if(currentMove == 5)
			{
				npc.velocity = new Vector2((player.Center.X - npc.Center.X) / 250, (player.Center.Y - npc.Center.Y) / 250);
				rotationSpeed = 0.02f;
				if(subCool == 25)
				{
					targetPos = player.Center;
					for(int i = 0; i < 20; i++)
					{
						int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
						int x = 0;
						int y = 0;
						while(x == 0 && y == 0)
						{
							x = Main.rand.Next(-6, 6);
							y = Main.rand.Next(-6, 6);
						}
						Main.dust[dust].velocity = new Vector2(x, y);
						Main.dust[dust].color = new Color(0, 255, 255);
					}
				}
				if(subCool <= 0)
				{
					Vector2 sum = Vector2.Zero;
					sum.X = Main.rand.Next(-120, 121);
					BitLightning(targetPos + sum);
					subCool = 30;
				}
			}
			if(subCool <= 0)
			{
				subCool = 60;
			}
			// -------------------------------------------------------------------------- ATTACKS

			if(Main.netMode != 1)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				npc.netUpdate = true;
			}
			lastStage = stage;
		}

		private bool ClearNebula(Player player)
		{
			bool cleared = false;
			for(int i = 0; i < 22; i++)
			{
				int t = player.buffType[i];
				if(t == BuffID.NebulaUpLife1 || t == BuffID.NebulaUpLife2 || t == BuffID.NebulaUpLife3 || t == BuffID.NebulaUpDmg1 || t == BuffID.NebulaUpDmg2 || t == BuffID.NebulaUpDmg3)
				{
					player.DelBuff(i);
					cleared = true;
				}
			}
			return cleared;
		}

		private void BitLightning(Vector2 pos)
		{
			int fallSpeed = -10;
			int damage = (int)(npc.damage);
			if(Main.expertMode)
			{
				damage = (int)(damage * 1.5f);
			}
			for(int i = 0; i < 3; i++)
			{
				int a2 = Projectile.NewProjectile(pos.X + Main.rand.Next(-12, 13), 50, 0, 10, mod.ProjectileType("CyberInsta"), damage, 0, 0);
			}
		}

		private void BitStorm(Vector2 pos)
		{
			for(int i = -5; i <= 5; i++)
			{
				Dust.NewDust(new Vector2(pos.X - (i * 15f), pos.Y - 300f + Main.rand.Next(-16, 17)), 12, 16, mod.DustType("Binary" + Main.rand.Next(0, 2)), 0f, -0.5f, 0, default(Color), 1f);
			}
			int fallSpeed = 10;
			if(Main.expertMode)
			{
				fallSpeed = 15;
			}
			int a2 = Projectile.NewProjectile(pos.X - (Main.rand.Next(-5, 6)*15f), pos.Y-300f+Main.rand.Next(-16,17), 0, fallSpeed, mod.ProjectileType("Cyber"), (int)(npc.damage * 0.6f), 0, 0);
			Main.projectile[a2].timeLeft = 45;
		}

		private void BitBeam(Vector2 pos)
		{
			Vector2 vector2 = npc.Center;
			float num200 = (float)pos.X - vector2.X;
			float num201 = (float)pos.Y - vector2.Y;
			num200 += (float)Main.rand.Next(-40, 41) * 0.4f;
			num201 += (float)Main.rand.Next(-32, 33) * 0.4f;
			Vector2 vector12 = vector2 + Vector2.Normalize(new Vector2(num200, num201).RotatedBy((double)(-1.57079637f * (float)npc.direction), default(Vector2))) * 6f;
			int a2 = Projectile.NewProjectile(vector12.X, vector12.Y, num200, num201, mod.ProjectileType("Cyber"), (int)(npc.damage * 0.7f), 0, 0);
			Main.projectile[a2].tileCollide = true;
			Main.projectile[a2].timeLeft = 180;
		}

		private void BitExplosion(Vector2 pos)
		{
			int range = 16, count = 50;
			if(Main.expertMode)
			{
				range = 24;
				count = 70;
			}
			for(int i = 0; i < count; i++)
			{
				int a2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-range, range+1), Main.rand.Next(-range, range+1), mod.ProjectileType("Cyber"), (int)(npc.damage * 0.7f), 0, 0);
				Main.projectile[a2].tileCollide = true;
				Main.projectile[a2].timeLeft = 185;
			}
		}

		private Vector2 getAttackPosition()
		{
			Player player = Main.player[npc.target];
			return new Vector2(player.Center.X, player.Center.Y);
		}

		private void getNextMove()
		{
			targetPos = Main.player[npc.target].Center;
			int nextAtk = Main.rand.Next(0, 101);
			if(nextAtk <= 30 || stage == 0)
			{
				currentMove = 1;
				coolDown = 120;
				int divisor = 45;
				if(stage >= 1)
				{
					divisor = 30;
					coolDown = 90;
				}
				npc.velocity = new Vector2((targetPos.X - npc.Center.X) / divisor, (targetPos.Y - npc.Center.Y) / divisor);
			}
			else if(nextAtk > 30 && nextAtk <= 50)
			{
				currentMove = 2;
				coolDown = 240;
			}
			else if(nextAtk > 50 && nextAtk <= 70)
			{
				currentMove = 3;
				coolDown = 120;
			}
			else if(nextAtk > 70)
			{
				if(stage == 2 && nextAtk > 85)
				{
					currentMove = 5;
					coolDown = 185;
				}
				else
				{
					currentMove = 4;
					coolDown = 180;
				}
			}
		}

		public override bool CheckDead()
		{
			if(!npc.lavaImmune)
			{
				npc.lavaImmune = true;
				npc.life = npc.lifeMax;
				return false;
			}
			return true;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write((short)moveTime);
			writer.Write((short)moveTimer);
			if(Main.expertMode)
			{
				//
			}
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			moveTime = reader.ReadInt16();
			moveTimer = reader.ReadInt16();
			if(Main.expertMode)
			{
				//
			}
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = 0;
		}

		private void UpdateStage()
		{
			float hp = (float)(npc.life);
			float hpM = (float)(npc.lifeMax);
			float hpP = hp/hpM;
			if(!npc.lavaImmune)
			{
				stage = 0;
			}
			else if(npc.lavaImmune && hpP > 0.5f)
			{
				stage = 1;
			}
			else
			{
				stage = 2;
			}
		}

		public override Color? GetAlpha(Color drawColor)
		{
			if(currentlyImmune)
			{
				return Color.Red;
			}
			if(stage == 2)
			{
				return Color.Orange;
			}
			if(stage == 1)
			{
				return Color.White;
			}
			return null;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for(int k = 0; k < damage / npc.lifeMax * 100.0; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Neon"), hitDirection, -1f, 0, default(Color), 1f);
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if(Main.expertMode || Main.rand.Next(2) == 0)
			{
				player.AddBuff(mod.BuffType("Virus"), 180, true);
			}
		}

		public override void NPCLoot()
		{
			int hD = GetHighestDamage();
			for(int i = 0; i < 256; i++)
			{
				Player player = Main.player[i];
				if(player.active)
				{
					PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
					modPlayer.damageType = hD;
				}
			}
			if(!Main.expertMode)
			{
				int wep = -1;
				switch(hD)
				{
					case 4:
						wep = mod.ItemType("CyberCardA");
						break;
					case 0:
						wep = mod.ItemType("BlinkBlade");
						break;
					case 3:
						wep = mod.ItemType("CyberStaff");
						break;
					case 1:
						wep = mod.ItemType("TechSmite");
						break;
					case 2:
						wep = mod.ItemType("BitCannon");
						break;
				}
				DropLoot((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, wep, 1, false, -1, false);
			}
			else
			{
				int index = DropLoot((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("MagicalCubeTreasureBag"), 1, false, -1, false);
			}
		}

		public int GetHighestDamage()
		{
			int max = receivedDamage[0];
			int bestType = 0;
			for(int i = 1; i < 5; i++)
			{
				if(receivedDamage[i] > max)
				{
					max = receivedDamage[i];
					bestType = i;
				}
			}
			return bestType;
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + npc.TypeName;
			potionType = ItemID.SuperHealingPotion;
		}

		private int DropLoot(int x, int y, int w, int h, int itemId, int stack = 1, bool broadcast = false, int prefix = 0, bool nodelay = false)
		{
			return Item.NewItem(x, y, w, h, itemId, stack, broadcast, prefix, nodelay);
		}

		public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			float mult = 1f;
			if(item.melee)
			{
				receivedDamage[0] += damage;
				mult = 0.75f;
			}
			else if(item.magic)
			{
				receivedDamage[1] += damage;
				mult = 0.6f;
			}
			else if(item.ranged)
			{
				receivedDamage[2] += damage;
				mult = 0.75f;
			}
			else if(item.summon)
			{
				receivedDamage[3] += damage;
				mult = 0.75f;
			}
			else if(item.thrown)
			{
				receivedDamage[4] += damage;
				mult = 1.2f;
			}
			if(damage >= 5000)
			{
				Main.NewText("Cheating will not help.", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was judged"), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
				mult = 0f;
			}
			damage = (int)(damage * mult);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			float mult = 1f;
			if(projectile.melee)
			{
				receivedDamage[0] += damage;
				mult = 0.75f;
			}
			else if(projectile.magic)
			{
				receivedDamage[1] += damage;
				mult = 0.6f;
			}
			else if(projectile.ranged)
			{
				receivedDamage[2] += damage;
				mult = 0.75f;
			}
			else if(projectile.minion)
			{
				receivedDamage[3] += damage;
				mult = 0.75f;
			}
			else if(projectile.thrown)
			{
				receivedDamage[4] += damage;
				mult = 1.2f;
			}
			if(damage >= 5000)
			{
				Main.NewText("Cheating will not help.", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was judged"), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
				mult = 0f;
			}
			damage = (int)(damage * mult);
		}

		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if(currentlyImmune)
			{
				damage *= 0.1f;
				Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, npc.HitSound.SoundId);
				return false;
			}
			if(stage == 0)
			{
				damage *= 4f;
			}
			return true;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 0f;
			return false;
		}
	}
}