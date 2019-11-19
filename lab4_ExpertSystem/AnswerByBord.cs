using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    //Класс по выводу ответа по методу Борда
    public class AnswerByBord : Answer
    {
        public AnswerByBord(List<string> listAlt, List<int> listVote, int candidateCount) : base(ListAlt: listAlt, ListVote: listVote, CandidateCount: candidateCount)
        {
            ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);
        }
        public override string GetAnswer()
        {
            try
            {
                string ans = "[Метод Борда]\r\n";
                for (int i = 0; i < CandidateCount; i++)
                {
                    CompareAlter(i);
                    ans += ALPHABET[i] + " = " + ListScore[i] + "\r\n";
                }
                ans += "Ответ: " + Answer() + "\r\n";
                return ans;

                bool CompareAlter(int X)
                {
                    List<string> list_tmp = new List<string>();
                    for (int i = 0; i < ListAlt.Count; i++)
                        list_tmp.Add(ListAlt[i]);

                    for (int i = 0; i < list_tmp.Count; i++)
                    {
                        for (int j = 0; j < list_tmp[i].Length; j++)
                            if (list_tmp[i][j] == ' ' || list_tmp[i][j] == '>')
                            {
                                list_tmp[i] = list_tmp[i].Remove(j--, 1);
                            }

                        string s = null;
                        for (int c = list_tmp[i].Length - 1; c >= 0; c--)
                            s += list_tmp[i][c];
                        list_tmp[i] = s;

                        ListScore[X] += ListVote[i] * list_tmp[i].IndexOf(ALPHABET[X].ToString());
                    }
                    return true;
                }

                string Answer()
                {
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
            catch { return null; }
        }
    }
}
