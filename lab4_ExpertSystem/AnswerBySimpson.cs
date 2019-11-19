using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    //Класс по выводу ответа по методу Симпсона
    public class AnswerBySimpson : Answer
    {
        public AnswerBySimpson(List<string> listAlt, List<int> listVote, int candidateCount) : base(ListAlt: listAlt, ListVote: listVote, CandidateCount: candidateCount)
        {
            ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);
        }

        public override string GetAnswer()
        {
            try
            {
                List<int> list_tmp = new List<int>();
                for (int i = 0; i < CandidateCount; i++)
                {
                    list_tmp.Add(0);
                }

                string ans = "[Метод Симпсона]\r\n";
                for (int i = 0; i < CandidateCount; i++)
                {
                    ClearListTmp();
                    for (int j = 0; j < CandidateCount; j++)
                        if (i != j)
                            CompareAlter(i, j);
                    list_tmp[i] = list_tmp.Max() + 1;
                    ListScore[i] = list_tmp.Min();
                    ans += "Оценка по " + ALPHABET[i] + " = " + ListScore[i] + "\r\n";
                }
                ans += "Ответ: " + Answer() + "\r\n\r\n";
                return ans;

                bool ClearListTmp()
                {
                    for (int i = 0; i < list_tmp.Count; i++)
                        list_tmp[i] = 0;
                    return true;
                }

                bool CompareAlter(int X, int Y)
                {
                    for (int i = 0; i < ListAlt.Count; i++)
                    {
                        if (ListAlt[i].IndexOf(ALPHABET[X].ToString()) < ListAlt[i].IndexOf(ALPHABET[Y].ToString()))
                            list_tmp[Y] += ListVote[i];
                    }
                    return true;
                }

                string Answer()
                {
                    string s = null;
                    int max = ListScore.Max();
                    #region 
                    //int cnt = ListScore.Count; 
                    //int min = ListScore.Min(); 
                    //for (int i = 0; i < cnt; i++) 
                    //{ 
                    // if (i != 0) 
                    // { 
                    // if (max == ListScore.Max()) 
                    // s += " = "; 
                    // else 
                    // s += " > "; 
                    // } 
                    // s += ALPHABET[ListScore.IndexOf(ListScore.Max())]; 
                    // max = ListScore.Max(); 
                    // ListScore[ListScore.IndexOf(max)] = min - 1; 
                    //} 
                    #endregion

                    int cnt = 0;
                    for (int i = 0; i < ListScore.Count; i++)
                        if (max == ListScore[i])
                        {
                            if (cnt != 0)
                                s += ", ";
                            s += ALPHABET[i];
                            cnt++;
                        }


                    s += " - наилучшая(ие) альтернатива(ы)!";
                    return s;
                }
            }
            catch { return null; }
        }
    }
}
