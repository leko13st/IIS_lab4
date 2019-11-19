using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    class KondorseBordMethod : IMethod
    {
        private string ALPHABET { get; set; } //Алфавит, чтобы указать альтернативу
        public List<string> ListAlt { get; }
        public List<int> ListVote { get; }
        private int CandidateCount { get; }

        public KondorseBordMethod(int candidateCount)
        {
            ALPHABET = Alphabet.value;
            ListVote = new List<int>();
            ListAlt = new List<string>();
            CandidateCount = candidateCount;
        }

        public bool EnumAllAlter() //Метод по перечислению всех альтернатив
        {
            string s = null;
            List<int> cnt_list = new List<int>();

            for (int i = 0; i < CandidateCount; i++)
            {
                s += ALPHABET[0];
                cnt_list.Add(0);
            }

            while (true)
            {
                if (ValidValue(s))
                {
                    string str = null;
                    for (int i = 0; i < CandidateCount; i++)
                        if (i != 0)
                            str += " > " + s[i];
                        else str += s[i];
                    ListAlt.Add(str);
                }

                if (IncrementMethod(CandidateCount - 1))
                    return true;

                bool IncrementMethod(int index)
                {
                    cnt_list[index]++;
                    if (cnt_list[index] == CandidateCount)
                    {
                        if (index == 0)
                            return true;
                        if (IncrementMethod(index - 1)) return true;
                        cnt_list[index] = 0;
                    }
                    s = s.Remove(index, 1).Insert(index, ALPHABET[cnt_list[index]].ToString());
                    return false;
                }
            }

            bool ValidValue(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[i] == str[j])
                            return false;
                    }
                }
                return true;
            }
        }

        //Вывод ответа
        public string PrintAnswer() 
        {
            string s = null;
            Answer Ans = null;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    Ans = new AnswerByKondorse(ListAlt, ListVote, CandidateCount);
                if (i == 1)
                    Ans = new AnswerByCopeland(ListAlt, ListVote, CandidateCount);
                if (i == 2)
                    Ans = new AnswerBySimpson(ListAlt, ListVote, CandidateCount);
                if (i == 3)
                    Ans = new AnswerByBord(ListAlt, ListVote, CandidateCount);

                s += Ans.GetAnswer();
            }
            return s;
        }
    }
}
