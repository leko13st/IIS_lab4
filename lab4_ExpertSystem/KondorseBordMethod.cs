using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    class KondorseBordMethod : IMethod
    {
        string ALPHABET { get; set; } //Алфаваит, чтобы указать альтернативу
        public List<string> ListAlt { get; }
        public List<int> ListVote { get; }

        public KondorseBordMethod()
        {
            ALPHABET = Alphabet.value;
            ListVote = new List<int>();
            ListAlt = new List<string>();
        }

        public bool EnumAllAlter(int candidateCount)
        {
            int cnt = candidateCount;
            string s = null;
            List<int> cnt_list = new List<int>();

            for (int i = 0; i < candidateCount; i++)
            {
                s += ALPHABET[0];
                cnt_list.Add(0);
            }

            while (true)
            {
                if (ValidValue(s))
                {
                    string str = null;
                    for (int i = 0; i < candidateCount; i++)
                        if (i != 0)
                            str += " > " + s[i];
                        else str += s[i];
                    ListAlt.Add(str);
                }

                if (IncrementMethod(cnt - 1))
                    return true;

                bool IncrementMethod(int index)
                {
                    cnt_list[index]++;
                    if (cnt_list[index] == cnt)
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

        public string PrintAnswer()
        {
            string s = AnswerByKondorse() + AnswerByCopeland() + AnswerBySimpson();
            return s;
        }

        string AnswerByKondorse()
        {
            string ans = null;

            return ans;
        }

        string AnswerByCopeland()
        {
            string ans = null;

            return ans;
        }

        string AnswerBySimpson()
        {
            string ans = null;

            return ans;
        }
    }
}
