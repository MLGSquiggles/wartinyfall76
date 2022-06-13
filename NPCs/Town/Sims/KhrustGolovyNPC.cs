using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using wartinyfall76.NPCs.Town.Warframe;
using wartinyfall76.NPCs.Town.Genshin;
using wartinyfall76.NPCs.Town.Crash;
using wartinyfall76.NPCs.Town.Fallout;
using wartinyfall76.NPCs.Town.GTA;
using wartinyfall76.NPCs.Town.Control;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//town npc Hanzo. attempted random arrow when attacking

namespace wartinyfall76.NPCs.Town.Sims
{
    [AutoloadHead]
    public class KhrustGolovyNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        int arrowIterator = 0;

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Sims/KhrustGolovyNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Sims/KhrustGolovyNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "DisguisedAlien";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 15; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 150;
            NPCID.Sets.AttackType[NPC.type] = 3; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 15;
            NPCID.Sets.HatOffsetY[NPC.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; //town npc style
            NPC.damage = 400;
            NPC.defense = 40;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
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
            return "Khrust Golovy";
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

            NPC Klee = FindNPC(ModContent.NPCType<KleeNPC>());
            int otherNPC = NPC.FindFirstNPC(NPCID.Dryad); //checks if the guide is alive
            if (otherNPC >= 0 && Klee != null && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return "Hey uh... does " + Main.npc[otherNPC].GivenName + " know that she's wearing that with kids around!";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.Pirate); //checks if the guide is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
            {
                return "Yarr har fiddle dee dee, being a pirate is alright to be, do what you want cause a pirate is free, " + Main.npc[otherNPC].GivenName
                    + " is the pirate!";
            }

            if (Main.moonPhase == 1 && Main.rand.NextBool(2)) //if it is a fuul moon
            {
                return "Werewolves come out on full moons right? Ive never met one, mainly vampires, wizards and mermaids!";
            }

            if (Main.bloodMoon && Main.rand.NextBool(5)) //if it is a blood moon
            {
                return "Red moon! Red moon! RED MOON!!!";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Preston Garvey is certainly someone I would want defending the town! Oh and you of course!";
            }

            NPC Nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (Nina != null && Main.rand.NextBool(8))
            {
                return "Wait are you telling me Nina isn't an alien... Not even alien parents? How'd she get the skin complexion then? Can you ask for me, she terrifies me!";
            }

            NPC Hanzo = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Hanzo != null && Main.rand.NextBool(8))
            {
                return "Hanzo glanced at me and I couldn't keep myself composed at all! He's like the worst critic and he hasn't even" +
                    " heard my singing or music.";
            }

            if (Klee != null && Main.rand.NextBool(8))
            {
                return "If Klee ever serves pufferfish, im staying away from that meal.";
            }

            NPC Eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Eudico != null && Main.rand.NextBool(8))
            {
                return "Solaris United sounds like a cool band name... You think Eudico would be willing to jam?";
            }

            NPC Lisa = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Lisa != null && Main.rand.NextBool(8))
            {
                return "Im not much of a book person, but I would like to see Lisa's library. I hope she has stuff on music theory!";
            }

            NPC Trevor = FindNPC(ModContent.NPCType<TrevorNPC>());
            if (Trevor != null && Main.rand.NextBool(8))
            {
                return "Maybe Trevor can be soothed with some tunes...?";
            }

            NPC Ahti = FindNPC(ModContent.NPCType<AhtiNPC>());
            if (Ahti != null && Main.rand.NextBool(8))
            {
                return "I wonder what music Ahti always listens to?";
            }

            switch (Main.rand.Next(3))
                {
                    case 0:
                        return "I would love to join you on your adventures but I wanna play music instead!";
                    case 1:
                        return "Yes I am an alien. I am not native to earth... or this world... something's up with the multiverse isn't it.";
                    case 2:
                        return "Let me guess, you want to rock on right?";
                    case 3:
                        return "If you ever find anything fun to play with please let me try it. I've heard yo-yos are popular in these parts!";
                    default:
                        return "Dum-Dum-De-De-Do-De-De-De-Lo-Di-Do-Dum-Dum!";
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
            
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("GolovyGuitar").Type);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("KhrustAndMatthiusSingPainting").Type);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("KhrustGuitarPainting").Type);
            nextSlot++;
        }

        public override void OnKill()
        {
            base.OnKill();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 180;
            knockback = 20f;
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

        //public override void TownNPCAttackShoot(ref bool inBetweenShots)
        //{
        //    inBetweenShots = true;
        //}

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            item = TextureAssets.Item[Mod.Find<ModItem>("GolovyGuitar").Type].Value;
            scale = 1;
            itemSize = 50;
            offset = new Vector2(-1, 0);
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 56;
            itemHeight = 46;
        }

        //public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        //{
        //    scale = 1; //?
        //    item = 2223; //pulse bow
        //    closeness = 10; //?
        //}

        //public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        //{
        //    multiplier = 20f;
        //    randomOffset = 2f;
        //}
    }
}
