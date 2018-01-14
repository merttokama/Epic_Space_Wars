using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epic_Space_Wars.Classes
{
    public abstract class Character
    {
        public PictureBox Resim { get; set; } = new PictureBox();

        public int En { get; set; }

        public int Boy { get; set; }

        public int Hiz { get; set; }
        public Point Konum
        {
            get
            {
                return Resim.Location;
            }
            set
            {
                Resim.Location = value;
            }
        }
        public virtual void ResimOlustur()
        {
            Resim.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Resim.Size = new System.Drawing.Size(En, Boy);
            Resim.Visible = true;
        }
    }
}
