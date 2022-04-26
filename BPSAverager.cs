using System;
using System.Collections.Generic;

namespace GraphSample
{
    class AVG_STR
    {
        public ulong Bytes { get; set; }
        public long Ticks { get; set; }

        public AVG_STR(ulong count, long ticks)
        {
            this.Bytes = count;
            this.Ticks = ticks;
        }
    }

    class BPSAverager
    {
        private const int Capacity = 6;
        Queue<AVG_STR> Samples;
        private ulong TotalBytes;
        private long TotalTime;
        private long PrevTickCount;
        private ulong PrevBytes;
        private bool start;

        public BPSAverager()
        {
            Samples = new Queue<AVG_STR>();
            start = false;
        }

        public void Add(ulong aBytes)
        {
            if (!CheckStart())
            {
                SetPrevData(aBytes, DateTime.Now.Ticks);
                return;
            }
            SetParams(aBytes);
        }

        public void SetParams(ulong aBytes)
        {
            ulong lenBytes = aBytes - PrevBytes;
            long ticksLen = DateTime.Now.Ticks - PrevTickCount;
            SetPrevData(aBytes, DateTime.Now.Ticks);
            CheckQueueEnd();
            SetTotal(ticksLen, lenBytes);
            SetSampleData(ticksLen, lenBytes);
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
                TotalTime -= sample.Ticks; 
            }
            
        }

        private void SetTotal(long ticksLen, ulong lenBytes)
        {
            TotalTime += ticksLen;
            TotalBytes += lenBytes;
        }

        private void SetSampleData(long ticksLen, ulong lenBytes)
        {
            AVG_STR sample = new AVG_STR(lenBytes, ticksLen);
            Samples.Enqueue(sample);
        }

        private bool CheckStart()
        {
            if (!start)
            {
                start = true;
                return false;
            }   
            return true;
        }

        private bool CheckStatus()
        {
            if (Samples.Count == 0 || TotalTime == 0 || TotalBytes == 0)
                return false;
            return true;
        }

        private double ParseToMBPs()
        {
            double bps;
            TimeSpan elapsed = new TimeSpan(TotalTime);
            bps = (double)TotalBytes / elapsed.TotalSeconds / 1000 / 1000 * 8;
            return bps;
        }

        public string GetBps()
        {
            if (!CheckStatus())
            {
                return "0";
            }

            return ParseToMBPs().ToString("#.####");
        }
    }
}
