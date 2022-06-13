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
    public class ScorchedGoblinSummonerNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Scorched/ScorchedGoblinSummonerNPC"; }
        }

        //setup defaults
        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Scorched Goblin Summoner");
            
            Main.npcFrameCount[NPC.type] = 20; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Goblin Summoner";
            return Mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Goblin Summoner";
        }
        public override void SetDefaults()
        {
               
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 3; //fighter AI style
            NPC.damage = 300;
            NPC.defense = 40;
            NPC.lifeMax = 10000;
            NPC.HitSound = SoundID.NPCHit40; 
            NPC.DeathSound = SoundID.NPCDeath23; //crimson death sound
            NPC.knockBackResist = 0.35f;
            NPC.value = 50f;
            NPC.npcSlots = 2;

            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.ShadowFlame] = true;

            //use these if copying an existing thing from terraria
            AIType = NPCID.GoblinSummoner;
            AnimationType = NPCID.GoblinSummoner;

            //get NPC to banner -- uses standard zombie
            Banner = Item.NPCtoBanner(NPCID.Zombie);
            //then link it back
            BannerItem = Item.BannerToItem(Banner);
        }

        //spawn in the overworld as a test, eventually spawn in during event
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //if(wartinyfall76World.ScorchedInvasionUp)
            //{
            //    return  0.5f;
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
            for(int i = 0; i < 10; i++)
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
        }

       




    }
}
