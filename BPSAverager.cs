using System;
using System.Collections.Generic;

namespace GraphSample
{
    class AVG_STR
    {
        public ulong Bytes { get; set; }
        public long Millisecs { get; set; }

        public AVG_STR(ulong count, long ms)
        {
            this.Bytes = count;
            this.Millisecs = ms;
        }
    }

    class BPSAverager
    {
        private const int Capacity = 5;
        Queue<AVG_STR> Samples;
        private ulong TotalBytes;
        private long TotalTime;
        private long PrevTickCount;
        private ulong PrevBytes;

        public BPSAverager()
        {
  
            Samples = new Queue<AVG_STR>();
            Reset();
        }

        public void Add(ulong aBytes)
        {
            ulong lenBytes = aBytes - PrevBytes;
            long tickCount = DateTime.Now.Ticks;
            long msLen = tickCount - PrevTickCount;
            SetPrevData(aBytes, tickCount);
            CheckQueueEnd();
            SetTotal(msLen, lenBytes);
            SetSampleData(msLen, lenBytes);
            
        }

        private void SetPrevData(ulong aBytes, long tickCount)
        {
            PrevBytes = aBytes;
            PrevTickCount = tickCount;
        }

        private void CheckQueueEnd()
        {
            if(Samples.Count == Capacity)
            {
                AVG_STR sample = Samples.Dequeue();
                TotalBytes -= sample.Bytes;
                TotalTime -= sample.Millisecs;
            }
        }

        private void SetTotal(long msLen, ulong lenBytes)
        {
            TotalTime += msLen;
            TotalBytes += lenBytes;
        }

        private void SetSampleData(long msLen, ulong lenBytes)
        {
            AVG_STR sample = new AVG_STR(lenBytes, msLen);
            Samples.Enqueue(sample);
        }

        private void Reset()
        {
            TotalBytes = 0;
            TotalTime = 0;
            PrevTickCount = DateTime.Now.Ticks;
            PrevBytes = 0;
        }

        private bool CheckStatus()
        {
            if (Samples.Count == 0 || TotalTime == 0 || TotalBytes == 0)
                return false;
            return true;
        }

        public string GetBps()
        {
            System.Console.WriteLine("NumSamples:{0}; TotalTime:{1}; TotalBytes{2}", Samples.Count, TotalTime, TotalBytes);
            double bps;
            if (!CheckStatus())
            {
                
                return "0";
            }

            TimeSpan elapsed = new TimeSpan(TotalTime);
            bps = (double)TotalBytes * 8 / elapsed.TotalSeconds / 1000;
            
            return bps.ToString("#.####");
        }
    }
}
