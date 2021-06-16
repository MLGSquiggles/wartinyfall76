using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


//Scorched derpling. Spawns during Scorched Earth Event

namespace wartinyfall76.NPCs.Scorched
{
    //[AutoloadHead]
    public class ScorchedDerplingNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Scorched/ScorchedDerplingNPC"; }
        }

        //setup defaults
        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Scorched Derpling");

            Main.npcFrameCount[npc.type] = 3; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Derpling";
            return mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Derpling";
        }
        public override void SetDefaults()
        {

            npc.width = 68;
            npc.height = 64;
            npc.aiStyle = 41; //Herpling AI style
            npc.damage = 100;
            npc.defense = 23;
            npc.lifeMax = 1200;
            npc.HitSound = SoundID.NPCHit22;
            npc.DeathSound = SoundID.NPCDeath23; //crimson death sound
            npc.knockBackResist = 0.01f;
            npc.value = 20f;

            //use these if copying an existing thing from terraria
            aiType = NPCID.Derpling;
            animationType = NPCID.Derpling;

            //get NPC to banner -- uses standard zombie
            banner = Item.NPCtoBanner(NPCID.Derpling);
            //then link it back
            bannerItem = Item.BannerToItem(banner);
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
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X * Main.rand.Next(-50, 50) * 0.01f;
                dust.velocity.Y = dust.velocity.Y * Main.rand.Next(-50, 50) * 0.01f;
                dust.scale *= 1 + Main.rand.Next(-30, 30) * 0.01f;
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("UltraciteOre_Item"));
            }            
        }






    }
}
