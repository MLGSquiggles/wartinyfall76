using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using wartinyfall76.NPCs.Nina;
using wartinyfall76.NPCs.Preston;


//town npc GLitch. This is intentionally strange

namespace wartinyfall76.NPCs.Glitch
{
    [AutoloadHead]
    public class GlitchNPC : ModNPC
    {
        ////this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        public int currentRandomItem = Main.rand.Next(2000);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Glitch/GlitchNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Glitch/GlitchNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "GlitchedAnomaly";
            return mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 25; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[npc.type] = 10; //???
            NPCID.Sets.DangerDetectRange[npc.type] = 1000;
            NPCID.Sets.AttackType[npc.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[npc.type] = 80;
            NPCID.Sets.AttackAverageChance[npc.type] = 40;
            NPCID.Sets.HatOffsetY[npc.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //town npc style
            npc.damage = 40;
            npc.defense = 250;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit57; 
            npc.DeathSound = SoundID.NPCDeath62;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Merchant;
        }

        //spawn in if the Preston and Nina are alive
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

            //this is broken as it only checks if nina and preston exist in the mod itself...
            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            
            if (nina != null && preston != null)
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            string wackName = "";

            switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    wackName = wackName + "B";
                    break;
                case 1:
                    wackName = wackName + "M";
                    break;
                case 2:
                    wackName = wackName + "P";
                    break;
                case 3:
                    wackName = wackName + "L";
                    break;
                case 4:
                    wackName = wackName + "J";
                    break;
                case 5:
                    wackName = wackName + "B";
                    break;
                case 6:
                    wackName = wackName + "R";
                    break;
                default:
                    wackName = wackName + "C";
                    break;

            }

                    //give us a semi random name with some pre done strings
                    for (int i = 0; i < 5; i++)
                    {
                switch (WorldGen.genRand.Next(20))
                {
                    case 0:
                        wackName = wackName + "arl";
                        break;
                    case 1:
                        wackName = wackName + "odney";
                        break;
                    case 2:
                        wackName = wackName + "ames";
                        break;
                    case 3:
                        wackName = wackName + "atthew";
                        break;
                    case 4:
                        wackName = wackName + "uan";
                        break;
                    case 5:
                        wackName = wackName + "elaney";
                        break;
                    case 6:
                        wackName = wackName + "ake";
                        break;
                    case 7:
                        wackName = wackName + "ared";
                        break;
                    case 8:
                        wackName = wackName + "eter";
                        break;
                    case 9:
                        wackName = wackName + "omas";
                        break;
                    case 10:
                        wackName = wackName + "arlos";
                        break;
                    case 11:
                        wackName = wackName + "achel";
                        break;
                    case 12:
                        wackName = wackName + "ann";
                        break;
                    case 13:
                        wackName = wackName + "arvey";
                        break;
                    case 14:
                        wackName = wackName + "ortex";
                        break;
                    case 15:
                        wackName = wackName + "oonlord";
                        break;
                    case 16:
                        wackName = wackName + "owser";
                        break;
                    case 17:
                        wackName = wackName + "eggman";
                        break;
                    case 18:
                        wackName = wackName + "aun";
                        break;
                    case 19:
                        wackName = wackName + "ott";
                        break;
                    case 20:
                        wackName = wackName + "eaper";
                        break;
                    default:
                        wackName = wackName + "ette";
                        break;

                }
            }
             

            return wackName;
             
        }

        

