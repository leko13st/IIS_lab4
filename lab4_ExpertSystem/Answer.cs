using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    //Абстрактный класс по выводу ответа от каждого метода
    public abstract class Answer
    {
        protected string ALPHABET { get; } //Алфавит, чтобы указать альтернативу
        public List<string> ListAlt { get; }
        public List<int> ListVote { get; }
        protected int CandidateCount { get; }

        //Список баллов. Необходим, что указать какие альтернативы лучше
        protected List<int> ListScore { get; set; } 

        public Answer(List<string> ListAlt, List<int> ListVote, int CandidateCount)
        {
            ALPHABET = Alphabet.value;
            this.ListAlt = ListAlt;
            this.ListVote = ListVote;
            this.CandidateCount = CandidateCount;
        }

        public abstract string GetAnswer();
    }
}
