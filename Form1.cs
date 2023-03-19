using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = DiscordRPC.Button;

namespace Killers_Discord_RPC_V1
{
    public partial class Form1 : Form
    {
        private string configPath = ".\\Extras\\DCRPC\\config.txt";

        public DiscordRpcClient client;

        private string helppath = ".\\Extras\\DCRPC\\Help\\help.mp4";
        

        public Form1()
        {
            InitializeComponent();

            readconfig();
        }



        private void readconfig()
        {
            if (File.Exists(configPath))
            {
                StreamReader streamReader = new StreamReader(configPath);
                string text = streamReader.ReadToEnd();
                streamReader.Close();
                string[] array = text.Split('\n');

                client = new DiscordRpcClient(array[0]); https://www.youtube.com/watch?v=dQw4w9WgXcQ
                client.Initialize();
                DiscordRpcClient obj = client;
                RichPresence val = new RichPresence();

                try
                {
                    val.Details = array[1];
                    val.State = array[2];

                }
                catch
                {

                }
                
               
                try
                {

                    val.Buttons = new Button[]
                    {
                        new Button() { Label = array[7], Url = array[8] }
                    };


                    //new Button() { Label = array[7], Url = array[8] };
                }
                catch
                {

                }
                val.Timestamps = Timestamps.Now;
                Assets val2 = new Assets();
                val2.LargeImageKey = array[3];
                val2.LargeImageText = array[4];
                val2.SmallImageKey = array[5];
                val2.SmallImageText = array[6];
                val.Assets = val2;
                obj.SetPresence(val);

                try
                {
                    textBox1.Text = array[0];
                    textBox2.Text = array[1];
                    textBox3.Text = array[2];
                    textBox4.Text = array[3];
                    textBox5.Text = array[4];
                    textBox6.Text = array[5];
                    textBox7.Text = array[6];
                    try
                    {
                        textBox8.Text = array[7];
                        textBox9.Text = array[8];
                    }
                    catch
                    {


                    }
                    
                }
                catch
                {

                }







            }
            else
            {
                client = new DiscordRpcClient("1070009013963599932");
                client.Initialize();
                DiscordRpcClient obj = client;
                RichPresence val = new RichPresence();
                val.Details = "♥ Download on my Discord ♥";
                val.State = "discord.gg/Rfspz3cywf";
                val.Buttons = new Button[]
                {
                    new Button() { Label = "Join Now", Url = "https://discord.gg/67WFCMb6" }
                };
                //val.Buttons() { Label = "Join Now", Url = "https://discord.gg/67WFCMb6" };
                val.Timestamps = Timestamps.Now;
                Assets val2 = new Assets();
                val2.LargeImageKey = "bigpicture";
                val2.LargeImageText = "LoseMyXelf#7777";
                val2.SmallImageKey = "littlepicture";
                val2.SmallImageText = "♥ Version 1.0 ♥";
                val.Assets = val2;
               
                obj.SetPresence(val);
            }
        }



        private void writeconfig()
        {
            TextWriter textWriter = new StreamWriter(configPath);
            textWriter.Write(textBox1.Text + "\n" + textBox2.Text + "\n" + textBox3.Text + "\n" + textBox4.Text + "\n" + textBox5.Text + "\n" + textBox6.Text + "\n" + textBox7.Text + "\n" + textBox8.Text + "\n" + textBox9.Text + "\n");
            textWriter.Close();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (File.Exists(configPath))
            {
                string mes = "Config Found\nDo you want to overwrite?";
                DialogResult dialogResult = MessageBox.Show(mes, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    writeconfig();

                    string me = "Sucessfully Overwritten";
                    string ms = "Config Saved";
                    MessageBox.Show(me, ms);
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
            {
                string mes = "No Config Found\nDo you want to Create one?";
                DialogResult dialogResult = MessageBox.Show(mes, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    writeconfig();
                    string m = "Sucessfully Config Created";
                    string s = "Config Saved";
                    MessageBox.Show(m, s);
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
        }

        private void configdelete_Click(object sender, EventArgs e)
        {
            if (File.Exists(".\\Extras\\DCRPC\\config.txt"))
            {
                try
                {
                    File.Delete(".\\Extras\\DCRPC\\config.txt");

                    string mes2 = "Config successfully deleted!\nDo you want to Restart the Application?";

                        DialogResult dialogResult = MessageBox.Show(mes2, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                        Application.Restart();
                        }
                        else
                        {

                        }
                    
                }
                catch
                {

                }

            }
            else
            {
                string mes = "Error 404 \nRPC config not found";

                DialogResult dialogResult = MessageBox.Show(mes, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string help = "If you need help with that Feature pls\nwatch this mp4 before u Texting\nan Admin or me. Thanks ♥";

            DialogResult dialogResult = MessageBox.Show(help, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                Process.Start(helppath);
            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }
        }
    }
}
