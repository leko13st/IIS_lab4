using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    //Класс по выводу ответа по методу Копленда
    class AnswerByCopeland : Answer
    {
        public AnswerByCopeland(List<string> listAlt, List<int> listVote, int candidateCount) : base(ListAlt: listAlt, ListVote: listVote, CandidateCount: candidateCount)
        {
            ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);
        }

        public override string GetAnswer()
        {
            string ans = "[Метод Копленда]\r\n";
            for (int i = 0; i < CandidateCount; i++)
            {
                for (int j = 0; j < CandidateCount; j++)
                    if (i != j)
                        CompareAlter(i, j);
                ans += ALPHABET[i] + " = " + ListScore[i] + "\r\n";
            }
            ans += "Ответ: " + Answer() + "\r\n\r\n";
            return ans;

            bool CompareAlter(int X, int Y)
            {
                int sum = 0;
                int CountVotes = ListVote.Sum();

                for (int i = 0; i < ListAlt.Count; i++)
                {
                    if (ListAlt[i].IndexOf(ALPHABET[X].ToString()) < ListAlt[i].IndexOf(ALPHABET[Y].ToString()))
                        sum += ListVote[i];
                }
                if (sum > (CountVotes - sum))
                    ListScore[X]++;
                else if (sum < (CountVotes - sum))
                    ListScore[X]--;
                return true;
            }

            string Answer()
            {
                string s = null;
                int cnt = ListScore.Count;
                int max = ListScore.Max();
                int min = ListScore.Min();
                for (int i = 0; i < cnt; i++)
                {
                    if (i != 0)
                    {
                        if (max == ListScore.Max())
                            s += " = ";
                        else
                            s += " > ";
                    }
                    s += ALPHABET[ListScore.IndexOf(ListScore.Max())];
                    max = ListScore.Max();
                    ListScore[ListScore.IndexOf(max)] = min - 1;
                }
                return s;
            }
        }
    }
}
