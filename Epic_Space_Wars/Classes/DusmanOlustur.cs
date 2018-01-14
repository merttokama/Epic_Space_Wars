using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Epic_Space_Wars.Interface;
using System.Drawing;

namespace Epic_Space_Wars.Classes
{
    public class DusmanOlustur : Character, IDikeyHareketEdebilme
    {
        Random rastgele = new Random();
        string shipA = "jpeg/EnemySpaceShip.jpg";
        string shipB = "jpeg/EnemySpaceShip2.jpg";
        string shipC = "jpeg/EnemySpaceShip3.jpg";

        public DusmanOlustur()
        {
            En = 50;
            Boy = 50;
            Hiz = 15;
            ResimOlustur();
        }

        public void DikeyHareketEt(bool asagiMi)
        {
            if (asagiMi)
                this.Konum = new Point(Konum.X, Konum.Y + Hiz);
            else
                this.Konum = new Point(Konum.X, Konum.Y - Hiz);
        }

        public override void ResimOlustur()
        {
            int sayi = rastgele.Next(3, 30);
            if (sayi % 3 == 0)
                this.Resim.ImageLocation = shipA;
            else if(sayi % 3 == 1)
                this.Resim.ImageLocation = shipB;
            else if (sayi % 3 == 2)
                this.Resim.ImageLocation = shipC;
            base.ResimOlustur();
            Resim.Visible = true;
            Resim.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
