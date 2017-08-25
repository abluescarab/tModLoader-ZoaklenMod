using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Backgrounds
{
	public class NeonUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return NPC.AnyNPCs(mod.NPCType("MagicalCube"));
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/NeonUGBackground");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/NeonUGBackground");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/NeonUGBackground");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/NeonUGBackground");
		}
	}
}