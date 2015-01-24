#define WINVER4
#define WINVER5
//#define WINVER501
using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;

namespace RasModemManager.Model
{
    public enum RasFieldSizeConstants
    {
        RAS_MaxDeviceType = 16,
        RAS_MaxPhoneNumber = 128,
        RAS_MaxIpAddress = 15,
        RAS_MaxIpxAddress = 21,
#if WINVER4
		RAS_MaxEntryName      =256,
		RAS_MaxDeviceName     =128,
		RAS_MaxCallbackNumber =RAS_MaxPhoneNumber,
#else
        RAS_MaxEntryName = 20,
        RAS_MaxDeviceName = 32,
        RAS_MaxCallbackNumber = 48,
#endif

        RAS_MaxAreaCode = 10,
        RAS_MaxPadType = 32,
        RAS_MaxX25Address = 200,
        RAS_MaxFacilities = 200,
        RAS_MaxUserData = 200,
        RAS_MaxReplyMessage = 1024,
        RAS_MaxDnsSuffix = 256,
        UNLEN = 256,
        PWLEN = 256,
        DNLEN = 15
    }

    public enum RASNOTIFICATION : uint
    {
        RASCN_Connection = 0x00000001,
        RASCN_Disconnection = 0x00000002,
        RASCN_BandwidthAdded = 0x00000004,
        RASCN_BandwidthRemoved = 0x00000008,
        RASCN_All = RASCN_Connection | RASCN_Disconnection | RASCN_BandwidthAdded | RASCN_BandwidthRemoved
    }

    public enum EncryptionTypes
    {
        ET_None = 0,  // No encryption
        ET_Require = 1,  // Require Encryption
        ET_RequireMax = 2,  // Require max encryption
        ET_Optional = 3  // Do encryption if possible. None Ok.
    }

    public enum EntryTypes
    {
        RASET_Phone = 1,  // Phone lines: modem, ISDN, X.25, etc
        RASET_Vpn = 2,  // Virtual private network
        RASET_Direct = 3,  // Direct connect: serial, parallel
        RASET_Internet = 4  // BaseCamp internet
#if WINVER501
			RASET_Broadband 5  // Broadband
#endif
    }

    public enum EntryProtocols
    {
        RASNP_NetBEUI = 0x00000001,
        RASNP_Ipx = 0x00000002,
        RASNP_Ip = 0x00000004
    }

    public enum EntryFramingProtocols
    {
        /* _RASENTRY 'dwFramingProtocols' bit flags.
        */
        RASFP_Ppp = 0x00000001,
        RASFP_Slip = 0x00000002,
        RASFP_Ras = 0x00000004
    }

    public enum EntryOptions : uint
    {
        RASEO_UseCountryAndAreaCodes = 0x00000001,
        RASEO_SpecificIpAddr = 0x00000002,
        RASEO_SpecificNameServers = 0x00000004,
        RASEO_IpHeaderCompression = 0x00000008,
        RASEO_RemoteDefaultGateway = 0x00000010,
        RASEO_DisableLcpExtensions = 0x00000020,
        RASEO_TerminalBeforeDial = 0x00000040,
        RASEO_TerminalAfterDial = 0x00000080,
        RASEO_ModemLights = 0x00000100,
        RASEO_SwCompression = 0x00000200,
        RASEO_RequireEncryptedPw = 0x00000400,
        RASEO_RequireMsEncryptedPw = 0x00000800,
        RASEO_RequireDataEncryption = 0x00001000,
        RASEO_NetworkLogon = 0x00002000,
        RASEO_UseLogonCredentials = 0x00004000,
        RASEO_PromoteAlternates = 0x00008000,

#if WINVER4
			RASEO_SecureLocalFiles      =0x00010000,
#endif

#if WINVER5
			RASEO_RequireEAP                =0x00020000,
			RASEO_RequirePAP                =0x00040000,
			RASEO_RequireSPAP               =0x00080000,
			RASEO_Custom                    =0x00100000,

