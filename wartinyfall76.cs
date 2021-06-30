using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
namespace wartinyfall76
{
	public class wartinyfall76 : Mod
    {

        public wartinyfall76()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true   
            };
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            //Checks if the invasion is in the correct spot, if it is, then change the music
            if (wartinyfall76World.ScorchedInvasionUp && Main.invasionX == Main.spawnTileX)
            {
                music = ((Mod)this).GetSoundSlot(SoundType.Music, "Sounds/Music/Events/boss Theme 1");
                priority = (MusicPriority)6;
            }
        }

        /*public override void Load()
        {
            // Will show up in client.log under the ExampleMod name

            // In older tModLoader versions we used: ErrorLogger.Log("blabla");
            // Replace that with above


            ModTranslation text = CreateTranslation("LivesLeft");
            text = CreateTranslation("BossSpawnInfo.ExampleWormHead");
            text.SetDefault("Use a [i:" + ModContent.ItemType<Items.ClingerWorm.StrangeBait>() + "] in the Corruption after Golem has been defeated");
            AddTranslation(text);

            // Volcano warning is for the random volcano tremor

        }


        public override void PostSetupContent()
        {
            // Showcases mod support with Boss Checklist without referencing the mod
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    10.5f,
                    new List<int> { ModContent.NPCType<NPCs.Bosses.Clinger_Worm.ExampleWormHead>() },
                    this, // Mod
                    "Clinger Worm",
                    (Func<bool>)(() => ExampleWorld.downedClingerWorm),
                    ModContent.ItemType<Items.ClingerWorm.StrangeBait>(),

                    "Use Strange Bait in the Corruption after Golem is defeated."
                );

            }
        }*/


    }


}