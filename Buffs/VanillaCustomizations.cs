using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class VanillaCustomizations : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if(NPC.AnyNPCs(mod.NPCType("MagicalCube")) && Main.buffName[type].Contains("Mount"))
			{
				player.mount.Reset();
				player.ClearBuff(type);
				buffIndex--;
				int a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(-2f, -2f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(-2f, 2f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(2f, -2f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(2f, 2f);
				Main.dust[a].color = new Color(255, 0, 0);

				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(0f, 2f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(0f, -2f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(2f, 0f);
				Main.dust[a].color = new Color(255, 0, 0);
				a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[a].velocity = new Vector2(-2f, 0f);
				Main.dust[a].color = new Color(255, 0, 0);
			}
		}
	}
}