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

            Main.npcFrameCount[npc.type] = 3; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Bendy";
            return mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Bendy";
        }

        public override void SetDefaults()
        {
            npc.width = 80;
            npc.height = 102;
            npc.aiStyle = 32;
            npc.damage = 200;
            npc.defense = 49;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.value = 120000f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.npcSlots = 6f;

            //use these if copying an existing thing from terraria
            aiType = NPCID.SkeletronPrime;
            animationType = NPCID.SkeletronPrime;

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)((double)npc.lifeMax * 0.75);
            npc.damage = (int)((double)npc.damage * 0.85);
        }

        











    }
}
