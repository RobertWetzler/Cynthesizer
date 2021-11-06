using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cynthesizer
{
    class AdditiveWaveProvider : ISampleProvider
    {
        private List<ISampleProvider> waveProviders;
        public AdditiveWaveProvider(List<ISampleProvider> waveProviders)
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
            this.waveProviders = waveProviders;
        }
        public WaveFormat WaveFormat { get; private set; }

        public void AddWave(ISampleProvider waveProvider)
        {
            this.waveProviders.Add(waveProvider);
        }
        private static void AddArrays(float[] a, float[] b, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                a[i + offset] += b[i + offset];
            }
        }
        public int Read(float[] buffer, int offset, int count)
        {
            float[] tempBuffer = new float[count];
            for (int wave = 0; wave < this.waveProviders.Count; wave++)
            {
                this.waveProviders[wave].Read(tempBuffer, offset, count);
                AddArrays(buffer, tempBuffer, offset, count);
            }
            return count;
        }
    }
}
