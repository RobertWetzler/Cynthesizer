using NAudio.Wave;
using Cynthesizer;
using System;
using System.Threading;

namespace Cynthesizer
{
    class Program
    {
        static double GetKeyFreq()
        {
            char key = Console.ReadKey().KeyChar;
            int val = (int)key;
            double char_1 = 49;
            double char_9 = 57;
            double C4 = 261.63;
            double C5 = 587.33;
            double C6 = 1567.98;
            double C7 = 2093;
            //poor attempt at mapping Keys 1-9 to music notes (doesn't really work except for 1 and 9)
            return (C5 + ((val - char_1) / (char_9 - char_1) * (C6-C5)));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sine20Seconds = new SineWaveProvider();
            using (var wo = new NAudio.Wave.WaveOutEvent())
            {
                wo.Init(sine20Seconds);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                   
                    sine20Seconds.Frequency = GetKeyFreq();
                    //uncomment code below to make frequency change over time
                    // DateTime t = DateTime.Now;
                    //long uT = ((DateTimeOffset)t).ToUnixTimeMilliseconds();
                    //sine20Seconds.Frequency = 500 + 400*Math.Sin(uT/1200.0);
                    Console.WriteLine(" Freq: " + sine20Seconds.Frequency);
                    Thread.Sleep(30);
                }
            }
        }
    }
}
