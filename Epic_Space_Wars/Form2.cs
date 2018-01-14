using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Epic_Space_Wars.Classes;
using System.Collections;


namespace Epic_Space_Wars
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        #region TANIMLAMALAR

        MermiOlustur mermiOlustur;
        DusmanOlustur enemyShip;
        SpaceShip spaceShip;
        List<DusmanOlustur> gemiler = new List<DusmanOlustur>();
        List<MermiOlustur> mermiler = new List<MermiOlustur>();
        int sayac = 0, score = 0;
        Form1 frmAnaSayfa = new Form1();


        #endregion

        #region FORM LOAD

        private void Form2_Load(object sender, EventArgs e)
        {
            spaceShip = new SpaceShip();
            this.Controls.Add(spaceShip.Resim);
            spaceShip.Konum = new Point(this.ClientSize.Width / 2 - spaceShip.En, this.ClientSize.Height - spaceShip.Boy);
        }

        #endregion

        #region TIKLAMA ISLEMLERI

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                spaceShip.YatayHareketEt(true);
            else if (e.KeyCode == Keys.Right)
                spaceShip.YatayHareketEt(false);
            else if (e.KeyCode == Keys.Space)
                TimerMermiAtes.Start();
            else if (e.KeyCode == Keys.Escape)
                StopPanel();
        }

        #endregion

        #region METOTLAR

        private void AtesEtForm()
        {
            MermiOlustur mermiOlustur = new MermiOlustur();
            mermiOlustur.Konum = new Point(spaceShip.Konum.X + 15, spaceShip.Konum.Y);
            mermiOlustur.Resim.Visible = true;
            this.Controls.Add(mermiOlustur.Resim);
            mermiler.Add(mermiOlustur);
            TimerMermiHareket.Start();
            SoundTracks.spaceshipFireSoundtrack.Play();
        }

        private void DusmanHareket()
        {
            DusmanOlustur enemyShip = new DusmanOlustur();
            Random rasgele = new Random();
            int sayi = rasgele.Next(5, 845);
            enemyShip.Konum = new Point(sayi, 0);
            this.Controls.Add(enemyShip.Resim);
            gemiler.Add(enemyShip);
            TimerDusmanHareket.Start();
        }

        #endregion

        #region ZAMANLAMA ISLEMLERI

        private void TimerDusman_Tick(object sender, EventArgs e)
        {
            DusmanHareket();
        }

        private void TimerMermiHareket_Tick(object sender, EventArgs e)
        {
            foreach (MermiOlustur item in mermiler)
            {
                item.DikeyHareketEt(false);
            }
        }

        private void TimerDusmanHareket_Tick(object sender, EventArgs e)
        {
            foreach (DusmanOlustur item in gemiler)
            {
                item.DikeyHareketEt(true);
            }
        }

        private void TimerZorluk_Tick(object sender, EventArgs e)
        {
            if (TimerDusman.Interval >= 1600)
                TimerDusman.Interval -= 100;
            if (TimerDusmanHareket.Interval >= 160)
            TimerDusmanHareket.Interval -= 10;
            if (TimerMermiAtes.Interval >= 250)
                TimerMermiAtes.Interval -= 50;
            SoundTracks.bonusEffect.Play();
        }

        private void TimerMermiAtes_Tick(object sender, EventArgs e)
        {
            AtesEtForm();
            TimerMermiAtes.Stop();
        }

        public void TimerKontrol_Tick(object sender, EventArgs e)
        {
            Carpisma();
        }

        #endregion

        #region CARPISMALAR

        private void Carpisma()
        {
            for (int i = 0; i < gemiler.Count; i++)
            {
                if (gemiler[i].Resim.Bounds.IntersectsWith(lblAltDuvar.Bounds) || gemiler[i].Resim.Bounds.IntersectsWith(spaceShip.Resim.Bounds))
                { // Dusman Gemisi Aşağıdan Dışarı Çıkarsa       -        Dusman Gemisi Bizim Gemimize çarparsa
                    sayac++;

                    SoundTracks.explosionSound.Play();
                    if (sayac == 1) // Bir kez yanarsak 1 can gitsin
                    {
                        pictureBox3.Visible = false;
                        gemiler[i].Resim.Visible = false;
                        this.Controls.Remove(gemiler[i].Resim);
                        gemiler.Remove(gemiler[i]);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        break;
                    }
                    else if (sayac == 2) // yanarsak 2 can gitsin
                    {
                        pictureBox2.Visible = false;
                        gemiler[i].Resim.Visible = false;
                        this.Controls.Remove(gemiler[i].Resim);
                        gemiler.Remove(gemiler[i]);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        break;
                    }
                    else if (sayac == 3) // Oyunu Kaybettin
                    {
                        pictureBox1.Visible = false;
                        gemiler[i].Resim.Visible = false;
                        this.Controls.Remove(gemiler[i].Resim);
                        gemiler.Remove(gemiler[i]);
                        this.Controls.Remove(spaceShip.Resim);
                        spaceShip.Resim.Visible = false;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        TimerDusman.Stop();
                        TimerMermiHareket.Stop();
                        TimerDusmanHareket.Stop();
                        DialogResult cikis = new DialogResult();
                        cikis = MessageBox.Show("YOU LOSE!", "Your Score:" + lblScore.Text, MessageBoxButtons.OKCancel);

                        if (cikis == DialogResult.OK)
                        {
                            frmAnaSayfa.Show();
                            this.Close();
                        }
                        break;
                    }
                }
                for (int j = 0; j < mermiler.Count; j++)
                {
                    if (gemiler[i].Resim.Bounds.IntersectsWith(mermiler[j].Resim.Bounds))
                    { // Dusman Gemisi Lazer ile Vurulursa
                        SoundTracks.crashSoundtrack.Play();
                        gemiler[i].Resim.Visible = false;
                        mermiler[j].Resim.Visible = false;
                        this.Controls.Remove(gemiler[i].Resim);
                        gemiler.Remove(gemiler[i]);
                        this.Controls.Remove(mermiler[j].Resim);
                        mermiler.Remove(mermiler[j]);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        score += 50;
                        lblScore.Text = score.ToString();
                        break;
                    }
                    else if (lblUstDuvar.Bounds.IntersectsWith(mermiler[j].Resim.Bounds))
                    { // Lazer alan dışına çıkarsa
                        mermiler[j].Resim.Visible = false;
                        this.Controls.Remove(mermiler[j].Resim);
                        mermiler.Remove(mermiler[j]);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        break;
                    }
                }
            }
        }

        #endregion

        #region DURDUR MENUSU

        private void StopPanel()
        {
            durdurPanel.Visible = true;
            durdurPanel.Enabled = true;
            TimerDusman.Stop();
            TimerDusmanHareket.Stop();
            TimerMermiAtes.Stop();
            TimerMermiHareket.Stop();
            TimerZorluk.Stop();
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            durdurPanel.Visible = false;
            durdurPanel.Enabled = false;
            TimerZorluk.Start();
            TimerDusman.Start();
            TimerDusmanHareket.Start();
            TimerMermiHareket.Start();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}


