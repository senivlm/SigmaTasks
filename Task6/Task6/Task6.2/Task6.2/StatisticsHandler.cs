using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task6._2
{
    public class StatisticsHandler
    {
        private Dictionary<string,Dictionary<DayOfWeek,List<TimeSpan>>> data;


        public StatisticsHandler(string path)
        {
            data = new Dictionary<string, Dictionary<DayOfWeek, List<TimeSpan>>>();
            ReadFromFile(path);
        }
        public void ReadFromFile(string path)
        {
            try
            {
                string[] info = File.ReadAllLines(path);
                string[] temp;
                TimeSpan time;
                DayOfWeek day;
                foreach (string str in info)
                {
                    
                    temp = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length != 3)
                        throw new FormatException();
                    time = TimeSpan.Parse(temp[1]);
                    day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), temp[2]);
                    if (!data.ContainsKey(temp[0]))
                        data.Add(temp[0], new Dictionary<DayOfWeek, List<TimeSpan>>());
                    if(!data[temp[0]].ContainsKey(day))
                        data[temp[0]].Add(day, new List<TimeSpan>());
                     data[temp[0]][day].Add(time);


                              
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public Dictionary<string, int> NumberOfVisits()
        {
            
            Dictionary<string, int> temp = new Dictionary<string, int>();
            int number=0;
            foreach (var item in data)
            {
                foreach (var item2 in item.Value)
                {
                    number += item2.Value.Count;
                }
                temp.Add(item.Key, number);
                number = 0;
            }
            return temp;
        }
        public Dictionary<string, DayOfWeek> MostPopularDay()
        {
            Dictionary<string, DayOfWeek> temp = new Dictionary<string, DayOfWeek>();
            int attendance = 0;
            DayOfWeek day=new DayOfWeek();
            foreach (var item in data)
            {
                foreach (var item2 in item.Value)
                {
                    if (item2.Value.Count > attendance)
                    {
                        attendance = item2.Value.Count;
                        day = item2.Key;
                    }
                    
                }
                temp.Add(item.Key, day);
            }
            return temp;
        }
        private (TimeSpan, TimeSpan) FindMostPopulatInterval(List<TimeSpan> list)
        {
            TimeSpan popularTime=new TimeSpan();
            TimeSpan curentTimeStart,curentTimeEnd;
            int curentCount = 0,popularCount=0;
            foreach (TimeSpan item in list)
            {
                curentTimeStart = item;
                curentTimeEnd = curentTimeStart + new TimeSpan(1, 0, 0);
                foreach (var item2 in list)
                {
                    if (item2 >= curentTimeStart && item2 <= curentTimeEnd)
                        ++curentCount;  
                }
                if (curentCount > popularCount)
                {
                    popularCount = curentCount;
                    popularTime =curentTimeStart;
                }
                curentCount = 0;

            }
            return (popularTime,popularTime+new TimeSpan(1,0,0));
        }
        public Dictionary<string, (TimeSpan,TimeSpan)> MostPopularTime()
        {
            Dictionary<string, (TimeSpan,TimeSpan)> temp = new Dictionary<string, (TimeSpan,TimeSpan)>();
            List<TimeSpan> allTime = new List<TimeSpan>();
            foreach (var item in data)
            {
                foreach (var item2 in item.Value)
                {
                    allTime.AddRange(item2.Value);
                }
                temp.Add(item.Key, FindMostPopulatInterval(allTime));
                allTime.Clear();
            }
            return temp;
        }
        public (TimeSpan, TimeSpan) MostPopularTimeForWeak()
        {
            (TimeSpan, TimeSpan) temp;
            List<TimeSpan> allTime = new List<TimeSpan>();
            foreach (var item in data)
            {
                foreach (var item2 in item.Value)
                {
                    allTime.AddRange(item2.Value);
                }
                   
            }
            temp = FindMostPopulatInterval(allTime);
            return temp;
        }




        public override string ToString()
        {

            StringBuilder temp = new StringBuilder();
            foreach (var item in data)
            {
                temp.Append(item.Key + " \n");
                foreach (var item2 in item.Value )
                {
                    temp.Append(item2.Key + "\n");
                    foreach (var item3 in item2.Value)
                    {
                        temp.Append(item3 + "\n");
                    }
                }
            }
            return temp.ToString(); 
        }
    }
}
