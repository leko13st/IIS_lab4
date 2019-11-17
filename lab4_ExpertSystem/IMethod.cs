using System.Collections.Generic;

namespace lab4_ExpertSystem
{
    interface IMethod
    {
        List<string> ListAlt { get; } //Список всех альтернатив
        List<int> ListVote { get; } //Список всех голосов за определённую альтернативу
        bool EnumAllAlter(); //Метод перечисления всех ВОЗМОЖНЫХ альтернатив
        string PrintAnswer(); //Вывод ответа
    }
}
