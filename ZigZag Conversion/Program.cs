using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZigZag_Conversion
{
    internal class Program
    {
        // The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:

        // P   A   H   N
        // A P L S I I G
        // Y   I   R

        // And then read line by line: "PAHNAPLSIIGYIR"
        // Write the code that will take a string and make this conversion given a number of rows:
        // string convert(string s, int numRows);

        // Input: s = "PAYPALISHIRING", numRows = 4
        // Output: "PINALSIGYAHRPI"
        // Explanation:

        // P     I    N
        // A   L S  I G
        // Y A   H R
        // P     I

        static void Main(string[] args)
        {
            Console.WriteLine($"Expected: PAHNAPLSIIGYIR, Got: {Convert("PAYPALISHIRING", 3)}");
            Console.WriteLine($"Expected: PINALSIGYAHRPI, Got: {Convert("PAYPALISHIRING", 4)}");
            Console.WriteLine($"Expected: A, Got: {Convert("A", 1)}");
        }

        public static string Convert(string s, int numRows)
        {
            Dictionary<string, List<char>> rows = new Dictionary<string, List<char>>();
            for (int i = 1; i < numRows + 1; i++)
            {
                rows.Add(($"list{i}"), new List<char>());
            }

            int listTrack = 1;
            bool increasing = true;

            foreach (char c in s)
            {
                rows[$"list{listTrack}"].Add(c);

                if (numRows > 1)
                {
                    if (increasing)
                    {
                        if (listTrack == numRows)
                        {
                            increasing = false;
                            listTrack--;
                        }
                        else
                        {
                            listTrack++;
                        }
                    }
                    else
                    {
                        if (listTrack == 1)
                        {
                            increasing = true;
                            listTrack++;
                        }
                        else
                        {
                            listTrack--;
                        }
                    }
                }
            }

            string result = "";

            foreach (List<char> list in rows.Values)
            {
                result += new string(list.ToArray());
            }

            return result;
        }
    }
}
