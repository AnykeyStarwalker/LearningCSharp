using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;
using System.Media;
using System.Threading;

namespace Lesson11_winform
{
    public partial class Form1 : Form
    {
        // # ← ⬉ ↑ ⬈ → ⬊ ↓ ⬋ ↔ ↕ ⇆ ⇅    
        Dictionary<string, bool> state = new Dictionary<string, bool>()
        {
            { "Right_Down", false },
            { "Left_Down", false},
            { "A_Down", false},
            { "B_Down", false},
            { "Options_Down", false},
            { "NewPet_Down", false}
        };

        public int xCoordBack = -1228;
        public Mammalis pet = new Mammalis();
        public Bitmap UISkin = Resource1.UI_tamagochi,
                      BackGround = Resource1.back,
                      AnimalImg = Resource1.pig_walk;

        private SoundPlayer player;
        private SoundPlayer buttSound;

        public Form1()
        {
            InitializeComponent();            
            pet.Init();

            player = new SoundPlayer(Resource1.track1);
            buttSound = new SoundPlayer(Resource1.butt_click);

            pEat.Value = (int)pet.eat;
            pHappy.Value = (int)pet.happy;
            pAge.Value = pet.age;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pet.Update(state);
            Refresh();
        }
        private void Form1_paint(object sender, PaintEventArgs e) 
        { 
            Graphics g = e.Graphics;

            g.DrawImage(pet.background, new Rectangle(pet.backXcoord, 64, 1920, 320));
            g.DrawImage(pet.skin, new Rectangle(336, 215, 128, 128));
            g.DrawImage(UISkin, new Rectangle(0, 0, 800, 462));

            pEat.Value = (int)pet.eat;
            pHappy.Value = (int)pet.happy;
            pAge.Value = pet.age;
            labelXcoord.Text = pet.backXcoord.ToString();
            stateLabel.Text = pet.state;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked) 
            {                
                checkBox1.BackgroundImage = Resource1.ButtonSmallOn;
                buttSound.Play();
                player.Play();
            }
            else {
                checkBox1.BackgroundImage = Resource1.ButtonSmall;
                buttSound.Play();

            }
        }


        private void buttNewPet_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void buttOptions_MouseClick(object sender, MouseEventArgs e)
        {
        
        }

        private void buttNewPet_MouseDown(object sender, MouseEventArgs e)
        {
            buttNewPet.BackgroundImage = Resource1.ButtonSmallOn;
        }

        private void buttNewPet_MouseUp(object sender, MouseEventArgs e)
        {
            buttNewPet.BackgroundImage = Resource1.ButtonSmall;
        }

        private void buttRight_MouseDown(object sender, MouseEventArgs e)
        {
            buttRight.BackgroundImage = Resource1.ButtonBigOn;
            state["Right_Down"] = true;
        }

        private void buttRight_MouseUp(object sender, MouseEventArgs e)
        {
            buttRight.BackgroundImage = Resource1.ButtonBig;
            state["Right_Down"] = false;
        }

        private void buttLeft_MouseDown(object sender, MouseEventArgs e)
        {
            buttLeft.BackgroundImage = Resource1.ButtonBigOn;
            state["Left_Down"] = true;
        }

        private void buttLeft_MouseUp(object sender, MouseEventArgs e)
        {
            buttLeft.BackgroundImage = Resource1.ButtonBig;
            state["Left_Down"] = false;
        }

        private void buttB_MouseDown(object sender, MouseEventArgs e)
        {
            buttB.BackgroundImage = Resource1.ButtonBigOn;
            state["B_Down"] = true;
        }

        private void buttB_MouseUp(object sender, MouseEventArgs e)
        {
            buttB.BackgroundImage = Resource1.ButtonBigOn;
            state["B_Down"] = false;
        }

        private void buttA_MouseDown(object sender, MouseEventArgs e)
        {
            buttA.BackgroundImage = Resource1.ButtonBigOn;
            state["A_Down"] = true;
        }

        private void buttA_MouseUp(object sender, MouseEventArgs e)
        {
            buttA.BackgroundImage = Resource1.ButtonBigOn;
            state["A_Down"] = false;
        }

    }
}
