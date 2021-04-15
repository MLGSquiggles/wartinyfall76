using Microsoft.Xna.Framework;
using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace wartinyfall76.Tiles.Ultracite
{
	public class UltraciteOre_Tile : ModTile
	{
		public override void SetDefaults()
		{
		TileID.Sets.Ore[Type] = true;
		Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
		Main.tileValue[Type] = 700; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
		Main.tileShine2[Type] = true; // Modifies the draw color slightly.
		Main.tileShine[Type] = 700; // How often tiny dust appear off this tile. Larger is less frequently
		Main.tileMergeDirt[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;

		ModTranslation name = CreateMapEntryName();
		name.SetDefault("UltraciteOre");
		AddMapEntry(new Color(234, 254, 126), name);

		dustType = 84;
		drop = ModContent.ItemType<Items.Ultracite.UltraciteOre_Item>();
		soundType = SoundID.Tink;
		soundStyle = 1;
		mineResist = 4f;
		minPick = 225;
		}
	}
}