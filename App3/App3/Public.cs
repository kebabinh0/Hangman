using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace App3
{
    public static class Public
    {
        public static int letterCounter = 0;
        public static string word;
        public static string guessed;
        public static string [] wordarray;


        public static string ReadFile()
        {

            wordarray = new string [] {"lobuz", "wolny", "szybki", "herbata","wisielec"};

            Random rnd = new Random();
            int number = rnd.Next(0, 4);


           
            string line = wordarray[3];
            
             for(int i=0;i<line.Length;i++)
            {
                guessed = guessed + " ";
            }
            
            return line;
        }
    }
}
