using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class form1 : Form
    {
        // Create a Random object to generate random numbers
        Random randomizer = new Random();
        int addend1;
        int addend2;
        // tiempo restante
        int timeleft;
        public form1()
        {
            InitializeComponent();

        }
        private void iniciarQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            suma.Value = 0;
            this.timeleft = 30;
            this.timelabel.Text = "30 Segundos";
            timer1.Start();

        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            this.iniciarQuiz();
            this.startbutton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkearRespuesta())
            {
                timer1.Stop();
                MessageBox.Show("Todas las Respuestas Correctas!", "completado");
                startbutton.Enabled = true;

            }
            else if (timeleft > 0)
            {
                // Se puede usar timeleft --
                timeleft = timeleft - 1;
                timelabel.Text = timeleft + " seconds";
            }
            else
            {
                timer1.Stop();
                timelabel.Text = "time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                suma.Value = addend1 + addend2;
                this.startbutton.Enabled = true;
            }
        }
        private bool checkearRespuesta()
        {
            if (addend1 + addend2 == suma.Value)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void suma_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);

            }
        }
    }
}