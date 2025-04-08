using System;

namespace gettersSettersTryCatch
{
    enum MarkType
    {
        Pass,
        Term,
        Exam
    }
    class Mark
    {
        private int mValue;
        public int Value
        {
            get => mValue;
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Оценка должна быть в диапазоне от 0 до 12");
                }
                mValue = value;
            }
        }
        private string mSubject;
        public string Subject
        {
            get{ return mSubject; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Предмет не может быть пустым");
                }
                mSubject = value;
            }
        }
        private DateOnly mDate;
        public DateOnly Date
        {
            get => mDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentOutOfRangeException("Дата не может быть в будущем");
                }
                mDate = value;
            }
        }
        private string mTeacher;
        public string Teacher
        {
            get { return mTeacher; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя преподавателя не может быть пустым");
                }
                mTeacher = value;
            }
        }
        public Mark(int value, string subject, DateOnly date, string teacher)
        {
            Value = value;
            Subject = subject;
            Date = date;
            Teacher = teacher;
        }
    }
}