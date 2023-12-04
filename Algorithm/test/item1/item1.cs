using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class Item1 // 교수님 파일
    {
        public string Description;
        public string name;
        public int CanUse; // 사용 가능 여부
        public int amount;
        public int weight;
        public int Point;
        public Inventory inv = Inventory.GetInstance();

        public abstract void Use();        

    }
}
