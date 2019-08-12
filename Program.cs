using System;

namespace CrackingTheCodingInterview
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyHashMap<string, string> map = new MyHashMap<string, string>(20);
            map.Add("1", "apple");
            map.Add("2", "fig");
            map.Add("3", "lemon");
            map.Add("4", "orange");

            string one = map.Find("1");
            string three = map.Find("3");

            map.Remove("1");
        }
    }
}
