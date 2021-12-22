using System;
using System.Linq;

namespace lb1
{
    enum Subjects
    {
        English,
        Embedded,
        Web,
        CSharp,
        CPlusPlus,
        ElCircuits,
        BigData,
        VHDL,
        Sports,
        Philosophy
    }

    class Student 
    {
        private string name;
        private string id;
        private int course;

        private int[] marksArr = new int[10];
        private double avgMark => marksArr.Average();
        public string Name
        {
            get => name;

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name should not be empty");
                }
                for (int i = 0; i < value.Length; ++i)
                {
                    if (Char.IsDigit(value[i]))
                    {
                        throw new Exception("Name should not has numbers");
                    }
                }
                name = value;
            }
        }

        public string Id
        {
            get => id;
            set
            {
                for (int i = 0; i < value.Length; ++i)
                {
                    if (!Char.IsDigit(value[i]))
                    {
                        throw new Exception("Number of student recordbook shold contain only numbers");
                    }
                }
                id = value;
            }
        }

        public int Course
        {
            get => course;
            set
            {
                if (value <= 0 || value > 6)
                {
                    throw new Exception("Course should be in range from 1 to 6");
                }
                else course = value;
            }
        }

        public int[] MarksArr { get => marksArr; set => marksArr = value; }
        public Student(string name, string id, int course)
        {
            Name = name;
            Id = id;
            Course = course;
        }

        public int GetMark(Subjects subj) => MarksArr[(int)subj];
        public void SetMark(Subjects subj, int mark) => MarksArr[(int)subj] = mark;
        public override string ToString() => $"Student {Name}, recordbook {Id}, course {Course}";
        public int[] CompareTo(Student obj)
        {
            int[] diffMarks = new int[10];
            foreach (int i in diffMarks)
            {
                diffMarks[i] = this.marksArr[i] - obj.marksArr[i];
            }
            return diffMarks;
        }
        public int CompareTo(object obj) => throw new NotImplementedException();
    }
   
}

