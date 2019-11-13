using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_ExpertSystem
{
    public partial class SystemVote : Form
    {
        public SystemVote()
        {
            InitializeComponent();
        }
        int VoterCount { get; set; }
        int CandidateCount { get; set; }
        VoteHandler vh = null;

        enum method { RelativeMajority, Kondorse_Bord}
        method CurrentMethod = method.RelativeMajority;

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool ValidVoterCount()
        {
            try
            {
                VoterCount = Convert.ToInt32(textBox1.Text);
                return true;
            }
            catch { return false; }
        }

        bool ValidCandidateCount()
        {
            try
            {
                CandidateCount = Convert.ToInt32(textBox2.Text);
                return true;
            }
            catch { return false; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ValidVoterCount() && ValidCandidateCount())
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (ValidVoterCount() && ValidCandidateCount())
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            State(true);
            vh = new VoteHandler();
            if (CurrentMethod == method.RelativeMajority)
                vh.CreateAlternative(CandidateCount, 0);
            else 
                vh.CreateAlternative(CandidateCount, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            State(false);
        }
        
        void State(bool Apply)
        {
            button2.Enabled = Apply;
            button1.Enabled = !Apply;
            textBox1.Enabled = !Apply;
            textBox2.Enabled = !Apply;

            if (!Apply) dataGridView1.Rows.Clear();
        }

        private void относительноеБольшинствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMethod = method.RelativeMajority;
            Text = "SystemVote [" + CurrentMethod.ToString() + "]";
        }

        private void кондорсеБордToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMethod = method.Kondorse_Bord;
            Text = "SystemVote: [" + CurrentMethod.ToString() + "]";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // vh.SendVote(i);
        }
    }
}
