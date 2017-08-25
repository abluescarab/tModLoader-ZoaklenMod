using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace ZoaklenMod
{
	public class BiomeInformations
	{
		public string name = "???";
		public Color color = new Color(255, 0, 0);
		public Player player = Main.player[0];
		public void UpdateInfos()
		{
			if(player.position.Y < 1000)
			{
				name = "Space";
				color = new Color(0, 62, 132);
			}
			else if(player.position.Y < 2500)
			{
				name = "Sky";
				color = new Color(255, 255, 194);
			}
			else if(player.position.Y > (Main.maxTilesY - 200)*16)
			{
				name = "Underworld";
				color = new Color(255, 101, 31);
			}
			else if(player.ZoneDungeon)
			{
				name = "Dungeon";
				color = new Color(0, 74, 140);
			}
			else if(player.ZoneJungle)
			{
				name = "Jungle";
				color = new Color(15, 194, 2);
			}
			else if(player.ZoneCorrupt)
			{
				name = "Corruption";
				color = new Color(128, 0, 167);
			}
			else if(player.ZoneCrimson)
			{
				name = "Crimson";
				color = new Color(178, 58, 0);
			}
			else if(player.ZoneHoly)
			{
				name = "Hallow";
				color = new Color(255, 0, 255);
			}
			else if(player.ZoneGlowshroom)
			{
				name = "Mushroom";
				color = new Color(0, 62, 236);
			}
			else if(player.ZoneDesert || player.ZoneUndergroundDesert)
			{
				name = "Desert";
				color = new Color(194, 182, 140);
			}
			else if(player.ZoneSnow)
			{
				name = "Snow";
				color = new Color(255, 205, 194);
			}
			else
			{
				if(player.position.Y > 7150)
				{
					name = "Caverns";
					color = new Color(116, 66, 80);
				}
				else if(player.position.X < 4000 || player.position.X > (Main.maxTilesX-250)*16)
				{
					name = "Ocean";
					color = new Color(43, 140, 255);
				}
				else
				{
					name = "Pacific Place";
					color = new Color(43, 163, 80);
				}
			}
		}
	}
}