        public override string GetChat()
        {
            //each time you talk to him his item he attacks with changes
            currentRandomItem = Main.rand.Next(2000);

            
            int otherNPC = NPC.FindFirstNPC(NPCID.Merchant); //checks if the guide is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the merchant is alive
            {
                return "I wish " + Main.npc[otherNPC].GivenName + " would be more careful. I'm getting tired of having to sew his limbs back on every day.!";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.Truffle);
            if (otherNPC >= 0 && Main.rand.NextBool(5)) //randomly if the truffle is alive
            {
                return "Tried to get " + Main.npc[otherNPC].GivenName + " to pay me with favors once, now I have fungus growing in strange places.";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.Clothier);
            if (otherNPC >= 0 && Main.rand.NextBool(3)) //randomly if the clothier is alive
            {
                bool line = Main.rand.NextBool(2);
                if(line)
                {
                    return Main.npc[otherNPC].GivenName + " is a looker. Too bad she's such a prude.";
                }
                else
                {
                    return "I woke up to the clothier chewing on my foot last night.";
                }
                

            }

            otherNPC = NPC.FindFirstNPC(NPCID.Nurse);
            if (otherNPC >= 0 && Main.rand.NextBool(5)) //randomly if the nurse is alive
            {
                return "Hey, has " + Main.npc[otherNPC].GivenName + " mentioned needing to go to the doctor for any reason? I make a rather enchanting hot chocolate if you'd be inter...No? Ok.";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.Steampunker);
            if (otherNPC >= 0 && Main.rand.NextBool(5)) //randomly if the steampunker is alive
            {
                return "Ah, they will tell tales of " + Main.npc[otherNPC].GivenName + " some day... Have you seen Chith...Shith.. Chat... The big eye?";
            }

            //if nina exists
            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());         
            if (nina != null && Main.rand.NextBool(7))
            {
                return "Check out Nina Cortex. Now that's a girl who can paint the town red!"; //-- did not work
            }


            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if(preston != null && Main.rand.NextBool(8))
            {
                return "How come Preston Garvey won't sell me any ale? Either you have style, or you get styled.";
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(5))
                {
                    case 0:
                        return "When the moon goes red I of course need a home to live in.";
                    case 1:
                        return "There are some special plants and commodities are volatile and my dark arts, mysterious.";
                    case 2:
                        return "Mama always said you've got to more blinking lights";
                    case 3:
                        return "I'm no landlubber, but it's better to rest of the skeletons down here.";
                    case 4:
                        return "Tipping IS optional, but remember I like your... gear. Does it come in brass?";
                    case 5:
                        return "As if living underground wasn't bad enough, jerks like you come in while I'm sleeping and steal my children, so enough with your palaver you ragamuffin!";
                    default:
                        return "There's another settlement that needs our help. I hope you can get to them quickly. We need to show people that the Minutemen are back";
                }
            }
                

                switch (Main.rand.Next(11))
                {
                    case 0:
                        return "Explosives are da' bomb. How many times a week can you come in with severe lava burns? ";
                    case 1:
                        return "My expedition efficiency was all out of titanium white, so don't even ask.";
                    case 2:
                        return "Two people will not live in the same home. Also, if their home is destroyed, I'm gonna need more gold than that.";
                    case 3:
                        return "Keep your hands off my gun, That will get the attention of a dryad.";
                    case 4:
                        return "I hear a race of lizardmen painted a mural on this wall just a moment ago. Shoulda bought a weather radio!";
                    case 5:
                        return "So two goblins walk into a bar. It's pretty cold in the snow biome, maybe even bolts!";
                    case 6:
                        return "I sell what I want! If you don't like it, NO SMOKING IN HERE!!";
                    case 7:
                        return "Must everyone open and shut doors so incredibly noisily around here?! Be ready for anything if you decide to harvest one.";
                    case 8:
                        return "I tried having a paintball fight. Stop staring!";
                    case 9:
                        return "Turn your head and you are not aging very gracefully.";
                    case 10:
                        return "Gurrllll! You are my favorite gossip ever. I wonder if the moon is made of cheese...huh, what? Oh yes, buy something!";
                    case 11:
                        return "What? You thought I wasn't... Egg Nog!";
                default:
                        return "There's another settlement that needs our help. I hope you can get to them quickly. We need to show people that the Minutemen are back";
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
            shop.item[nextSlot].SetDefaults(mod.ItemType("GreenStaffItem"));
            nextSlot++;

            //condtions can also exist
            if (Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                nextSlot++;
            }
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 4000;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
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
            projType = ProjectileID.ChlorophyteBullet;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            //currentRandomItem = Main.rand.Next(1000);
            item = currentRandomItem;
            closeness = 1; //?
            
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
