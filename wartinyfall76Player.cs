using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using wartinyfall76.Items.Ultracite;
using System.Net;
using System.Runtime.CompilerServices;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using wartinyfall76.NPCs.Scorched;

namespace wartinyfall76
{
    public class wartinyfall76Player : ModPlayer
    {
       public bool AkuAkuPet = false;

        //reset stuff in this function (stuff that should be reset on death)
        public override void ResetEffects()
        {
            AkuAkuPet = false;
        }
    }
}

