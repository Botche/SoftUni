using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
               .Split(", ")
               .ToList();
            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] commands = command
                    .Split(":")
                    .ToArray();
                switch (commands[0])
                {
                    case "Add":
                        string lesson = commands[1];
                        if (!lessons.Contains(lesson))
                        {
                            lessons.Add(lesson);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(commands[2]);
                        lesson = commands[1];
                        if (!lessons.Contains(lesson))
                        {
                            lessons.Insert(index, lesson);
                        }
                        break;
                    case "Remove":
                        lesson = commands[1];
                        string exe = lesson + "-Exercise";
                        if (lessons.Contains(lesson))
                        {
                            lessons.Remove(lesson);
                        }
                        if (lessons.Contains(exe))
                        {
                            lessons.Remove(exe);
                        }
                        break;
                    case "Swap":
                        lesson = commands[1];
                        exe = lesson + "-Exercise";
                        string lessonTwo = commands[2];
                        string exe2 = lessonTwo + "-Exercise";
                        int indexOne = lessons.IndexOf(lesson);
                        int indexTwo = lessons.IndexOf(lessonTwo);
                        if (lessons.Contains(lesson) && lessons.Contains(lessonTwo))
                        {
                            string swap = lessons[indexOne];
                            lessons[indexOne] = lessons[indexTwo];
                            lessons[indexTwo] = swap;
                        }
                        if (lessons.Contains(exe))
                        {
                            lessons.Remove(exe);
                            indexOne = lessons.IndexOf(lesson);
                            lessons.Insert(indexOne + 1, exe);
                        }
                        if (lessons.Contains(exe2))
                        {
                            lessons.Remove(exe2);
                            indexTwo = lessons.IndexOf(lessonTwo);
                            lessons.Insert(indexTwo + 1, exe2);
                        }
                        break;
                    case "Exercise":
                        lesson = commands[1];
                        exe = lesson + "-Exercise";
                        if (lessons.Contains(lesson) && !lessons.Contains(exe))
                        {
                            indexOne = lessons.IndexOf(lesson);
                            lessons.Insert(indexOne + 1, exe);
                        }
                        else if (!lessons.Contains(lesson) && !lessons.Contains(exe))
                        {
                            lessons.Add(lesson);
                            lessons.Add(exe);
                        }
                        break;
                }
                //Console.WriteLine(string.Join(" ",lessons));
                command = Console.ReadLine();
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
