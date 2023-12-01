using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Sword : Item
    {
        private int damage = 10;

        public Sword()
        {
            name = "한손검";
            Description = $"장착시 공격력을 {damage} 올려줍니다";
            CanUse = 1;
        }  

        public virtual void Use(Player player, int command)
        {
            

            if (player.equipSword == false)
            {
                Console.WriteLine("한손검을 장비합니다.");
                player.equipSword = true;
                player.Damage = player.Damage + damage;
                base.Use(command);

            }
            else
            {
                Console.WriteLine("이미 무기를 장착하고 있습니다.");
                base.Use(command);
                }

            }
        }
    }

