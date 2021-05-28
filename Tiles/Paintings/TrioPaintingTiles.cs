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
using Terraria.ObjectData;

namespace wartinyfall76.Tiles.Paintings
{
	public class TrioPaintingTiles : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);

			//update the height as the sprite is 6 x 4
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 }; //because height changed

			TileObjectData.newTile.Width = 6;
			TileObjectData.addTile(Type);

			disableSmartCursor = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Painting");
			AddMapEntry(new Color(120, 85, 60), name);

		
		//drop = ModContent.ItemType<Items.Paintings.MatthiusPaintingItem>();
		//soundType = SoundID.;
		//soundStyle = 1;
		
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			//drop = ModContent.ItemType<Items.Paintings.MatthiusPainting>();
			Item.NewItem(i * 16, j * 16, 16, 48, ModContent.ItemType<Items.Paintings.TrioPainting>());
		}
	}
}