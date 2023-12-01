using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class CSword : Item
    {
        private int damage = 10;
        
        public CSword()
        {
            name = "한손검";
            Description = $"장착시 공격력을 {damage} 올려줍니다";
            CanUse = 1;
        }  

        public override void Use(Player player,int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command - 1);
            }
            player.EquipSword(damage);
            }
        }
    }

