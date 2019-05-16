using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashFireGame
{
    public partial class gameArea : Form
    {

        int ct = 1,y=1;

        public gameArea()
        {
            InitializeComponent();
            fireBtn.Enabled = false;
            btnSpin.Enabled = false;
        }

        private void gameArea_Load(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //click on the play button to play the game using gun
            if (nmBullet.Value == 0)
            {
                MessageBox.Show("First Fill the No of Bullet to load in the Gun");
            }
            else if (nmBullet.Value == 1)
            {
                //load the nxt image 
                pbGun.ImageLocation = "img/one.jpg";
                btnSpin.Enabled = true;
            }
            else if (nmBullet.Value == 2)
            {
                pbGun.ImageLocation = "img/two.jpg";
                btnSpin.Enabled = true;
            }
            else {

            }
            
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            //this method is used to load the image in the picture box for starting the game 
            if (nmBullet.Value > 0) {
                pbGun.ImageLocation = "img/fullloaded.jpg";
                fireBtn.Enabled = true;
            }


        }

        private void btnPlyAgain_Click(object sender, EventArgs e)
        {
            //after completing the game this method is used to restart the game from the strting stage
            pbGun.ImageLocation = "img/emptyGun.jpg";
            ct = 1;
            y = 1;
            //disable the button so thus further functionality will work 
            btnSpin.Enabled = false;
            fireBtn.Enabled = false;
            nmBullet.Value = 0;
        }

        private void fireBtn_Click(object sender, EventArgs e)
        {
            int emptyShot = 0;
            // this method is used to fire the gun and generate the sound
            if (ct <= nmBullet.Value && y == ct)
            {
                ct++;
                pbGun.ImageLocation = "img/fire.jpg";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("img/sund.wav");
                player.Play();
                // genrerate the sound with the use of random class
                Random rd = new Random();
                y = rd.Next(2, 4);
                if (ct == y)
                {
                    MessageBox.Show("You won the game and your score is-" + y);
                }

            }
            else {
                // generate the empty trigger sound when bullet is not available
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("img/Empty.wav");
                player.Play();
                emptyShot++;
            }

            if (emptyShot==6)
            {
                MessageBox.Show("you lose the game ");
                 
            }
        }
    }
}
