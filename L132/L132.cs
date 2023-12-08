using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L132
{
    internal class L132
    {
        struct Lesson
        {
            public string teacherName, room;
            public int numberOfStudents;
        }
        static void Main(string[] args)
        {
            Lesson[] Lessons = GetLessons();

        }

        static Lesson[] GetLessons()
        {
            Console.WriteLine("how many lessons to store?");
            int LNum = int.Parse(Console.ReadLine());
            Lesson[] lessons = new Lesson[LNum];
            for (int i = 0; i < LNum; i++)
            {
                Console.WriteLine("what is the teachers name?"); lessons[i].teacherName = Console.ReadLine();
                Console.WriteLine("what is the room?"); lessons[i].room = Console.ReadLine();
                Console.WriteLine("how many students are in the class?"); lessons[i].numberOfStudents = int.Parse(Console.ReadLine());
            }
            return lessons;
        }

        static void WriteLessonsData(Lesson[] lessons)
        {
            using (BinaryWriter BW = new BinaryWriter(File.Open("lessons.bin", FileMode.OpenOrCreate)))
            {
                BW.Write(lessons.Length);
                foreach (Lesson lesson in lessons)
                {
                    BW.Write(lesson.teacherName);
                    BW.Write(lesson.room);
                    BW.Write(lesson.numberOfStudents);
                }
            }
        }

        static Lesson[] ReadLessonsData()
        {
            using(BinaryReader BW = new BinaryReader(File.Open("lessons.bin", FileMode.OpenOrCreate)))
            {
                int length = BW.ReadInt32();
                Lesson[] lessons = new Lesson[length];
                for (int i = 0; i < length; i++)
                {
                    lessons[i].teacherName = BW.ReadString();
                    lessons[i].room = BW.ReadString();
                    lessons[i].numberOfStudents = BW.ReadInt32();
                }
                return lessons;
            }
        }
    }
}
