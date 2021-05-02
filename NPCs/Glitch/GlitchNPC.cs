using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


//town npc GLitch. This is intentionally strange

namespace wartinyfall76.NPCs.Glitch
{
    [AutoloadHead]
    public class GlitchNPC : ModNPC
    {
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
            int otherNPC = mod.NPCType("EvilStudent");
            int otherNPC2 = mod.NPCType("MinutemenSeniorOfficer");
            if (otherNPC >= 0 && otherNPC >= 0)
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            string wackName = "M";
            
            //give us a semi random name with some pre done strings
            for(int i = 0; i < 5; i++)
            {
                switch (WorldGen.genRand.Next(20))
                {
                    case 0:
                        wackName = wackName + "e";
                        break;
                    case 1:
                        wackName = wackName + "rag";
                        break;
                    case 2:
                        wackName = wackName + "ol";
                        break;
                    case 3:
                        wackName = wackName + "me";
                        break;
                    case 4:
                        wackName = wackName + "a";
                        break;
                    case 5:
                        wackName = wackName + "qu";
                        break;
                    case 6:
                        wackName = wackName + "ow";
                        break;
                    case 7:
                        wackName = wackName + "op";
                        break;
                    case 8:
                        wackName = wackName + "otto";
                        break;
                    case 9:
                        wackName = wackName + "z";
                        break;
                    case 10:
                        wackName = wackName + "xe";
                        break;
                    case 11:
                        wackName = wackName + "n";
                        break;
                    case 12:
                        wackName = wackName + "wo";
                        break;
                    case 13:
                        wackName = wackName + "we";
                        break;
                    case 14:
                        wackName = wackName + "egg";
                        break;
                    case 15:
                        wackName = wackName + "moon";
                        break;
                    case 16:
                        wackName = wackName + "lord";
                        break;
                    case 17:
                        wackName = wackName + "nina";
                        break;
                    case 18:
                        wackName = wackName + "mer";
                        break;
                    case 19:
                        wackName = wackName + "chant";
                        break;
                    case 20:
                        wackName = wackName + "help";
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
            
            //if(!Main.bloodMoon) //if it is not a blood moon have these lines
            //{
                int otherNPC = NPC.FindFirstNPC(NPCID.Merchant); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return "He seems familiar that " + Main.npc[otherNPC].GivenName + "!";
                }

                //otherNPC = NPC.FindFirstNPC(mod.NPCType("NinaNPC")); -- doesnt work
                //if(otherNPC >= 0 && Main.rand.NextBool(3))
                //{
                //had trouble getting other town NPC names...
                //nina = NPC.FindFirstNPC(mod.NPCType("NinaNPC"));//NPC.FindFirstNPC(mod.NPCType("NinaNPC"));
                

                //return Main.npc[otherNPC].GivenName + "Please be Nina cortex"; -- did not work
                //}

            if(Main.raining)
            {
                return "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
            }
            
            if(Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "When the moon goes red I of course need a home to live in.";
                    case 1:
                        return "There are some special plants and commodities are volatile and my dark arts, mysterious.";
                    case 2:
                        return "Mama always said you've got to more blinking lights";
                    case 3:
                        return "I'm no landlubber, but it's better to rest of the skeletons down here.";
                    default:
                        return "There's another settlement that needs our help. I hope you can get to them quickly. We need to show people that the Minutemen are back";
                }
            }
                

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "Don't blame me if I destroy your world.";
                    case 1:
                        return "Settlement blame me are dangerous!";
                    case 2:
                        return "My wares are dangerous, use them with caution";
                    case 3:
                        return "I had to put on a breaking things makes destroy your world.";
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
            shop.item[nextSlot].SetDefaults(mod.ItemType("ScorchedTransmitter"));
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
            cooldown = 20;
            randExtraCooldown = 15;
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
            item = Main.rand.Next(1000); 
            closeness = 1; //?
            
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
