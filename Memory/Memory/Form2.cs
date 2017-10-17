﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace Memory
{
    public partial class Form2 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        //System.Windows.Forms.Cursor.Current = 
        public Form2()
        {

            InitializeComponent();
            bar.Controls.Add(Exit);
            Exit.BackColor = Color.Transparent;

            cat.Controls.Add(Play);
            Play.BackColor = Color.Transparent;

            cat.Controls.Add(Highscore);
            Highscore.BackColor = Color.Transparent;

            cat.Controls.Add(Settings);
            Settings.BackColor = Color.Transparent;

            bar.Controls.Add(Fullscreen);
            Fullscreen.BackColor = Color.Transparent;

            cat.Controls.Add(Memory);
            Memory.BackColor = Color.Transparent;

            ChangeCursor();
        }

        void ChangeCursor()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.mouse_xs);
            Cursor c = new Cursor(bmp.GetHicon());
            this.Cursor = c;
        }
        private void cat_Click(object sender, EventArgs e)
        {
            //niets
        }

        private async void Exit_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            await Task.Delay(100);
            Application.Exit();
        }

        private void Fullscreen_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            Memory.Form3 f3 = new Memory.Form3();
            f3.Show();
        }

        private void bar_Click(object sender, EventArgs e)
        {
            //niets     
        }

        private async void Play_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            Memory.Form4 f5 = new Memory.Form4();
            f5.Show();
            await Task.Delay(100);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private async void Settings_Click(object sender, EventArgs e)
		{
			player.SoundLocation = "click.wav";
			player.Play();
			Memory.SettingsPage f6 = new Memory.SettingsPage();
			f6.Show();
			await Task.Delay(100);
			this.WindowState = FormWindowState.Minimized;
			this.ShowInTaskbar = false;
		}

		private void Load_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            //naar form van opgeslagen spellen
        }

        private void Highscore_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            //naar form van highscores
        }

    }
}
