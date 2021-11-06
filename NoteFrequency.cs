using System;
using System.Collections.Generic;
using System.Text;

namespace Cynthesizer
{
    static class NoteFrequency
    {
        //calculate the Hz of a music note, using the formula given by https://pages.mtu.edu/~suits/NoteFreqCalcs.html
        public static double NoteToHz(char note = 'A', int scale = 4, char accidental = ' ')
        {
            //base: A4 is 440HZ
            double A4 = 440;
            int halfSteps = HalfStepsFromA4(note, scale, accidental);
            double a = Math.Pow(2, halfSteps / 12f);
            double result = A4 * a;
            Console.WriteLine("" + note + scale + accidental + " - frequency: " + result);
            return A4 * a;
        }
        //number of half steps from A4
        private static int HalfStepsFromA4(char note = 'A', int scale = 4, char accidental = ' ')
        {
            int noteDif = note - 'A';
            int scaleDif = scale - 4;
            int result = scaleDif * 12 + noteDif;
            int mult = Math.Sign(noteDif);
            if (note >= 'B')
            {
                result += mult;
            }
            if(note >= 'D')
            {
                result += mult;
            }
            if(note >= 'E')
            {
                result += mult;
            }
            if(note == 'G')
            {
                result += mult;
            }
            if(accidental == '#')
            {
                result += 1;
            }
            else if(accidental == 'b')
            {
                result -= 1;
            }
            return result;
        }
    }
}
