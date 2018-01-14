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
    public class MermiOlustur : Character, IDikeyHareketEdebilme
    {
        public MermiOlustur()
        {
            En = 20;
            Boy = 36;
            Hiz = 20;
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
            base.ResimOlustur();
            this.Resim.ImageLocation = "jpeg/Low_Poly_2D_Bullet-min.jpeg";
            Resim.Visible = false;
            Resim.SizeMode = PictureBoxSizeMode.Zoom;
        }

    }
}
