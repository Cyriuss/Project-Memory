﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// een "loading" screen die draait op timers om de animatie te doen, en een random quote weergeeft
/// </summary>
namespace Memory
{

    public partial class LoadingScreen : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
   
        public LoadingScreen()
        {
            InitializeComponent();

            Loading_bar.Controls.Add(label1);
            label1.BackColor = Color.Transparent;
            timer1.Start();
            timer3.Start();

            ChangeCursor();

            // Genereren van een willekeurige Loadingscreen text
            Random rand = new Random();
            double a = rand.Next(1, 9);


			if (a == 1)
			{
				label1.Text = "Randomizing cards";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 2)
			{
                label1.Text = "Finishing the last preparations";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 3)
			{
                label1.Text = "Showing an extremly useless loading screen";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 4)
			{
                label1.Text = "Giving you some time to mentally prepare";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 5)
			{
                label1.Text = "Wasting valuable time";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 6)
			{
                label1.Text = "Testing players for hacks";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}

			else if (a == 7)
			{
                label1.Text = "The ting goes skraa";
                timer2.Start();
                label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}
			else if (a == 8)
			{
                label1.Text = "Donderdag visdag";
				label1.Font = new Font("Arial", 18, FontStyle.Bold);
				label1.ForeColor = System.Drawing.Color.Black;
				label1.AutoSize = false;
				label1.TextAlign = ContentAlignment.MiddleCenter;
				label1.Dock = DockStyle.Fill;
			}
		}

        // Veranderd de mouse cursor
		void ChangeCursor()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.cur1031);
            Cursor c = new Cursor(bmp.GetHicon());
            this.Cursor = c;
        }

		// Magische code die de flickering in de form fixt
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

        // Afspelen van een soundeffect
        private async void timer3_Tick(object sender, EventArgs e)
        {
            player.Stop(); //stop van ting goes skra
			player.SoundLocation = "ping.wav";
			player.Play();
			await Task.Delay(2000);
			player.Stop();
            timer3.Stop();
		}

        // Method voor het sluiten van de form
        public void Sluiten()
        {
            this.Close();
            Dispose();
            GC.Collect();
        }

        // Afspelen van audio bij het willekeurige getal: 7
        private void timer2_Tick(object sender, EventArgs e)
        {
            player.SoundLocation = "Skra.wav";
            player.Play();
            timer2.Stop();
            
        }

        // Sluiten van de loadingscreen form na een bepaalde tijd
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Sluiten();
        }
    }
}
