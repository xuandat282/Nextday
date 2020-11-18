using System;
using System.Runtime.CompilerServices;
/*
Nhập một ngày và xuất ra ngày tiếp theo
*/

namespace Nextday
{
    class Date
    {
        public int year, day, month;

        public void Input()
        {
            do
            {
                Console.WriteLine("---------IN RA NGÀY TIẾP THEO---------");
                Console.WriteLine("\n Nhập ngày");
                this.day = int.Parse(Console.ReadLine());
                Console.WriteLine("\n Nhập tháng");
                this.month = int.Parse(Console.ReadLine());
                Console.WriteLine("\n Nhập năm");
                this.year = int.Parse(Console.ReadLine());
            } while (this.day > check_maxday() || this.month > 12);
        }
        
        // check leap year
        public bool check_leap_year()
        {

            if (this.year % 4 == 0 && this.year % 100 != 0)
                return true;
            else 
                return false;
        }

        // check max day
        public int check_maxday()
        {
            int max_day = 0;
            
            switch(this.month)
                {
                case 1:
                    {
                        max_day = 31;
                        break;
                    }
                case 2:
                    {
                        if (check_leap_year() == true)
                        { 
                            max_day = 29; 
                        }
                        else
                        {
                            max_day = 28;
                        }
                           break;
                    }
                case 3:
                    {
                        max_day = 31;
                        break;
                    }
                case 4:
                    {
                        max_day = 30;
                        break;
                    }
                case 5:
                    {
                        max_day = 31;
                        break;
                    }
                case 6:
                    {
                        max_day = 30;
                        break;
                    }
                case 7:
                    {
                        max_day = 31;
                        break;
                    }
                case 8:
                    {
                        max_day = 31;
                        break;
                    }
                case 9:
                    {
                        max_day = 30;
                        break;
                    }
                case 10:
                    {
                        max_day = 31;
                        break;
                    }
                case 11:
                    {
                        max_day = 30;
                        break;
                    }
                case 12:
                    {
                        max_day = 31;
                        break;
                    }
            }
            return max_day;
        }
        //check case
        public void check_all()
        {
            if(this.day == check_maxday() && this.month != 2) // ngày cuối cùng của các tháng
            {
                if (this.month == 12)
                    Output(1, 1, this.year+1);
                else
                    Output(1, this.month+1, this.year);
            }
            else
            {
                if (this.month == 2) // nếu là tháng 2
                {
                    if (check_leap_year() == true) // là năm nhuận
                    {
                        if (this.day == check_maxday()) // là ngày cuối cùng
                        {
                            Output(1, 3, this.year);
                        }
                        else // không phải ngày cuối
                        {
                            Output(this.day + 1, this.month, this.year);
                        }

                    }
                    else if(check_leap_year() == false) // không phải năm nhuân
                    {
                        if (this.day == check_maxday()) // là ngày cuối cùng
                        {
                            Output(1, 3, this.year);
                        }
                        else
                            Output(this.day + 1, this.month, this.year); // không phải ngày cuối
                    }
                    else // ngày cuối của tháng 2 
                    {
                        if (this.day == check_maxday())
                        {
                            Output(1, 3, this.year);
                        }
                    }
                }
                else // just a normal day, không phải tháng 2
                {
                    Output(this.day + 1, this.month, this.year);
                }
                
            }    
        }

        // print
        public void Output(int day, int month, int year)
        {
            Console.WriteLine("\nTHE NEXT DAY IS: {0}/{1}/{2}", day, month, year);
            Day_time(year, month, day);
            Output_next_year(day, month, year+1);
        }
        public void Output_next_year(int day, int month, int year)
        {
            Console.WriteLine("\nTHE NEXT DAY OF NEXT YEAR IS: {0}/{1}/{2}", day, month, year);
            Day_time(year, month, day);
        }

        public void Day_time(int year, int month, int day)
        {
            DateTime D = new DateTime(year, month, day);
            Console.WriteLine(D.DayOfWeek);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Date d1 = new Date();
            d1.Input();
            d1.check_all();
            Console.ReadKey();
        }
    }
}
