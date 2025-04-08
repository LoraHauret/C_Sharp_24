using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    enum MarkType
    {
        Pass,
        Term,
        Exam
    }
    class Mark
    {
        public int Value { get; set; }
        public string Subject { get; set; }
        public DateOnly Date { get; set; }
        public string Teacher { get; set; }
        public Mark(int value, string subject, DateOnly date, string teacher)
        {
            Value = value;
            Subject = subject;
            Date = date;
            Teacher = teacher;
        }
    }
}
