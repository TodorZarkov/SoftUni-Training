using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 1000; i++)
            //{



                int examHour = int.Parse(Console.ReadLine());
                int examMin = int.Parse(Console.ReadLine());
                int arrHour = int.Parse(Console.ReadLine());
                int arrMin = int.Parse(Console.ReadLine());

                // “Late”, ако студентът пристига по-късно от часа на изпита.
                // “On time”, ако студентът пристига точно в часа на изпита или до 30 минути по-рано.
                // “Early”, ако студентът пристига повече от 30 минути преди часа на изпита.
                string status = "";
                string msg = "";

                examMin += examHour * 60;
                arrMin += arrHour * 60;

                int diffMin = examMin - arrMin;

                int hours = diffMin / 60;
                int minutes = diffMin % 60;
                string zero = "";
                if (Math.Abs(minutes) < 10)
                    zero = "0";

                if (diffMin < 0)
                {
                    status = "Late";
                    if (diffMin <= -60)
                    {
                        msg = $"{-hours}:{zero}{-minutes} hours after";
                    }
                    else
                    {
                        msg = $"{-minutes} minutes after";
                    }
                }
                else if (diffMin >= 0 && diffMin <= 30)
                {
                    status = "On time";
                    if (diffMin >= 60)
                    {
                        msg = $"{hours}:{zero}{minutes} hours before";
                    }
                    else
                    {
                        msg = $"{minutes} minutes before";
                    }
                }
                else
                {
                    status = "Early";
                    if (diffMin >= 60)
                    {
                        msg = $"{hours}:{zero}{minutes} hours before";
                    }
                    else
                    {
                        msg = $"{minutes} minutes before";
                    }
                }


                Console.WriteLine(status);
                if (msg != "")
                {
                    Console.WriteLine($"{msg} the start");
                }
            //}

        }
    }
}
