using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Queue
{
    internal class FileName
    {
        public class item
        {
            string name;
            int id;
            public item(string name, int id)
            {
                this.name = name;
                this.id = id;
            }
        }
        static void Main(string[] args)
        {
            Queue<item> queue = new Queue<item>();

            queue.Enqueue(new item("방패 ", 1));
            queue.Enqueue(new item("포션 ", 2));
            item thisitem = new item("허브", 3);

            queue.Enqueue(thisitem);
            thisitem.name = "해독초";

            while (queue.Count > 0) 
            {
                Console.WriteLine(queue.Dequeue().name);
            }

             11/ 15 3 :50분 영상
        }
    }
}
