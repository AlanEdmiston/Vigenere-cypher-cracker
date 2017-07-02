using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vigenere_Cypher_Cracker
{
    class Program
    {
        static void Main(string[] args)
        {

            string rootDirectory;
            string cypherText;
            Console.WriteLine("enter root directory of cyphertext");
            rootDirectory = Console.ReadLine();
            cypherText = System.IO.File.ReadAllText(@rootDirectory);
            int trigrams = 0;
            int codeWordLength = 0;
            int maximumCodeWordLength = 18;
            int[] possibleCodeWordLengths;

            cypherText = cypherText.Trim(new Char[] { ' ', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '{', '}', '[', ']', ';', ':', '@', '#', '~', '/', '?', '.', '>', '<', ',' });
            cypherText = cypherText.ToUpper();

            possibleCodeWordLengths = new int[maximumCodeWordLength];
            char a;
            char b;
            char c;
            char d;
            char e;
            char f;
            for (int i = 0; i < cypherText.Length - 2; i++)
            {
                a = cypherText[i];
                b = cypherText[i + 1];
                c = cypherText[i + 2];
                for (int j = i + 2; j < cypherText.Length - 2; j++)
                {

                    d = cypherText[j];
                    e = cypherText[j + 1];
                    f = cypherText[j + 2];
                    if (a == d && b == e && c == f)
                    {
                        int seperation;
                        seperation = j - i;
                        trigrams++;
                        for (int k = 0; k < maximumCodeWordLength; k++)
                        {
                            if (seperation % (k + 1) == 0)
                            {
                                possibleCodeWordLengths[k]++;
                            }
                        }
                        break;
                    }
                }
            }
            double[] codewordLengthProbabilities;
            codewordLengthProbabilities = new double[maximumCodeWordLength];
            double probability = 0;
            for (int i = 0; i < maximumCodeWordLength; i++)
            {
                codewordLengthProbabilities[i] = (possibleCodeWordLengths[i] - trigrams / (i + 1)) / Math.Sqrt(trigrams / (i + 1));
                if (codewordLengthProbabilities[i] > probability)
                {
                    codeWordLength = i;
                    probability = codewordLengthProbabilities[i];
                }
            }
            codeWordLength = codeWordLength + 1;
            for (int i = 0; i < maximumCodeWordLength; i++)
            {
                Console.Write(i + 1);
                Console.Write(":");
                Console.Write(possibleCodeWordLengths[i]);
                Console.Write(",    ");
            }
            Console.Write("codeword Length is ");
            Console.WriteLine(codeWordLength);

            //once codeword length is found, crack code using letter frequencies.
            string[] strings;
            int stringsSize = (int)Math.Ceiling((double)cypherText.Length / codeWordLength);
            strings = new string[stringsSize];
            for (int i = 0; i < cypherText.Length; i++)
            {
                int j = i % codeWordLength;
                strings[j] += (cypherText[i]);
            }
            double[,] letterFrequencies;
            letterFrequencies = new double[26, codeWordLength];
            for (int i = 0; i < codeWordLength; i++)
            {
                foreach (char g in strings[i])
                {
                    if (g == 'A') letterFrequencies[0, i]++;
                    if (g == 'B') letterFrequencies[1, i]++;
                    if (g == 'C') letterFrequencies[2, i]++;
                    if (g == 'D') letterFrequencies[3, i]++;
                    if (g == 'E') letterFrequencies[4, i]++;
                    if (g == 'F') letterFrequencies[5, i]++;
                    if (g == 'G') letterFrequencies[6, i]++;
                    if (g == 'H') letterFrequencies[7, i]++;
                    if (g == 'I') letterFrequencies[8, i]++;
                    if (g == 'J') letterFrequencies[9, i]++;
                    if (g == 'K') letterFrequencies[10, i]++;
                    if (g == 'L') letterFrequencies[11, i]++;
                    if (g == 'M') letterFrequencies[12, i]++;
                    if (g == 'N') letterFrequencies[13, i]++;
                    if (g == 'O') letterFrequencies[14, i]++;
                    if (g == 'P') letterFrequencies[15, i]++;
                    if (g == 'Q') letterFrequencies[16, i]++;
                    if (g == 'R') letterFrequencies[17, i]++;
                    if (g == 'S') letterFrequencies[18, i]++;
                    if (g == 'T') letterFrequencies[19, i]++;
                    if (g == 'U') letterFrequencies[20, i]++;
                    if (g == 'V') letterFrequencies[21, i]++;
                    if (g == 'W') letterFrequencies[22, i]++;
                    if (g == 'X') letterFrequencies[23, i]++;
                    if (g == 'Y') letterFrequencies[24, i]++;
                    if (g == 'Z') letterFrequencies[25, i]++;
                }
            }
            for (int i = 0; i < codeWordLength; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    letterFrequencies[j, i] = letterFrequencies[j, i] / strings[i].Length;
                }
            }
            double[] englishLetterFrequency;
            englishLetterFrequency = new double[26];
            englishLetterFrequency[0] = 0.08167;
            englishLetterFrequency[1] = 0.01492;
            englishLetterFrequency[2] = 0.02782;
            englishLetterFrequency[3] = 0.04253;
            englishLetterFrequency[4] = 0.12702;
            englishLetterFrequency[5] = 0.02228;
            englishLetterFrequency[6] = 0.02015;
            englishLetterFrequency[7] = 0.06094;
            englishLetterFrequency[8] = 0.06966;
            englishLetterFrequency[9] = 0.00153;
            englishLetterFrequency[10] = 0.00772;
            englishLetterFrequency[11] = 0.04025;
            englishLetterFrequency[12] = 0.02406;
            englishLetterFrequency[13] = 0.06749;
            englishLetterFrequency[14] = 0.07507;
            englishLetterFrequency[15] = 0.01929;
            englishLetterFrequency[16] = 0.00095;
            englishLetterFrequency[17] = 0.05987;
            englishLetterFrequency[18] = 0.06327;
            englishLetterFrequency[19] = 0.09057;
            englishLetterFrequency[20] = 0.02758;
            englishLetterFrequency[21] = 0.00978;
            englishLetterFrequency[22] = 0.02361;
            englishLetterFrequency[23] = 0.0015;
            englishLetterFrequency[24] = 0.01974;
            englishLetterFrequency[25] = 0.00074;

            double[,] chiSquared;
            double[] currentChiSquared;
            currentChiSquared = new double[codeWordLength];
            for (int i = 0; i < codeWordLength; i++)
            {
                currentChiSquared[i] = 10000000;
            }
            chiSquared = new double[codeWordLength, 26];
            int[] shift;
            shift = new int[codeWordLength];
            for (int i = 0; i < codeWordLength; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    for (int k = 0; k < 26; k++)
                    {
                        chiSquared[i, k] += Math.Pow(letterFrequencies[(j + k) % 26, i] - englishLetterFrequency[j], 2) / englishLetterFrequency[j];
                    }
                }
            }

            for (int i = 0; i < codeWordLength; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (chiSquared[i, j] < currentChiSquared[i])
                    {
                        currentChiSquared[i] = chiSquared[i, j];
                        shift[i] = j;
                    }
                }
            }
            for (int i = 0; i < codeWordLength; i++)
            {
                Console.Write(shift[i]);
                Console.Write(" ");
            }

            int[] letterOrder = new int[cypherText.Length];
            for (int i = 0; i < cypherText.Length; i++)
            {
                switch (cypherText[i])
                {
                    case 'A':
                        letterOrder[i] = 0;
                        break;

                    case 'B':
                        letterOrder[i] = 1;
                        break;

                    case 'C':
                        letterOrder[i] = 2;
                        break;

                    case 'D':
                        letterOrder[i] = 3;
                        break;

                    case 'E':
                        letterOrder[i] = 4;
                        break;

                    case 'F':
                        letterOrder[i] = 5;
                        break;

                    case 'G':
                        letterOrder[i] = 6;
                        break;

                    case 'H':
                        letterOrder[i] = 7;
                        break;

                    case 'I':
                        letterOrder[i] = 8;
                        break;

                    case 'J':
                        letterOrder[i] = 9;
                        break;

                    case 'K':
                        letterOrder[i] = 10;
                        break;

                    case 'L':
                        letterOrder[i] = 11;
                        break;

                    case 'M':
                        letterOrder[i] = 12;
                        break;

                    case 'N':
                        letterOrder[i] = 13;
                        break;

                    case 'O':
                        letterOrder[i] = 14;
                        break;

                    case 'P':
                        letterOrder[i] = 15;
                        break;

                    case 'Q':
                        letterOrder[i] = 16;
                        break;

                    case 'R':
                        letterOrder[i] = 17;
                        break;

                    case 'S':
                        letterOrder[i] = 18;
                        break;

                    case 'T':
                        letterOrder[i] = 19;
                        break;

                    case 'U':
                        letterOrder[i] = 20;
                        break;

                    case 'V':
                        letterOrder[i] = 21;
                        break;

                    case 'W':
                        letterOrder[i] = 22;
                        break;

                    case 'X':
                        letterOrder[i] = 23;
                        break;

                    case 'Y':
                        letterOrder[i] = 24;
                        break;

                    case 'Z':
                        letterOrder[i] = 25;
                        break;

                }
            }
            char[] text = new char[cypherText.Length];
            for (int i = 0; i < cypherText.Length; i++)
            {
                letterOrder[i] = letterOrder[i] - shift[i % codeWordLength];

                letterOrder[i] = (letterOrder[i] + 26) % 26;
            }

            for (int i = 0; i < cypherText.Length; i++)
            {
                switch (letterOrder[i])
                {
                    case 0:
                        text[i] = 'A';
                        break;

                    case 1:
                        text[i] = 'B';
                        break;

                    case 2:
                        text[i] = 'C';
                        break;

                    case 3:
                        text[i] = 'D';
                        break;

                    case 4:
                        text[i] = 'E';
                        break;

                    case 5:
                        text[i] = 'F';
                        break;

                    case 6:
                        text[i] = 'G';
                        break;

                    case 7:
                        text[i] = 'H';
                        break;

                    case 8:
                        text[i] = 'I';
                        break;

                    case 9:
                        text[i] = 'J';
                        break;

                    case 10:
                        text[i] = 'K';
                        break;

                    case 11:
                        text[i] = 'L';
                        break;

                    case 12:
                        text[i] = 'M';
                        break;

                    case 13:
                        text[i] = 'N';
                        break;

                    case 14:
                        text[i] = 'O';
                        break;

                    case 15:
                        text[i] = 'P';
                        break;

                    case 16:
                        text[i] = 'Q';
                        break;

                    case 17:
                        text[i] = 'R';
                        break;

                    case 18:
                        text[i] = 'S';
                        break;

                    case 19:
                        text[i] = 'T';
                        break;

                    case 20:
                        text[i] = 'U';
                        break;

                    case 21:
                        text[i] = 'V';
                        break;

                    case 22:
                        text[i] = 'W';
                        break;

                    case 23:
                        text[i] = 'X';
                        break;

                    case 24:
                        text[i] = 'Y';
                        break;

                    case 25:
                        text[i] = 'Z';
                        break;

                }
            }
            for (int i = 0; i < cypherText.Length; i++)
            {
                Console.Write(text[i]);
                if (i % 5 == 4)
                {
                    Console.Write(" ");
                }
            }
            Console.ReadLine();
        }
    }
}