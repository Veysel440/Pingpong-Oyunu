using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string yatayYon = "sag";
        string dikeyYon = "ust";
        int topHiz = 10;
        int solSkor = 0, sagSkor=0;
        Random rnd = new Random();
        int RasgeleSayi;
        private void button1_Click(object sender, EventArgs e)
        {
            RasgeleSayi = rnd.Next(2);
            timer1.Enabled = true;
            label3.Text = "0";
            label4.Text = "0";
            button1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dikeyYon=="ust"){
                pbTop.Top = pbTop.Top - 10;
            }

            if (dikeyYon == "alt")
            {
                pbTop.Top = pbTop.Top + 10;
            }


            if (yatayYon == "sol")
            {
                pbTop.Left = pbTop.Left - topHiz;
            }

            if (yatayYon == "sag")
            {
                pbTop.Left = pbTop.Left + topHiz;
            }
            
            if (pbTop.Top <= 0)
            {
                dikeyYon = "alt";
            }

            if (pbTop.Top >= 340)
            {
                dikeyYon = "ust";
            }

            if (pbTop.Top >= pbSolR.Top && pbTop.Top<=pbSolR.Top+pbSolR.Height){
                if (pbTop.Left==10){
                    yatayYon = "sag";
                }
            }

            if (pbTop.Top >= pbSagR.Top && pbTop.Top <= pbSagR.Top + pbSagR.Height)
            {
                if (pbTop.Left == 520)
                {
                    yatayYon = "sol";
                }
            }

            if (pbTop.Left < 10)
            {
                solSkor++;
                sayiOldu();
                baslat();
            }

            if (pbTop.Left > 520)
            {
                sagSkor++;
                sayiOldu();
                baslat();
            }

          


        }


        public void sayiOldu(){
            

            topHiz = ((sagSkor+solSkor)/5+1)*10;
            label3.Text = solSkor.ToString();
            label4.Text = sagSkor.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            baslat();
        }

        public void baslat()
        {
            pbTop.Location = new Point(240, 150);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                if (pbSagR.Top >= 10)
                {
                    pbSagR.Top = pbSagR.Top - 10;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (pbSagR.Top <= 260)
                {
                    pbSagR.Top = pbSagR.Top + 10;
                }
            }


            if (e.KeyCode == Keys.A)
            {
                if (pbSolR.Top >= 10)
                {
                    pbSolR.Top = pbSolR.Top - 10;
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                if (pbSolR.Top <= 260)
                {
                    pbSolR.Top = pbSolR.Top + 10;
                }
            }
        }
    }
}