			RASEO_PreviewPhoneNumber        =0x00200000,
			RASEO_SharedPhoneNumbers        =0x00800000,
			RASEO_PreviewUserPw             =0x01000000,
			RASEO_PreviewDomain             =0x02000000,
			RASEO_ShowDialingProgress       =0x04000000,
			RASEO_RequireCHAP               =0x08000000,
			RASEO_RequireMsCHAP             =0x10000000,
			RASEO_RequireMsCHAP2            =0x20000000,
			RASEO_RequireW95MSCHAP          =0x40000000,
			RASEO_CustomScript              =0x80000000
#endif

#if WINVER501
			//
			// _RASENTRY dwfOptions2 bit flags
			//
			RASEO2_SecureFileAndPrint       0x00000001
			RASEO2_SecureClientForMSNet     0x00000002
			RASEO2_DontNegotiateMultilink   0x00000004
			RASEO2_DontUseRasCredentials    0x00000008
			RASEO2_UsePreSharedKey          0x00000010
			RASEO2_Internet                 0x00000020
			RASEO2_DisableNbtOverIP         0x00000040
			RASEO2_UseGlobalDeviceSettings  0x00000080
			RASEO2_ReconnectIfDropped       0x00000100
			RASEO2_SharePhoneNumbers        0x00000200
#endif
    }

    public enum RASCONNSTATE
    {
        RASCS_OpenPort = 0,
        RASCS_PortOpened,
        RASCS_ConnectDevice,
        RASCS_DeviceConnected,
        RASCS_AllDevicesConnected,
        RASCS_Authenticate,
        RASCS_AuthNotify,
        RASCS_AuthRetry,
        RASCS_AuthCallback,
        RASCS_AuthChangePassword,
        RASCS_AuthProject,
        RASCS_AuthLinkSpeed,
        RASCS_AuthAck,
        RASCS_ReAuthenticate,
        RASCS_Authenticated,
        RASCS_PrepareForCallback,
        RASCS_WaitForModemReset,
        RASCS_WaitForCallback,
        RASCS_Projected,

#if (WINVER4) 
		RASCS_StartAuthentication,    // Windows 95 only 
		RASCS_CallbackComplete,       // Windows 95 only 
		RASCS_LogonNetwork,           // Windows 95 only 
#endif
        RASCS_SubEntryConnected,
        RASCS_SubEntryDisconnected,

        RASCS_Interactive = RASCS_PAUSED,
        RASCS_RetryAuthentication,
        RASCS_CallbackSetByCaller,
        RASCS_PasswordExpired,
#if (WINVER5)
		RASCS_InvokeEapUI,
#endif
        RASCS_Connected = RASCS_DONE,
        RASCS_Disconnected,
        RASCS_PAUSED = 0x1000,
        RASCS_DONE = 0x2000
    }

    public enum RASPROJECTION
    {
        RASP_Amb = 0x10000,
        RASP_PppNbf = 0x803F,
        RASP_PppIpx = 0x802B,
        RASP_PppIp = 0x8021,
        RASP_PppCcp = 0x80FD,
        RASP_PppLcp = 0xC021,
        RASP_Slip = 0x20000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class RASPPPIP
    {
        public readonly int dwSize = Marshal.SizeOf(typeof(RASPPPIP));
        public uint dwError = 0;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxIpAddress + 1)]
        public string szIpAddress = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxIpAddress + 1)]
        public string szServerIpAddress = null;
#if WINVER501
		public uint     dwOptions=0;
		public uint     dwServerOptions=0;
