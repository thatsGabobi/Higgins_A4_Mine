using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Lab5
{
    public partial class Form1 : Form
    {
        /* Name: Alex higgins
           Date: december, 3, 2022
           This program is used for working with loops and random numbers*/
        
        public Form1()
        {
            InitializeComponent();
        }

        const string PROGRAMMER = "Alex Higgins";
        int Counter = 0;
        /* creats random number */
        private int Getrandom(int min, int max)
        {
            Random rand = new Random();
            int Password = rand.Next(min, max);
            return Password;
        }

        /* set range for random number and sets properties to be exicuted on lunch */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += "" + PROGRAMMER;
            grpText.Visible = false;
            grpStats.Visible = false;
            grpChoose.Visible = false;
            txtCode.Focus();
            lblCode.Text = Getrandom(100000, 200001).ToString();

        }
        /* Login click compares the authentication code */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (lblCode.Text != txtCode.Text)
            {
                Counter = Counter + 3;
                if (Counter < 3)
                {
                    MessageBox.Show("You have a total of three guesses. \n guesses used: " + Counter);
                    txtCode.Text = "";
                    txtCode.Focus();
                }
            }
           
            else
            {
                grpLogin.Enabled = false;
                grpChoose.Visible = true;
            }
            if (Counter >= 3)
            {
                MessageBox.Show("Guesses have surpassed given amount closing applucation");
                this.Close();
            }
     
        }
        /* function to reset grptext */
        private void ResetTextGrp()
        {
            txtString1.Text = "";
            txtString1.Focus();
            txtString2.Text = "";
            chkSwap.Checked = false;
            lblResults.Text = "";
            this.AcceptButton = btnJoin;
            this.CancelButton = btnReset;

        }
        /* function to reset grpstats */
        private void ResetStatsGrp
        {
            lblSum.Text = "";
            lblMean.Text = "";
            lblOdd.Text = "";
            lstNum.Items.Clear();
            this.AcceptButton = bntGenerate;
            this.CancelButton = bntClear;
        }
        /* function to switch views from radio buttons */
        private void SetupOption()
        {
            if (radText.Checked)
            {
                grpStats.Hide();
                grpText.Show();
                ResetTextGrp();
            }
            else if(radStats.Checked)
            {
                grpText.Hide();
                grpStats.Show();
                ResetTextGrp();
            }
        }
        /* calling functions */
        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }
        private void radStats_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextGrp();
        }
        private void bntClear_Click(object sender, EventArgs e)
        {
            ResetStatsGrp();
        }
        /* swapping two workds inside grptext */
        private void Swap(ref string word1, ref string word2)
        {
            string placeHolder = word1;
            word1 = word2;
            word2 = placeHolder;
            txtString1.Text = word1
            txtString2.Text = word2;
        }
        private bool CheckInput()
        {
            if (txtString1 != null && txtString2 != null)
            {
                return true
            }
            else { return false; }
        }
        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSwap.Checked && CheckInput() == true)
            {
                string word1 = txtString1.Text;
                string word2 = txtString2.Text;
                Swap(ref word1, ref word2);
                CheckInput();
                lblResults.Text = "Fisrt string = " + word1 + "\n" + "Second string = " + word2 + "\n" + "Joined = " + word1 + word2;

            }
        }
        /* joining words  that were swapped */
        private void btnJoin_Click(object sender, EventArgs e)
        {
            if(CheckInput() == true)
            {
                lblResults.Text = "First string = " + txtString1.Text + "\n Second string = " + txtString2.Text + "\n Joined = " + txtString2.Text + txtString1.Text;
            }
        }
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!CheckInput() == true)
            {
                lblResults.Text = "First string = " + txtString1.Text + "\n Characters check= " + txtString1.TextLength + "\n Second string = " + txtString2.TextLength;
            }
        }
        /* event to generate list of random numbers */
        private void bntGenerate_Click(object sender, EventArgs e)
        {
            Random gengerateRandom = new Random(733);
            lstNum.Items.Clear();

            for (int count2 = 1; count2 <= nudCounter.Value;)
            {
                lstNum.Items.Add(gengerateRandom.Next(1000, 5001));
                count2++;
            }
            lblSum.Text = Addlist().ToString();
            double mean = Addlist() / lstNum.Items.Count;
            lblMean.Text = lblMean.ToString();
            lblOdd.Text = CountOdd().ToString();
        }

        /* I now know click + enter will make a event for you */
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        /* creating a function for list */
        private int Addlist()
        {
            int count = 0, sum = 0, numbers;
            while (count < nudCounter.Value)
            {
                numbers = Convert.ToInt32(lstNum.Items[count++]);
                sum += numbers;
            }
            return sum;
        }
        private int CountOdd()
        {
            int numbers, count = 0, odds = 0;
            do
            {
                numbers = Convert.ToInt32(lstNum.Items[count++]);
                if(numbers % 2 != 0)
                    {
                        odds++;
                    }
            }while (count < nudCounter.Value);
            return odds;
        }
    }
}
