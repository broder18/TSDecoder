using System;
using System.Net;
using System.Runtime.InteropServices;

namespace GraphSample
{
    public static class Dll
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct InputNetwork
        {
            public uint MulticastIp;
            public ushort MulticastPort;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct Pids
        {
            public ushort pid0;
            public ushort pid1;
            public ushort pid2;
            public ushort pid3;
            public ushort pid4;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct Hwnds
        {
            public IntPtr hwnd0;
            public IntPtr hwnd1;
            public IntPtr hwnd2;
            public IntPtr hwnd3;
            public IntPtr hwnd4;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct GsSettings
        {
            public uint Size;
            public InputNetwork InNet;
            public IntPtr hContainerWnd;
            public ushort VideoPid;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct GsSettingsRefact
        {
            public uint Size;
            public InputNetwork InNet;
            public Hwnds hContainerWnds;
            public Pids VideoPid;
            
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct PidStatistics
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x2000)]
            public UInt64[] Pids;
            public UInt64 BadPackets;
        }

        private static class NativeMethods
        {
            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsInitialize", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool gsInitialize();

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsUninitialize", CallingConvention = CallingConvention.StdCall)]
            public static extern void gsUninitialize();

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsGetLastError",  CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr gsGetLastError();

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsClose", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern void gsClose();

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsResizeRenderer", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool gsResizeRenderer(IntPtr hContainerWnd);

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsSetInputNetwork", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool gsSetInputNetwork(ref InputNetwork netsettings);

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsGetStatistics", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool gsGetStatistics(IntPtr stats);

            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsResetStatistics", CallingConvention = CallingConvention.StdCall)]
            public static extern void gsResetStatistics();


            [DllImport("GraphSampleDLL.dll", EntryPoint = "gsOpenRefact", CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool gsOpenRefact(ref GsSettingsRefact settings);

        }

        private static bool _dllInitialized;

        private static string GetLastError()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.gsGetLastError());
        }

        public static void Initialize()
        {
            if (!_dllInitialized)
            {
                if (!NativeMethods.gsInitialize()) throw new Exception("gsInitialize() failed: " + GetLastError());
                _dllInitialized = true;
            }
        }

        public static void Uninitialize()
        {
            if (_dllInitialized)
            {
                NativeMethods.gsUninitialize();
                _dllInitialized = false;
            }
        }

        private static uint InetAddr(string ip)
        {
            var addr = IPAddress.Parse(ip);
            return BitConverter.ToUInt32(addr.GetAddressBytes(), 0);
        }

        public static void OpenRefact(string ip, ushort port, ushort[] pids, IntPtr[] hWnds)
        {
            var settings = new GsSettingsRefact();
            settings.Size = (uint)Marshal.SizeOf(settings);
            settings.InNet.MulticastIp = InetAddr(ip);
            settings.InNet.MulticastPort = port;
            Add_Pids(ref settings, pids);
            Add_HWNDS(ref settings, hWnds);
           
            if (!NativeMethods.gsOpenRefact(ref settings)) throw new Exception("gsOpenRefact() failed: " + GetLastError());
        }

        private static void Add_Pids(ref GsSettingsRefact settings, ushort[] pids)
        {
            settings.VideoPid.pid0 = pids[0];
            settings.VideoPid.pid1 = pids[1];
            settings.VideoPid.pid2 = pids[2];
            settings.VideoPid.pid3 = pids[3];
            settings.VideoPid.pid4 = pids[4];
        }

        private static void Add_HWNDS(ref GsSettingsRefact settings, IntPtr[] hWnds)
        {
            settings.hContainerWnds.hwnd0 = hWnds[0];
            settings.hContainerWnds.hwnd1 = hWnds[1];
            settings.hContainerWnds.hwnd2 = hWnds[2];
            settings.hContainerWnds.hwnd3 = hWnds[3];
            settings.hContainerWnds.hwnd4 = hWnds[4];
        }

        public static void Close()
        {
            NativeMethods.gsClose();
        }

        public static void Resize(IntPtr hwnd)
        {
            if (!NativeMethods.gsResizeRenderer(hwnd)) throw new Exception("gsResizeRenderer() failed: " + GetLastError());
        }

        public static bool SetIp(string ip, ushort port)
        {
            var netsettings = new InputNetwork {MulticastIp = InetAddr(ip), MulticastPort = port};
            return NativeMethods.gsSetInputNetwork(ref netsettings);
        }

        public static bool GetStatistics(IntPtr stat)
        {
            return NativeMethods.gsGetStatistics(stat);
        }

        public static void ResetStatistics()
        {
            NativeMethods.gsResetStatistics();
        }
    }
}
