using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab4_ExpertSystem
{
    public partial class SystemVote : Form
    {
        public SystemVote()
        {
            InitializeComponent();
            //comment for test1 commit
            Text = "SystemVote: [" + CurrentMethod.ToString() + "]";
        }
        int VoterCount { get; set; } //Кол-во голосующих
        int CandidateCount { get; set; } //Кол-во кандидатов
        int PreferCount { get; set; } //Кол-во предпочтений
        int voter_num { get; set; } //Текущий голосующий

        VoteHandler vh = null; //Класс-обработка

        enum method { RelativeMajority, Kondorse_Bord } //Список методов по решению задач
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
            if (ValidVoterCount() && ValidCandidateCount()) //Проверка на корректные значения в текстбоксах
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (ValidVoterCount() && ValidCandidateCount()) //Проверка на корректные значения в текстбоксах
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) //Кнопка принятия настроек
        {
            State(true);
            vh = new VoteHandler();

            //создаём в классе-обработчике все возможные альтернативы
            if (CurrentMethod == method.RelativeMajority)
                vh.CreateAlternative(CandidateCount, 0); 
            else if (CurrentMethod == method.Kondorse_Bord)
                vh.CreateAlternative(CandidateCount, 1);

            PrintPrefer(vh.GetListAlt()); //Выводим в datagridview1 все предпочтения
            label1.Text = 1 + " голосующий из " + VoterCount + " голосующих";
            voter_num = 0;
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

            if (!Apply)
            {
                dataGridView1.Rows.Clear();
                textBox3.Text = null;
            }
        }

        private void относительноеБольшинствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMethod = method.RelativeMajority;
            Text = "SystemVote: [" + CurrentMethod.ToString() + "]";
        }

        private void кондорсеБордToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMethod = method.Kondorse_Bord;
            Text = "SystemVote: [" + CurrentMethod.ToString() + "]";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Выбор определённой альтернативы
        {
            if (voter_num != VoterCount)
            {
                label1.Text = (++voter_num + 1) + " голосующий из " + VoterCount + " голосующих";
                for (int j = 0; j < PreferCount; j++)
                    if (isSelected(j))
                        break;

                if (voter_num == VoterCount)
                {
                    label1.Text = "Все голосующие сделали выбор!";
                    textBox3.Text += vh.Answer();
                }

                bool isSelected(int index)
                {
                    if (dataGridView1[0, index].Selected)
                    {
                        vh.SendVote(index); //Отправка в класс-обработчик выбранную альтернативу за определённого голосующего
                        return true;
                    }
                    return false;
                }
            }
        }

        bool PrintPrefer(List<string> list) //Выводим в datagridview1 все предпочтения
        {
            PreferCount = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows.Add("Выбрать");
                dataGridView1[1, i].Value = list[i];
            }
            return true;
        }
    }
}
