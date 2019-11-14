using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    class RelatMajorMethod : IMethod
    {
        string ALPHABET { get; set; } //Алфаваит, чтобы указать альтернативу
        public List<string> ListAlt { get; }
        public List<int> ListVote { get; }

        public RelatMajorMethod()
        {
            ALPHABET = Alphabet.value;
            ListVote = new List<int>();
            ListAlt = new List<string>();
        }

        public bool EnumAllAlter(int candidateCount)
        {
            ListAlt.Clear();
            for (int i = 0; i < candidateCount; i++)
            {
                ListAlt.Add(ALPHABET[i].ToString());
            }
            return true;
        }

        public string PrintAnswer()
        {
            string ans = "Победила альтернатива(ы): ";
            for (int i = 0; i < ListAlt.Count; i++)
            {
                if (ListVote[i] == ListVote.Max())
                {
                    if (i != 0)
                        ans += ", ";
                    ans += ListAlt[i];
                }
            }
            ans += " с кол-ом голосующих: " + ListVote.Max();
            return ans;
        }
    }
}
