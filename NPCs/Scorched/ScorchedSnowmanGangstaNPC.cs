﻿using System;
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
    public class ScorchedSnowmanGangstaNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Scorched/ScorchedSnowmanGangstaNPC"; }
        }

        //setup defaults
        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Scorched Snowman Gangsta");
            
            Main.npcFrameCount[npc.type] = 4; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Snowman Gangsta";
            return mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Snowman Gangsta";
        }
        public override void SetDefaults()
        {
               
            npc.width = 30;
            npc.height = 50;
            npc.aiStyle = 38; //snowman AI
            npc.damage = 40;
            npc.defense = 30;
            npc.lifeMax = 900;
            npc.HitSound = SoundID.NPCHit1; 
            npc.DeathSound = SoundID.NPCDeath23; //crimson death sound
            npc.knockBackResist = 0.01f;
            npc.value = 20f;

            //use these if copying an existing thing from terraria
            aiType = NPCID.SnowmanGangsta;
            animationType = NPCID.SnowmanGangsta;

            //get NPC to banner -- uses standard zombie
            banner = Item.NPCtoBanner(NPCID.Zombie);
            //then link it back
            bannerItem = Item.BannerToItem(banner);
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
