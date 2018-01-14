using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Epic_Space_Wars.Classes;

namespace Epic_Space_Wars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          SoundTracks.mainMenuSoundtrack.Play();
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            SoundTracks.mainMenuSoundtrack.Stop();
            SoundTracks.crashSoundtrack.Play();
            Form2 formGecis = new Form2();
            formGecis.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
