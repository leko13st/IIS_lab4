using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ExpertSystem
{
    interface IMethod
    {
        List<string> ListAlt { get; }
        List<int> ListVote { get; }
        bool EnumAllAlter(int i);
        string PrintAnswer();
    }
}