#endif
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RASEAPINFO
    {
        public uint dwSizeofEapInfo;
        public int pbEapInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class RASDIALEXTENSIONS
    {
        public readonly int dwSize = Marshal.SizeOf(typeof(RASDIALEXTENSIONS));
        public uint dwfOptions = 0;
        public int hwndParent = 0;
        public int reserved = 0;
        public int reserved1 = 0;
        public RASEAPINFO RasEapInfo = new RASEAPINFO();
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class RASDIALPARAMS
    {
        public int dwSize = Marshal.SizeOf(typeof(RASDIALPARAMS));
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxEntryName + 1)]
        public string szEntryName = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxPhoneNumber + 1)]
        public string szPhoneNumber = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxCallbackNumber + 1)]
        public string szCallbackNumber = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.UNLEN + 1)]
        public string szUserName = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.PWLEN + 1)]
        public string szPassword = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.DNLEN + 1)]
        public string szDomain = null;
        public int dwSubEntry = 0;
        public int dwCallbackId = 0;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class RasStats
    {
        public int dwSize = Marshal.SizeOf(typeof(RasStats));
        public int dwBytesXmited;
        public int dwBytesRcved;
        public int dwFramesXmited;
        public int dwFramesRcved;
        public int dwCrcErr;
        public int dwTimeoutErr;
        public int dwAlignmentErr;
        public int dwHardwareOverrunErr;
        public int dwFramingErr;
        public int dwBufferOverrunErr;
        public int dwCompressionRatioIn;
        public int dwCompressionRatioOut;
        public int dwBps;
        public int dwConnectDuration;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RASIPADDR
    {
        byte a;
        byte b;
        byte c;
        byte d;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct _RASENTRY
    {
        public int dwSize;
        public uint dwfOptions;
        //
        // Location/phone number.
        //
        public int dwCountryID;
        public int dwCountryCode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxAreaCode + 1)]
        public string szAreaCode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxPhoneNumber + 1)]
        public string szLocalPhoneNumber;
        public int dwAlternateOffset;
        //
        // PPP/Ip
        //
        public RASIPADDR ipaddr;
        public RASIPADDR ipaddrDns;
        public RASIPADDR ipaddrDnsAlt;
        public RASIPADDR ipaddrWins;
        public RASIPADDR ipaddrWinsAlt;
        //
        // Framing
        //
        public int dwFrameSize;
        public int dwfNetProtocols;
        public int dwFramingProtocol;
        //
        // Scripting
        //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]//MAX_PATH
        public string szScript;
        //
        // AutoDial
        //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]//MAX_PATH
        public string szAutodialDll;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]//MAX_PATH
        public string szAutodialFunc;
        //
        // Device
        //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceType + 1)]
        public string szDeviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceName + 1)]
        public string szDeviceName;
        //
        // X.25
        //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxPadType + 1)]//MAX_PATH
        public string szX25PadType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxX25Address + 1)]//MAX_PATH
        public string szX25Address;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxFacilities + 1)]//MAX_PATH
        public string szX25Facilities;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxUserData + 1)]//MAX_PATH
        public string szX25UserData;
        public int dwChannels;
        //
        // Reserved
        //
        public int dwReserved1;
        public int dwReserved2;
#if WINVER4
  //
  // Multilink and BAP
  //
		public int       dwSubEntries;
		public int       dwDialMode;
		public int       dwDialExtraPercent;
		public int       dwDialExtraSampleSeconds;
		public int       dwHangUpExtraPercent;
		public int       dwHangUpExtraSampleSeconds;
		//
		// Idle time out
		//
		public int       dwIdleDisconnectSeconds;
#endif
#if WINVER5
		public EntryTypes     dwType;               // entry type
		public EncryptionTypes     dwEncryptionType;     // type of encryption to use
		public int     dwCustomAuthKey;      // authentication key for EAP
		public GUID      guidId;               // guid that represents 
								  // the phone-book entry 
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=260)]//MAX_PATH
		public string    szCustomDialDll;    // DLL for custom dialing 
		public int    dwVpnStrategy;         // specifies type of VPN protocol 
#endif
#if WINVER501
		public int     dwfOptions2;
		public int     dwfOptions3;
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=(int)RasFieldSizeConstants.RAS_MaxDnsSuffix+1)]//MAX_PATH
		public string     szDnsSuffix;
		public int     dwTcpWindowSize;
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=260)]//MAX_PATH
		public string     szPrerequisitePbk;
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=(int)RasFieldSizeConstants.RAS_MaxEntryName+1)]//MAX_PATH
		public string     szPrerequisiteEntry;
		public int     dwRedialCount;
		public int     dwRedialPause;
#endif
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RasEntryName
    {
        public int dwSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxEntryName + 1)]
        public string szEntryName;
#if WINVER5
		public int dwFlags;
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=260+1)]
		public string szPhonebookPath;
