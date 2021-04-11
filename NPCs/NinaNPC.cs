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

namespace wartinyfall76.NPCs
{
    [AutoloadHead]
    public class NinaNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/NinaNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/NinaNPCHead"; }
        }

        public override string[] AltTextures
        {
            get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Adacemy of Evil Student";
            return mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 23;
            NPCID.Sets.AttackFrameCount[npc.type] = 0; //???
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;

        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //town npc style
            npc.damage = 69;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit15;
            npc.DeathSound = SoundID.NPCDeath15;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Nurse;
        }

        //spawn in Nina, replace later
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
                    if (item.type == mod.ItemType("TheStabbyStabber")) //for testing use Jame's stabby stabber
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            return "Nina Cortex";
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
            int otherNPC = NPC.FindFirstNPC(NPCID.Guide); //checks if the guide is alive
            if (otherNPC >= 0 && Main.rand.NextBool(4))
            {
                return "Hey this " + Main.npc[otherNPC].GivenName + " guy is a loser!";
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Breaking things makes me happy.";
                case 1:
                    return "Where the monsters at! Its getting boring here!";
                case 2:
                    return "I hope you have been up to evil.";
                case 3:
                    return "Evil things make me happy!";
                case 4:
                    return "This beats doing schoolwork!";
                default:
                    return "Where's the destruction at! I wanna see " + Main.worldName + " overtaken by evil!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Debuff";
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
            shop.item[nextSlot].SetDefaults(mod.ItemType("TheStabbyStabber"));
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
            projType = ProjectileID.ShadowBeamFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5f;
            randomOffset = 2f;
        }
    }
}
