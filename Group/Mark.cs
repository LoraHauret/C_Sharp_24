using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    enum MarkType
    {
        Pass,
        Term,
        Exam
    }
    internal class Mark
    {
        public int Value { get; set; }
        public string Subject { get; set; }
        public DateOnly Date { get; set; }
        public int Teacher { get; set; }
        public Mark(int value, string subject, DateOnly date, int teacher)
        {
            Value = value;
            Subject = subject;
            Date = date;
            Teacher = teacher;
        }
    }
}
