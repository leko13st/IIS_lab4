﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    public class VoteHandler
    {
        IMethod Method = null;
        public List<string> GetListAlt()
        {
            return Method.ListAlt;
        }
        public List<int> GetListVote()
        {
            return Method.ListVote;
        }

        public bool CreateAlternative(int candidateCount, int idMethod)
        {
            if (idMethod == 0)
                Method = new RelatMajorMethod();
            else if (idMethod == 1)
                Method = new KondorseBordMethod();

            for (int i = 0; i < candidateCount; i++)
                Method.ListVote.Add(0);

            if (Method.EnumAllAlter(candidateCount))
                return true;
            else 
                return false;
        }

        public void SendVote(int alt)
        {
            Method.ListVote[alt]++;
        }

        public string Answer()
        {
            return Method.PrintAnswer();
        }
    }
}
