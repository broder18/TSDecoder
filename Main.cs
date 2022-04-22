﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GraphSample.Properties;

namespace GraphSample
{

    public partial class MainForm : Form
    {     
        private enum Pids
        {
            Pid0 = 0x85,
            Pid1 = 0x86,
            Pid2 = 0x87,
            Pid3 = 0x88,
            Pid4 = 0x89
        }

        private ulong _prevcount0;
        private ulong _prevcount1;
        private ulong _prevcount2;
        private ulong _prevcount3;
        private ulong _prevcount4;
        private RendererContainerForm[] _renderers;
        private BPSAverager bps_x85;
        
       
        

        public MainForm()
        {
            InitializeComponent();
            CreateListItems();
            bps_x85 = new BPSAverager();

            try
            {
                CreateWndRender();
                Dll.OpenRefact(Settings.Default.IP_address, Settings.Default.Port_address, ParseUshort(), ParseIntPtr());
                statsTimer.Enabled = true;
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statsTimer.Enabled = false;
            Dll.Close();
            CloseWndRender();
            SavePosition();
        }

        private void CreateListItems()
        {
            foreach(int pid in Enum.GetValues(typeof(Pids)))
            {
                var item = StatisticsList.Items.Add($"0x{(ushort)pid:X4}");
                item.SubItems.Add("0");
            }
        }

        private void CreateWndRender()
        {
            _renderers = new RendererContainerForm[5];
            byte id = 85;
            for(byte ind = 0; ind < _renderers.Length; ind++)
            {
                _renderers[ind] = new RendererContainerForm("x00" + id.ToString());
                _renderers[ind].Show();
                id++;
            }
        }

        private void CloseWndRender()
        {
            foreach(var render in _renderers)
            {
                render.Close(); 
            }
            _renderers = null;
        }

        private IntPtr[] ParseIntPtr()
        {
            IntPtr[] hWnd = new IntPtr[_renderers.Length];
            for(byte ind = 0; ind < _renderers.Length; ind++)
            {
                hWnd[ind] = _renderers[ind].Handle;
            }
            return hWnd;
        }

        private ushort[] ParseUshort()
        {
            ushort[] pids = new ushort[_renderers.Length];
            int ind = 0;
            foreach(int pid in Enum.GetValues(typeof(Pids)))
            {
                pids[ind++] = (ushort)pid;
            }
            return pids;
        }

        private void statsTimer_Tick(object sender, EventArgs e)
        { 
            
            var pstats = Marshal.AllocHGlobal(Marshal.SizeOf<Dll.PidStatistics>());

            if (Dll.GetStatistics(pstats))
            {
                Dll.PidStatistics stats = Marshal.PtrToStructure<Dll.PidStatistics>(pstats);
                Check_Stats(stats);
            }
            Marshal.FreeCoTaskMem(pstats);
        }

        private void Check_Stats( Dll.PidStatistics stats)
        {
            WriteStats(ref _prevcount0, 0, ref stats.Pids[(int)Pids.Pid0]);
            //StatisticsList.Items[0].SubItems[2].Text = bps_x85.GetBps().ToString();
            bps_x85.Add(stats.Pids[(int)Pids.Pid0]);
            //StatisticsList.Items[0].SubItems[2].Text = bps_x85.GetBps();
            System.Console.WriteLine(bps_x85.GetBps());
            WriteStats(ref _prevcount1, 1, ref stats.Pids[(int)Pids.Pid1]);
            WriteStats(ref _prevcount2, 2, ref stats.Pids[(int)Pids.Pid2]);
            WriteStats(ref _prevcount3, 3, ref stats.Pids[(int)Pids.Pid3]);
            WriteStats(ref _prevcount4, 4, ref stats.Pids[(int)Pids.Pid4]);
        }

        private void WriteStats( ref ulong view_count, int id, ref ulong read_count)
        {
            if (view_count != read_count)
            {
                
                view_count = read_count;
                StatisticsList.Items[id].SubItems[1].Text = view_count.ToString();
                
                //StatisticsList.Items[id].SubItems[1].Text = bps_x85.GetBps();
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            SaveAddress();
            Dll.SetIp(textBox_IP.Text, UInt16.Parse(textBox_Port.Text));
        }
    }
}
