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
using wartinyfall76.NPCs.Town.Overwatch;
using wartinyfall76.NPCs.Town.Genshin;
using wartinyfall76.NPCs.Town.Crash;
using wartinyfall76.NPCs.Town.Fallout;

//town npc Eudico. 

namespace wartinyfall76.NPCs.Town.Warframe
{
    [AutoloadHead]
    public class EudicoNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Warframe/EudicoNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Warframe/EudicoNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "Fb-9";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 4; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 80;
            NPCID.Sets.AttackAverageChance[NPC.type] = 40;
            NPCID.Sets.HatOffsetY[NPC.type] = -3; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; //town npc style
            NPC.damage = 40;
            NPC.defense = 17;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        //spawn in Eudico if destroyer is defeated
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            //for (int i = 0; i < 255; i++)
            //{
            //    Player player = Main.player[i];
            //    if (!player.active)
            //    {
            //        continue;
            //    }

            //    foreach (Item item in player.inventory)
            //    {
            //        if (item.type == mod.ItemType("TheStabbyStabber")) //for testing use James's stabby stabber
            //        {
            //            return true;
            //        }
            //    }
            //}
            
            if (NPC.downedMechBoss1) //if the destroyer is defeated
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            return "Eudico";
            /*
             switch(WorldGen.genRand.Next(4))
             {case 0 :
             return "name 0";
             case 1:
             return name 1;
             case 2: 
             return name 2;
             }
             */
        }

        public override string GetChat()
        {
            
            //if(!Main.bloodMoon) //if it is not a blood moon have these lines
            //{
                int otherNPC = NPC.FindFirstNPC(NPCID.ArmsDealer); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return "Accessing buffer. Analyzing... " + Main.npc[otherNPC].GivenName + " makes guns without using blueprints? Sparky surely you plan before you make weapons?";
                }

            otherNPC = NPC.FindFirstNPC(NPCID.Steampunker); //checks if the steampunker is alive
            int otherNPC2 = NPC.FindFirstNPC(NPCID.Cyborg); //checks if the cyborg is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return Main.npc[otherNPC].GivenName + " keeps wanting to study me and its getting intrusive. She already has access to " + Main.npc[otherNPC2].GivenName
                    + " and he likes it, so why is she so persistent with me?";
            }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "Accessing buffer. Analyzing... Nina Cortex's cybernetic hands seem to be malfunctioning for some reason. I hope she can get it sorted... or maybe not.";
            }
            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Accessing buffer. Analyzing... Preston Garvey is a good man leading great people. If Fortuna had the Minutemen to aid our rebellion we could shove off the Taxmen for good!";
            }

            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Accessing buffer. Analyzing... Klee's fish blasting is an interesting hobby. Throwing explosives in Orb Vallis lakes could provide lots of servofish parts, but then again it would attract the Taxmen and the parts could get damaged.";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "Accessing buffer. Analyzing... Hanzo's arrow efficiency rivals that of the Ivara warframes ive contracted in the past.";
            }

            NPC lisa = FindNPC(ModContent.NPCType<LisaNPC>());
            if (lisa != null && Main.rand.NextBool(8))
            {
                return "Accessing buffer. Analyzing... Lisa keeps watching me, trying to figure out if I sleep or not... WELL BLOODY YES I DO SPARKY!";
            }

            if (!Main.dayTime && Main.rand.NextBool(2)) //if it is night
                {
                    return "I can rest easy knowing the Taxmen cant get me here, yet I still worry about everyone back at Fortuna.";
                }

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "Status check on coolant flow. And mind it doesn't off-gas!";
                    case 1:
                        return "Make it quick. What's it gonna be?";
                    case 2:
                        return "Anyone asks: we never talked.";
                    case 3:
                        return "I am Floor Boss Eudico FB-9. Well, seems ive got a different place in life in " + Main.worldName + " eh Sparky?";
                    default:
                        return "Accessing buffer. Analyzing...";
                }
            
            
            
            
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            //button2 = "Debuff";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                //is it a shop
                shop = true;
            }
            else
            {
                Main.npcChatText = "Muahahahaha!";

            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //repeat for each item, up to 40
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("BazaBlueprint_Item").Type);
            nextSlot++;

           
        }

        public override void OnKill()
        {
            base.OnKill();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 40;
            randExtraCooldown = 35;
        }

        //public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        //{
        //    itemWidth = 5;
        //    itemHeight = 5;
        //}

        public override void TownNPCAttackShoot(ref bool inBetweenShots)
        {
            inBetweenShots = true;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            item = Mod.Find<ModItem>("Baza_Item").Type; //434 should be the clockwork assault rifle 96 is musket
            closeness = 1; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