#endif
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct GUID
    {
        public uint Data1;
        public ushort Data2;
        public ushort Data3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Data4;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RASCONN
    {
        public int dwSize;
        public IntPtr hrasconn;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxEntryName + 1)]
        public string szEntryName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceType + 1)]
        public string szDeviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceName + 1)]
        public string szDeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]//MAX_PAPTH=260
        public string szPhonebook;
        public int dwSubEntry;
        public GUID guidEntry;
#if (WINVER501)
  int     dwFlags;
  public LUID      luid;
#endif
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LUID
    {
        int LowPart;
        int HighPart;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RASDEVINFO
    {
        public int dwSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceType + 1)]
        public string szDeviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceName + 1)]
        public string szDeviceName;
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class RASCONNSTATUS
    {
        public readonly int dwSize = Marshal.SizeOf(typeof(RASCONNSTATUS));
        public RASCONNSTATE rasconnstate = RASCONNSTATE.RASCS_OpenPort;
        public int dwError = 0;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceType + 1)]
        public string szDeviceType = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)RasFieldSizeConstants.RAS_MaxDeviceName + 1)]
        public string szDeviceName = null;
    }

    public delegate void RasDialFunc(
        uint unMsg,                // type of event that has occurred
        RASCONNSTATE rasconnstate, // connection state about to be entered
        int dwError              // error that may have occurred
    );

    public delegate void RasDialFunc2(
        int dwCallbackId,    // user-defined value specified in
        //  RasDial call
        int dwSubEntry,      // subentry index in multilink connection
        IntPtr hrasconn,     // handle to RAS connection
        uint unMsg,            // type of event that has occurred
        RASCONNSTATE rascs,    // connection state about to be entered
        uint dwError,         // error that may have occurred
        uint dwExtendedError  // extended error information for
        //  some errors
    );

    public delegate void RasDialFunc1(
        IntPtr hrasconn,    // handle to RAS connection
        uint unMsg,           // type of event that has occurred
        RASCONNSTATE rascs,   // connection state about to be entered
        uint dwError,        // error that may have occurred
        uint dwExtendedError // extended error information for some errors
    );

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
    public struct RASDIALDLG
    {
        public int dwSize;
        public IntPtr hwndOwner;
        public int dwFlags;
        public int xDlg;
        public int yDlg;
        public int dwSubEntry;
        public int dwError;
        public IntPtr reserved;
        public IntPtr reserved2;
    }

    public sealed class RasAPI
    {
        private RasAPI() { }

        [DllImport("Rasdlg.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool RasDialDlg(IntPtr phoneBook,
            string entryName, IntPtr phoneNumber, ref RASDIALDLG info);

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasDial(
            [In]RASDIALEXTENSIONS lpRasDialExtensions,
            // pointer to function extensions data
            [In]string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            [In]RASDIALPARAMS lpRasDialParams,
            // pointer to calling parameters data
            uint dwNotifierType,   // specifies type of RasDial event handler
            IntPtr lpvNotifier,     // specifies a handler for RasDial events
            ref IntPtr lphRasConn   // pointer to variable to receive 
            //  connection handle
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasDial(
            [In]RASDIALEXTENSIONS lpRasDialExtensions,
            // pointer to function extensions data
            [In]string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            [In]RASDIALPARAMS lpRasDialParams,
            // pointer to calling parameters data
            uint dwNotifierType,   // specifies type of RasDial event handler
            RasDialFunc2 lpvNotifier,     // specifies a handler for RasDial events
            ref IntPtr lphRasConn   // pointer to variable to receive 
            //  connection handle
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasHangUp(
            IntPtr hrasconn  // handle to the RAS connection to hang up
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetErrorString(
            uint uErrorValue,        // error to get string for
            StringBuilder lpszErrorString,  // buffer to hold error string
            [In]int cBufSize           // size, in characters, of buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasEnumConnections(
            [In, Out]RASCONN[] lprasconn,   // buffer to receive connections data
            ref int lpcb,          // size in bytes of buffer
            out int lpcConnections // number of connections written to buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasEnumDevices(
            [In, Out]RASDEVINFO[] lpRasDevInfo,  // buffer to receive
            //  information about RAS devices
            ref int lpcb,               // size, in bytes, of the buffer
            out int lpcDevices          // receives the number of
            //  entries written to the buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetConnectStatus(
            IntPtr hrasconn,  // handle to RAS connection of interest
            [In, Out]RASCONNSTATUS lprasconnstatus
            // buffer to receive status data
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasConnectionNotification(
            IntPtr hrasconn,  // handle to a RAS connection
            IntPtr hEvent,      // handle to an event object
            uint dwFlags       // type of event to receive notifications for
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasConnectionNotification(
            IntPtr hrasconn,  // handle to a RAS connection
            IntPtr hEvent,      // handle to an event object
            RASNOTIFICATION dwFlags       // type of event to receive notifications for
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetEntryDialParams(
            string lpszPhonebook,  // pointer to the full path and
            //  file name of the phone-book file
            [In, Out]RASDIALPARAMS lprasdialparams,
            // pointer to a structure that
            //  receives the connection parameters
            out bool lpfPassword      // indicates whether the user's
            //  password was retrieved
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetConnectionStatistics(
            IntPtr hRasConn,       // handle to the connection
            [In, Out]RasStats lpStatistics  // buffer to receive statistics
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasEnumEntries(
            string reserved,              // reserved, must be NULL
            string lpszPhonebook,         // pointer to full path and
            //  file name of phone-book file
            [In, Out]RasEntryName[] lprasentryname, // buffer to receive
            //  phone-book entries
            ref int lpcb,                  // size in bytes of buffer
            out int lpcEntries             // number of entries written
            //  to buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetEntryProperties(
            string lpszPhonebook,      // pointer to full path and
            //  file name of phone-book file
            string lpszEntry,          // pointer to an entry name
            [In, Out]_RASENTRY[] lpRasEntry,      // buffer that receives entry information
            ref int lpdwEntryInfoSize,  // size, in bytes, of the
            //  lpRasEntry buffer
            int lpbDeviceInfo,       // buffer that receives
            //  device-specific configuration information
            int lpdwDeviceInfoSize  // size, in bytes, of the 
            //  lpbDeviceInfo buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetEntryProperties(
            string lpszPhonebook,      // pointer to full path and
            //  file name of phone-book file
            string lpszEntry,          // pointer to an entry name
            IntPtr lpRasEntry,      // buffer that receives entry information
            ref int lpdwEntryInfoSize,  // size, in bytes, of the
            //  lpRasEntry buffer
            int lpbDeviceInfo,       // buffer that receives
            //  device-specific configuration information
            int lpdwDeviceInfoSize  // size, in bytes, of the 
            //  lpbDeviceInfo buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasSetEntryProperties(
            string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            string lpszEntry,      // pointer to an entry name
            ref _RASENTRY lpRasEntry,  // buffer that contains entry information
            int dwEntryInfoSize,  // size, in bytes, of the
            //  lpRasEntry buffer
            int lpbDeviceInfo,   // buffer that contains device-
            //  specific configuration information
            int dwDeviceInfoSize  // size, in bytes, of the 
            //  lpbDeviceInfo buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasSetEntryProperties(
            string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            string lpszEntry,      // pointer to an entry name
            IntPtr lpRasEntry,  // buffer that contains entry information
            int dwEntryInfoSize,  // size, in bytes, of the
            //  lpRasEntry buffer
            int lpbDeviceInfo,   // buffer that contains device-
            //  specific configuration information
            int dwDeviceInfoSize  // size, in bytes, of the 
            //  lpbDeviceInfo buffer
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasValidateEntryName(
            string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            string lpszEntry       // pointer to the entry name to validate
            );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasDeleteEntry(
            string lpszPhonebook,  // pointer to full path and file 
            //  name of phone-book file
            string lpszEntry       // pointer to an entry name to delete
            );


        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasGetProjectionInfo(
            IntPtr hrasconn,  // handle to a RAS connection
            RASPROJECTION rasprojection,      // type of control protocol
            [In, Out] RASPPPIP lpprojection,	// pointer to a structure that
            //  receives the projection info
            ref uint lpcb	// size of projection structure
            );

        public static void RasCheck(uint errorCode)
        {
            if (errorCode != (uint)RasError.SUCCESS)
                throw new RasException(errorCode);
        }
    }
}
