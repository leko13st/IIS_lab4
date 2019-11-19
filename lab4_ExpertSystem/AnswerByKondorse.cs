using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    //Класс по выводу ответа по методу Кондорсе
    class AnswerByKondorse : Answer
    { 
        public AnswerByKondorse(List<string> listAlt, List<int> listVote, int candidateCount) : base(ListAlt: listAlt, ListVote: listVote, CandidateCount: candidateCount)
        {
            ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);
        }

        public override string GetAnswer()
        {
            string ans = "[Метод Кондорсе]\r\n";
            for (int i = 0; i < CandidateCount; i++)
                for (int j = i + 1; j < CandidateCount; j++)
                    ans += CompareAlter(i, j);

            ans += "Ответ: " + Result() + "\r\n\r\n";
            return ans;

            string CompareAlter(int X, int Y)
            {
                int CountVotes = ListVote.Sum();

                int X_Votes = 0;
                for (int i = 0; i < ListAlt.Count; i++)
                {
                    if (ListAlt[i].IndexOf(ALPHABET[X].ToString()) < ListAlt[i].IndexOf(ALPHABET[Y].ToString()))
                        X_Votes += ListVote[i];
                }

                char symbol;
                if (X_Votes > (CountVotes - X_Votes))
                {
                    symbol = '>';
                    ListScore[X]++;
                }
                else if (X_Votes < (CountVotes - X_Votes))
                {
                    symbol = '<';
                    ListScore[Y]++;
                }
                else
                    symbol = '=';

                string s = ALPHABET[X] + " " + symbol + " " + ALPHABET[Y] + " : " + X_Votes + " " + symbol + " " + (CountVotes - X_Votes) + "\r\n";
                return s;
            }

            string Result()
            {
                List<int> list_temp = new List<int>();
                for (int i = 0; i < ListScore.Count; i++)
                {
                    list_temp.Add(ListScore[i]);
                }
                list_temp.Sort();

                for (int i = 0; i < list_temp.Count; i++)
                    if (list_temp[i] > i)
                        return "Парадокс Кондорсе!";
                    else if (i != 0)
                        if (list_temp[i] != list_temp[i - 1] && list_temp[i] != i)
                            return "Парадокс Кондорсе!";

                string s = null;
                int cnt = ListScore.Count;
                int max = ListScore.Max();
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
                    ListScore[ListScore.IndexOf(max)] = -1;
                }

                return s;
            }
        }
    }
}
