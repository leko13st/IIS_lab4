using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    public class VoteHandler
    {
        List<string> ListAlt { get; set; }

        string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public List<string> GetListAlt()
        {
            return ListAlt;
        }

        public void CreateAlternative(int candidateCount, int idMethod)
        {
            ListAlt = new List<string>();
            if (idMethod == 0)            
                EnumForMethod1(candidateCount);
            else if (idMethod == 1)
                EnumForMethod2(candidateCount);
        }

        void EnumForMethod1(int candidateCount)
        {
            
        }

        void EnumForMethod2(int candidateCount)
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
                    break;

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

        public void SendVote(int alt)
        {

        }

        public bool v(int i)
        {
            if (i == 1) return true;
            return false;
        }
    }
}
