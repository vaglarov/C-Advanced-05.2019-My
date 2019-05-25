namespace _108._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Ranking
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, string> dictContest = new Dictionary<string, string>();
                Dictionary<string, Student> dictStudent = new Dictionary<string, Student>();
                string input = string.Empty;
                //Read constest with password
                while ((input = Console.ReadLine()) != "end of contests")
                {
                    string[] inputSplit = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string contest = inputSplit[0];
                    string passwordContest = inputSplit[1];
                    if (!dictContest.ContainsKey(contest))
                    {
                        dictContest.Add(contest, passwordContest);
                    }
                }
                //Read student With Submissions
                while ((input = Console.ReadLine()) != "end of submissions")
                {
                    string[] inputSplit = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                    string contest = inputSplit[0];
                    string passwordContest = inputSplit[1];
                    string nameStudent = inputSplit[2];
                    int pointContest = int.Parse(inputSplit[3]);
                    if (dictContest.ContainsKey(contest) && dictContest[contest] == (passwordContest))
                    {
                        if (!dictStudent.ContainsKey(nameStudent))
                        {
                            var student = new Student(nameStudent);
                            student.AddContest(contest, pointContest);
                            dictStudent.Add(nameStudent, student);
                        }
                        else
                        {
                            var student = dictStudent[nameStudent];
                            student.AddContest(contest, pointContest);
                        }
                    }
                }
                Print(dictStudent);
                
            }
            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void Print(Dictionary<string, Student> dictStudent)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var bestStudent = dictStudent.OrderByDescending(x => x.Value.TotalResult).First();
            Console.WriteLine($"Best candidate is {bestStudent.Key} with total {bestStudent.Value.TotalResult} points.");
            Console.WriteLine("Ranking:");
            foreach (var kvp in dictStudent.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var contestResult in kvp.Value.ResultStudent())
                {
                    Console.WriteLine($"#  {contestResult.Key} -> {contestResult.Value}");
                }
            }
        }
    }

    public class Student
    {
        public Dictionary<string, int> dataContestResult;
        public int TotalResult { get => this.dataContestResult.Sum(x => x.Value); set => this.dataContestResult.Sum(x => x.Value); }
        public int totalResult;
        public Student(string name)
        {
            this.Name = name;
            this.dataContestResult = new Dictionary<string, int>();
            this.TotalResult = this.totalResult;
        }

        public void AddContest(string contest,int point)
        {
            if (!this.dataContestResult.ContainsKey(contest))
            {
                this.dataContestResult.Add(contest, point);
            }
            else if (this.dataContestResult[contest]<point)
            {
                this.dataContestResult[contest] = point;
            }
        }

        public Dictionary<string,int> ResultStudent()
        {
            var result = this.dataContestResult.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x=>x.Key,y=>y.Value);
            return result;
        }
        public string Name { get; private set; }
    }
}
 