﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Util
    {
        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: ");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"You must enter a valid {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt)
        {

            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid {prompt}");
                }

            } while (true);
        }
    }
}
