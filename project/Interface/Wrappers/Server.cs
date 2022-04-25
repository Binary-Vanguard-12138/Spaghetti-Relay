using System.Runtime.InteropServices;

namespace Message_Relay_GUI
{
    public class Server
    {
      #if MONO
        [DllImport("libServer.so")]
        public static extern int init(ushort port);

        [DllImport("libServer.so")]
        public static extern int readMessage(byte[] buffer, int size);

        [DllImport("libServer.so")]
        public static extern int sendMessage([MarshalAs(UnmanagedType.LPStr)] string data, int length);

        [DllImport("libServer.so")]
        public static extern void stop();
      #else
		[DllImport("Server.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int init(ushort port);

        [DllImport("Server.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int readMessage(byte[] buffer, int size);

        [DllImport("Server.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sendMessage([MarshalAs(UnmanagedType.LPStr)] string data, int length);

        [DllImport("Server.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void stop();
      #endif
	}
}
