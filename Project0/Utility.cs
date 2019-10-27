using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    static public class Utility
    {
        public static int ExitCode { get; }  = -5241119;
        public static int MainCode { get; } = -1311114;

        public static int ReadInt()
        {
            string intString = ReadString();
            int readInt = ParseInt(intString);
            return readInt;
        }

        public static decimal ReadDec()
        {
            string decString = ReadString();
            decimal readDec = ParseDec(decString);
            return readDec;
        }

        public static string ReadString()
        {
            string input = "";
            try
            {
                input = Console.ReadLine().Trim();
            }
            catch (Exception)
            {
                return null;
            }
            input = CheckCommands(input);
            return input;
        }

        public static string CheckCommands(string s)
        {
            if (CheckForExit(s))
            {
                return ExitCode.ToString();
            } else if (CheckForMain(s))
            {
                return MainCode.ToString();
            } else
            {
                return s;
            }
        }

        public static bool CheckForExit(string s)
        {
            if (s == "Exit" || s == "exit")
            {
                return true;
            }
            return false;
        }

        public static bool CheckForMain(string s)
        {
            if (s == "Main" || s == "main")
            {
                return true;
            }
            return false;
        }

        public static int ParseInt(string intString)
        {
            int parsedInt = 0;
            try
            {
                parsedInt = Int32.Parse(intString);
            }
            catch (Exception)
            {
                return -1;
            }
            return parsedInt;
        }

        public static decimal ParseDec(string decString)
        {
            decimal parsedDec = 0;
            try
            {
                parsedDec = Convert.ToDecimal(decString);
            }
            catch (Exception)
            {
                return -1;
            }
            return parsedDec;
        }
    }
}
