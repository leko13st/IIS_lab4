using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    class KondorseBordMethod : IMethod
    {
        string ALPHABET { get; set; } //Алфавит, чтобы указать альтернативу
        public List<string> ListAlt { get; }
        public List<int> ListVote { get; }

        private int CandidateCount;

        public KondorseBordMethod(int candidateCount)
        {
            ALPHABET = Alphabet.value;
            ListVote = new List<int>();
            ListAlt = new List<string>();
            CandidateCount = candidateCount;
        }

        public bool EnumAllAlter()
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

        public string PrintAnswer()
        {
            string s = AnswerByKondorse() + AnswerByCopeland() + AnswerBySimpson() + AnswerByBord();
            return s;
        }

        string AnswerByKondorse()
        {
            List<int> ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);

            string ans = "[Метод Кондорсе]\r\n";
            for (int i = 0; i < CandidateCount; i++)
                for (int j = i + 1; j < CandidateCount; j++)
                    ans += CompareAlter(i, j);

            ans += "Ответ: " + Result() + "\r\n";
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
                    if (i != 0) {
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

        string AnswerByCopeland()
        {
            List<int> ListScore = new List<int>();
            for (int i = 0; i < CandidateCount; i++)
                ListScore.Add(0);

            string ans = "[Метод Копленда]\r\n";
            for (int i = 0; i < CandidateCount; i++)
            {
                for (int j = 0; j < CandidateCount; j++)
                    if (i != j)
                        CompareAlter(i, j);
                ans += ALPHABET[i] + " = " + ListScore[i] + "\r\n";
            }
            ans += "Ответ: " + Answer() + "\r\n";
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

        string AnswerBySimpson()
        {
            
        }

        string AnswerByBord()
        {
            string ans = "[Метод Борда]\r\n";

            return ans;
        }
    }
}
