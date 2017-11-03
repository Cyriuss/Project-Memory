﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Memory
{
	public partial class SettingsPage : Form
	{
        //commands voor het aanpassen van systeemgeluid
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
		private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
		private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xE0000;
		private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public static string SetValueForComboBox = "";
		System.Media.SoundPlayer player = new System.Media.SoundPlayer();
		public SettingsPage()
		{
			InitializeComponent();

            ThemaBox.SelectedIndex = 0;

            ChangeCursor();
		}
        
        //Veranderen van de Mousecursor
        void ChangeCursor()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.cur1031);
            Cursor c = new Cursor(bmp.GetHicon());
            this.Cursor = c;
        }

        //Het teruggaan naar het Hoofdmenu
		private async void HomeButton_Click_1(object sender, EventArgs e)
		{
			player.SoundLocation = "click.wav";
			player.Play();
			await Task.Delay(300);
			player.Stop();
			this.ShowInTaskbar = false;
            this.Close();
            this.Dispose();
            GC.Collect();
        }

        //Toepassen van het gekozen thema uit de combobox
		public async void Apply_Click(object sender, EventArgs e)
		{
            player.SoundLocation = "click.wav";
			player.Play();
            string thema = ThemaBox.SelectedItem.ToString();      
            Memory.SettingsPage_Save.SaveData(thema);
            MessageBox.Show("Thema is succesvol toegepast");
            await Task.Delay(300);
            player.Stop();
		}

        //magische code
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

        //event die de HomePage herstart bij het afluiten van de Settingspage
		private async void SettingsPage_FormClosed(object sender, FormClosedEventArgs e)
		{
			Memory.HomePage f13 = new Memory.HomePage();
			f13.Show();
			await Task.Delay(100);
            this.Close();
            this.Dispose();
            GC.Collect();
        }

        //volume verlagen
		private void VolumeDown_Click(object sender, EventArgs e)
		{
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);

        }

        //volume verhogen
        private void VolumeUp_Click(object sender, EventArgs e)
		{
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        //Het terugkeren naar het Hoofdmenu. alweer?
        private async void Home_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            await Task.Delay(300);
            player.Stop();
            this.Close();
        }

        //volume dempen
        private void MuteButton_Click(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void ServerDebug_Click(object sender, EventArgs e)
        {
            Memory.GameServer g1 = new Memory.GameServer();
            g1.Show();
        }

        private void RunningInThe90sButton_Click(object sender, EventArgs e)
        {
            Memory.RunningInThe90s inThe90S = new Memory.RunningInThe90s();
            inThe90S.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Memory.intro intro = new Memory.intro();
            intro.Show();
        }

        //geluiden uitschakelen
		private void StopMusicButton_Click(object sender, EventArgs e)
		{
			SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
				(IntPtr)APPCOMMAND_MEDIA_PLAY_PAUSE);
		}
	}
}
