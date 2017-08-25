using Terraria;
using Terraria.ModLoader;
using ZoaklenMod.NPCs;

namespace ZoaklenMod.Buffs
{
	public class Virus : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Virus!";
			Main.buffTip[Type] = "The antivirus is killing you";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<PlayerChanges>(mod).virus = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetModInfo<NPCChanges>(mod).virus = true;
		}
	}
}
