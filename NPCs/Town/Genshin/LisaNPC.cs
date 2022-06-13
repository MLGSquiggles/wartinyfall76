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
using wartinyfall76.NPCs.Town.Warframe;
using wartinyfall76.NPCs.Town.Overwatch;
using wartinyfall76.NPCs.Town.Crash;
using wartinyfall76.NPCs.Town.Fallout;
using wartinyfall76.NPCs.Town.Genshin;

//town npc Lisa

namespace wartinyfall76.NPCs.Town.Genshin
{
    [AutoloadHead]
    public class LisaNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Genshin/LisaNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Genshin/LisaNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "Librarian";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 4; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; //town npc style
            NPC.damage = 180;
            NPC.defense = 45;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Nurse;
        }

        //spawn in Lisa if a player has a book in their inventory (standard ones found in dungeon)
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.Book) //player has a book in their inventory
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            return "Lisa";
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

            int otherNPC = NPC.FindFirstNPC(NPCID.Wizard); //checks if the demolitionist is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return Main.npc[otherNPC].GivenName + " gives magic such a bad name...";
            }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "Nina goes on about being a student but... what is it exactly is she studying?";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Preston is still in shock about the existence of magic... just wait until he finds out I'm the Witch of Purple Rose.";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "Hanzo's dragon... hmmm I wonder if he would let me pet it?";
            }

            NPC eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (eudico != null && Main.rand.NextBool(8))
            {
                return "I've never seen Eudico sleep, does she ever need to take a nap?";
            }

            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (klee != null && Main.rand.NextBool(8))
            {
                return " Last time little Klee wanted to use my workshop for her experiments, I had to say no, and she was angry at me for the rest of the day. What happened the next day, you ask? She went off happily to play outside of course.";
            }

            if (Main.raining && Main.rand.NextBool(8))
            {
                return "Perfect weather for sipping a cup of tea while gazing out the window.";
            }

            switch (Main.rand.Next(5))
            {
                case 0:
                    return "Hi darling, are you going to be Lisa's little helper? What? Me, a grand mage? That was a long time ago, I'm just a humble librarian now. Don't worry darling, I'll take very good care of you.";
                case 1:
                    return "Why not keep me company for a while... There'll be plenty of time for work later.";
                case 2:
                    return "Today's no good for going out... Hmm... Did I say that yesterday as well?";
                case 3:
                    return "I'm not lazy, I just know to save my energy for when I need it most.";
                case 4:
                    return "Such a calming breeze... Perfect for taking a nap, don't you think?";
                case 5:
                    return "Hey darling, would you like to try one of my magic potions? There's no knowing what it will do to you until you try it, though... Don't say I didn't warn you!";
                default:
                    return "It must almost be time for a nap...";
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
            shop.item[nextSlot].SetDefaults(ItemID.Book);
            nextSlot++;

            //if klee is alive, sell EKBN painting
            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (klee != null)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("EKBNPainting").Type);
                nextSlot++;
            }

            //if wall of flesh is defeated
            if(Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.WaterBolt); //10
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls); //10
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DemonScythe); //10
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
            }

            //if all three mech bosses defeated
            if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoldenShower); //10
                shop.item[nextSlot].shopCustomPrice = 500000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CursedFlame); //10
                shop.item[nextSlot].shopCustomPrice = 500000;
                nextSlot++;
            }
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
            cooldown = 30;
            randExtraCooldown = 25;
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
            projType = ProjectileID.InfluxWaver;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            item = ItemID.Book;
            closeness = 10; //?
        }
    }
}
