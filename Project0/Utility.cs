using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    static public class Utility
    {

        public static int IntReader()
        {
            string intString = stringReader();
            int readInt = IntParse(intString);
            return readInt;
        }

        public static decimal DecReader()
        {
            string decString = stringReader();
            decimal readDec = DecParse(decString);
            return readDec;
        }

        public static string stringReader()
        {
            string input = "";
            try
            {
                input = Console.ReadLine();
            }
            catch (Exception)
            {
                return null;
            }
            return input;
        }

        public static int CheckCommands(string s)
        {
            if (CheckForExit(s))
            {
                return -1;
            } else if (CheckForMain(s))
            {
                return 1;
            } else
            {
                return 0;
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
            if (s == "Main Menu" || s == "Main menu" || s == "main Menu" || s == "main menu")
            {
                return true;
            }
            return false;
        }

        public static int IntParse(string intString)
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

        public static decimal DecParse(string decString)
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
