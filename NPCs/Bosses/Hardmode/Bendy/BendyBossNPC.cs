using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace wartinyfall76.NPCs.Bosses.Hardmode.Bendy
{
    public class BendyBossNPC : ModNPC
    {
        
        
        
        // find/load texture for NPC 
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Bosses/Hardmode/Bendy/BendyBossNPC"; }
        }

        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Bendy");

            Main.npcFrameCount[NPC.type] = 3; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Bendy";
            return Mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Bendy";
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 102;
            NPC.aiStyle = 32;
            NPC.damage = 200;
            NPC.defense = 49;
            NPC.lifeMax = 50000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = 120000f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.npcSlots = 6f;

            //use these if copying an existing thing from terraria
            AIType = NPCID.SkeletronPrime;
            AnimationType = NPCID.SkeletronPrime;

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)((double)NPC.lifeMax * 0.75);
            NPC.damage = (int)((double)NPC.damage * 0.85);
        }

        











    }
}
