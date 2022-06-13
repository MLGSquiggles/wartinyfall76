using Microsoft.Xna.Framework;
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

namespace wartinyfall76.Items.Crash
{
    public class PowerCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power Crystal");
            Tooltip.SetDefault("Crystal of unknown origin.");
        }

        public override void SetDefaults()
        {
            // hitbox
            //item.width = 20;
            //item.height = 20;
            
            Item.maxStack = 999;
            Item.value = 1800;
            Item.rare = 11;
            Item.consumable = false;
            // Set other item.X values here
            // Usage
            
            
            


        }
        
    }
}