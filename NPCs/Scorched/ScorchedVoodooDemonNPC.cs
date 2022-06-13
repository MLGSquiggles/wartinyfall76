using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


//First hostile NPC scorched zombie. Spawns during Scorched Earth Event

namespace wartinyfall76.NPCs.Scorched
{
    //[AutoloadHead]
    public class ScorchedVoodooDemonNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Scorched/ScorchedVoodooDemonNPC"; }
        }

        //setup defaults
        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Scorched Voodoo Demon");

            Main.npcFrameCount[NPC.type] = 2; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Voodoo Demon";
            return Mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Voodoo Demon";
        }
        public override void SetDefaults()
        {

            NPC.width = 48;
            NPC.height = 90;
            NPC.aiStyle = 14; //bat AI style
            NPC.damage = 100;
            NPC.defense = 23;
            NPC.lifeMax = 1200;
            NPC.HitSound = SoundID.NPCHit21;
            NPC.DeathSound = SoundID.NPCDeath23; //crimson death sound
            NPC.knockBackResist = 0.01f;
            NPC.value = 20f;

            //use these if copying an existing thing from terraria
            AIType = NPCID.VoodooDemon;
            AnimationType = NPCID.VoodooDemon;

            //get NPC to banner -- uses standard zombie
            Banner = Item.NPCtoBanner(NPCID.VoodooDemon);
            //then link it back
            BannerItem = Item.BannerToItem(Banner);
        }

        //spawn in the overworld as a test, eventually spawn in during event
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //if (wartinyfall76World.ScorchedInvasionUp)
            //{
            //    return 0.5f;
            //}
            //else
            //{
            //    return 0;
            //}
            return 0;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            //create dust on being hit
            for (int i = 0; i < 10; i++)
            {
                int dustType = DustID.JungleSpore;
                int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X * Main.rand.Next(-50, 50) * 0.01f;
                dust.velocity.Y = dust.velocity.Y * Main.rand.Next(-50, 50) * 0.01f;
                dust.scale *= 1 + Main.rand.Next(-30, 30) * 0.01f;
            }
        }

        public override void OnKill()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(NPC.position, Mod.Find<ModItem>("UltraciteOre_Item").Type);
            }

            if (Main.rand.Next(5) == 3)
            {
                Item.NewItem(NPC.position, ItemID.GuideVoodooDoll);
            }
        }






    }
}
