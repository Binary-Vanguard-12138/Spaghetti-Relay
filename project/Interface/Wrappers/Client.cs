using System.Runtime.InteropServices;

namespace Message_Relay_GUI
{
    public class Client
    {
      #if MONO
		[DllImport("libClient.so")]
        public static extern int init(ushort port, [MarshalAs(UnmanagedType.LPStr)] string address);

        [DllImport("libClient.so")]
        public static extern int readMessage(byte[] buffer, int length);

        [DllImport("libClient.so")]
        public static extern int sendMessage([MarshalAs(UnmanagedType.LPStr)] string data, int length);

        [DllImport("libClient.so")]
        public static extern void stop();
      #else
		[DllImport("Client.dll",CallingConvention = CallingConvention.Cdecl)]
        public static extern int init(ushort port, [MarshalAs(UnmanagedType.LPStr)] string address);

        [DllImport("Client.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int readMessage(byte[] buffer, int length);

        [DllImport("Client.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sendMessage([MarshalAs(UnmanagedType.LPStr)] string data, int length);

        [DllImport("Client.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void stop();
      #endif
	}
}
