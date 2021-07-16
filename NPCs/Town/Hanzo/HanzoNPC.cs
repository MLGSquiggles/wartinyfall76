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
using wartinyfall76.NPCs.Town.Eudico;
using wartinyfall76.NPCs.Town.Klee;
using wartinyfall76.NPCs.Town.Nina;
using wartinyfall76.NPCs.Town.Preston;

//town npc Hanzo. attempted random arrow when attacking

namespace wartinyfall76.NPCs.Town.Hanzo
{
    [AutoloadHead]
    public class HanzoNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        int arrowIterator = 0;

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Hanzo/HanzoNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Hanzo/HanzoNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "OlderShimadaBrother";
            return mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[npc.type] = 5; //???
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[npc.type] = 50;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 2; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //town npc style
            npc.damage = 40;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1; 
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        //spawn in Preston if the arms dealer is alive
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
            //int otherNPC = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (Main.hardMode) //should be if world is in hardmode
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            return "Hanzo";
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
            
            
            int otherNPC = NPC.FindFirstNPC(NPCID.DD2Bartender); //checks if the guide is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return "Ale? Such an unsophisticated taste... " + Main.npc[otherNPC].GivenName + " should serve Sake.";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.PartyGirl); //checks if the guide is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return "My enemies fall like ... heh heh heh, destroyed piñatas!";
            }

            if (Main.moonPhase == 1 && Main.rand.NextBool(2)) //if it is a fuul moon
            {
                return "When the moon is full, it begins to wane.";
            }

            if (Main.bloodMoon && Main.rand.NextBool(5)) //if it is a blood moon
            {
                return "Strength does not come from physical capability, it comes from an indomitable will.";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "That Preston fellow reminds me of a certain unwieldly cowboy...";
            }

            NPC Nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (Nina != null && Main.rand.NextBool(8))
            {
                return "As such shame the Shimada Clan has fallen with, we will never fall to the level the Cortex family has...";
            }

            NPC Klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (Klee != null && Main.rand.NextBool(8))
            {
                return "The barbaric nature in which Klee throws those bombs ruins my attempts at peace in this new life.";
            }

            NPC Eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Eudico != null && Main.rand.NextBool(8))
            {
                return "The ammount of debt Eudico escaped from by arriving here is staggering, it would quadruple my father's empire tenfold!";
            }

            switch (Main.rand.Next(3))
                {
                    case 0:
                        return "With every death, comes honor. With honor, redemption.";
                    case 1:
                        return "I have lost my home and my brother. But I will not lose my honor.";
                    case 2:
                        return "From one thing, know ten thousand things.";
                    case 3:
                        return "I gave up my father's empire... and his fortune alongside it.";
                    default:
                        return "My arrow finds its mark.";
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
            shop.item[nextSlot].SetDefaults(ItemID.WoodenArrow); //0            
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.FlamingArrow); //1
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.HolyArrow); //2
            shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.UnholyArrow); //3
            shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.JestersArrow); //4
            shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.HellfireArrow); //5
            shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.BoneArrow); //6
            shop.item[nextSlot].shopCustomPrice = 50;
            nextSlot++;

            if (Main.hardMode)
            {

                shop.item[nextSlot].SetDefaults(ItemID.CursedArrow); //7
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.IchorArrow); //8
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FrostburnArrow); //9
                shop.item[nextSlot].shopCustomPrice = 150;
                nextSlot++;
            }

            if (NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteArrow); //10
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.VenomArrow); //11
                shop.item[nextSlot].shopCustomPrice = 250;
                nextSlot++;
            }

            if(NPC.downedMoonlord)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MoonlordArrow); //12
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
            }    
            
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 30;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 5;
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
            arrowIterator++;
            if(arrowIterator > 12)
            {
                arrowIterator = 0;
            }

            switch (arrowIterator)
            {
                case 0:
                    projType = ProjectileID.WoodenArrowFriendly;
                    break;
                case 1:
                    projType = ProjectileID.FlamingArrow;
                    break;
                case 2:
                    projType = ProjectileID.HolyArrow;
                    break;
                case 3:
                    projType = ProjectileID.UnholyArrow;
                    break;
                case 4:
                    projType = ProjectileID.JestersArrow;
                    break;
                case 5:
                    projType = ProjectileID.HellfireArrow;
                    break;
                case 6:
                    projType = ProjectileID.BoneArrow;
                    break;
                case 7:
                    projType = ProjectileID.CursedArrow;
                    break;
                case 8:
                    projType = ProjectileID.IchorArrow;
                    break;
                case 9:
                    projType = ProjectileID.FrostburnArrow;
                    break;
                case 10:
                    projType = ProjectileID.ChlorophyteArrow;
                    break;
                case 11:
                    projType = ProjectileID.VenomArrow;
                    break;
                case 12:
                    projType = ProjectileID.MoonlordArrow;
                    break;
            }
            
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            item = 2223; //pulse bow
            closeness = 10; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
