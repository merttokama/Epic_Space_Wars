using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epic_Space_Wars.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace Epic_Space_Wars.Classes
{
    public class SpaceShip : Character, IYatayHareketEdebilme, IAtesEdebilme
    {
        public void AtesEt()
        {
            throw new NotImplementedException();
        }

        public SpaceShip()
        {
            En = 50;
            Boy = 50;
            Hiz = 20;
            ResimOlustur();
        }

        public void YatayHareketEt(bool solaMi)
        {
            if (solaMi)
            {
                    this.Konum = new Point(Konum.X - Hiz, Konum.Y);
                if (Konum.X < 21)
                    this.Konum = new Point(869, Konum.Y);
            }
            else
            {
                    this.Konum = new Point(Konum.X + Hiz, Konum.Y);
                if (Konum.X > 871)
                    this.Konum = new Point(19, Konum.Y);
            }
        }
        public override void ResimOlustur()
        {
            base.ResimOlustur();
            this.Resim.ImageLocation = "jpeg/SpaceShip.jpg";
            Resim.Visible = true;
            Resim.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
