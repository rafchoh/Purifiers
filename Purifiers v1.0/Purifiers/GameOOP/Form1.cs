using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
/*   
 *   РАФЕТ-ХАЛИЛ_СОФТУЕРНО-ИНЖЕНЕРСТВО_1курс_ФАК.No:1901321052
 * 
 */
namespace GameOOP
{
    public partial class Purifiers : Form
    {
        bool goLeft;
        bool goRight;

        int pSpeed = 12;
        int zSpeed;

        int score;

        int zBulletTimer;

        PictureBox[] zergSArray;

        bool shooting;
        bool isGameOver;
        bool shield = false;

        byte counter = 6;


        public Purifiers()
        {
            InitializeComponent();
            gameSetup();
        }

        private void gameSetup()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            isGameOver = false;

            zBulletTimer = 300;
            zSpeed = 5;
            shooting = false;

            releaseZergs();
            gameTimer.Start();

            Timer.Start();
        }

        private void releaseZergs()
        {
            zergSArray = new PictureBox[16];

            int left = 0;

            for (int i = 0; i < zergSArray.Length; i++)
            {
                zergSArray[i] = new PictureBox();
                zergSArray[i].Size = new Size(60, 50);
                zergSArray[i].Image = Properties.Resources.zShip;
                zergSArray[i].Top = 5;
                zergSArray[i].Tag = "Zergs";
                zergSArray[i].Left = left;
                zergSArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(zergSArray[i]);
                left -= 80;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (shieldP.Value == 100 && e.KeyCode == Keys.Down)
            {
                shield = true;
                shieldT.Start();
                labelS.ForeColor = Color.White;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                makeBulletP("bullet");
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeAll();
                gameSetup();
                this.shieldP.Value = 0;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            } 
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = $"Score: {score}";

            if (goLeft)
            {
                player.Left -= pSpeed;
            }
            if (goRight)
            {
                player.Left += pSpeed;
            }

            zBulletTimer -= 10;

            if (zBulletTimer < 1)
            {
                zBulletTimer = 300;
                makeBullet("zBullet");
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "Zergs")
                {
                    x.Left += zSpeed;

                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver("You've been infested!");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1;
                                shooting = false;
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;

                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zBullet")
                {
                    x.Top += 20;

                    if (x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds) && !shield)
                    {
                        this.Controls.Remove(x);
                        gameOver("Your ship was destroyed by Zerg forces!");
                    }

                }
            }

            if (score > 8)
            {
                zSpeed = 12;
            }

            if (score == zergSArray.Length)
            {
                gameOver("Sector's been purified!");
            }
        }

        private void makeBulletP(string bulletTagP)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.pLazer;
            bullet.Size = new Size(15, 15);
            bullet.Tag = bulletTagP;
            bullet.Left = player.Left + player.Width / 2;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;

            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = player.Top - 20;
            }

            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void makeBullet(string bulletTag)
        {
            PictureBox zbullet = new PictureBox();
            zbullet.Image = Properties.Resources.zAttack;
            zbullet.Size = new Size(15, 15);
            zbullet.Tag = bulletTag;
            zbullet.Left = player.Left + player.Width / 2;
            zbullet.SizeMode = PictureBoxSizeMode.StretchImage;

            if ((string)zbullet.Tag == "zBullet")
            {
                zbullet.Top = -100;
            }
            this.Controls.Add(zbullet);
            zbullet.BringToFront();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.shieldP.Value += 1;
            if (shieldP.Value == 100 || isGameOver == true)
            {
                Timer.Stop();
                labelS.ForeColor = Color.White;
            }
        }

        private void shieldT_Tick(object sender, EventArgs e)
        {
            counter--;
            labelS.Text = "Shield left: " + counter;
            if (counter <= 0)
            {
                counter = 6;
                shield = false;
                this.shieldP.Value = 0;
                labelS.ForeColor = Color.Black;
                labelS.Text = "Use shield!!";
                shieldT.Stop();
            }
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text = $"Score: {score} {message}!";
        }
        
        private void removeAll()
        {
            foreach(PictureBox i in zergSArray)
            {
                this.Controls.Remove(i);
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                { 
                    if((string)x.Tag == "bullet" || (string)x.Tag == "zBullet")
                    {
                        this.Controls.Remove(x); 
                    } 
                }
            }
        }

        

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void Purifiers_Load(object sender, EventArgs e)
        {

        }
        private void labelS_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void shieldcountdown(object sender, EventArgs e)
        {

        }
    }
}
