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

        private int CandidateCount;

        public RelatMajorMethod(int candidateCount)
        {
            ALPHABET = Alphabet.value;
            ListVote = new List<int>();
            ListAlt = new List<string>();
            CandidateCount = candidateCount;
        }

        public bool EnumAllAlter()
        {
            ListAlt.Clear();
            for (int i = 0; i < CandidateCount; i++)
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
