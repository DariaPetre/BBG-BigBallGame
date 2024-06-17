using BBG_BigBallGame.BallsType;
using BBG_BigBallGame.BallTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBG_BigBallGame
{
    public partial class Form1 : Form
    {   
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Height = Height;
            pictureBox1.Width = Width;
            pictureBox1.BackColor = Color.Aqua;
            Engine.Initialize();
            Engine.Draw();
            
        }
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for(int i = 0; i < Engine.balls.Count; i++) 
            {   
                Ball ball = Engine.balls[i];
                if(ball is RegularBall)
                {   
                    RegularBall.Collision(i);
                    ball.Move();  
                }
                else if(ball is RepellentBall)
                {
                    RepellentBall.Collision(i);
                    ball.Move();
                }
            }
            
           Engine.Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
