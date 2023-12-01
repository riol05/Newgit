using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class ShopScene : Scene
    {
        public ShopScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintShopMenu();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void EnterShop(Shop shop)
        {
            
        }
        public void ExitShop()
        {
            game.OpenPrev();
        }
        private void PrintShopMenu()
        {

        }
    }
}
