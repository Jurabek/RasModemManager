using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RasModemManager.Model
{
    public class RasEntry
    {
        public RasEntry()
        {

        }
        private string _EntryName;
        private _RASENTRY _Entry = new _RASENTRY();
        private ArrayList _AlternateNumbers = new ArrayList();

        #region properties

        public string EntryName
        {
            get
            {
                return _EntryName;
            }
            set
            {
                _EntryName = value;
            }
        }

        public ArrayList AlternateNumbers
        {
            get
            {
                return this._AlternateNumbers;
            }
        }

        public uint Options
        {
            get
            {
                return _Entry.dwfOptions;
            }
            set
            {
                _Entry.dwfOptions = value;
            }
        }

        //
        // Location/phone number.
        //
        public int CountryID
        {
            get
            {
                return _Entry.dwCountryID;
            }
            set
            {
                _Entry.dwCountryID = value;
            }
        }

        public int CountryCode
        {
            get
            {
                return _Entry.dwCountryCode;
            }
            set
            {
                _Entry.dwCountryCode = value;
            }
        }

        public string AreaCode
        {
            get
            {
                return _Entry.szAreaCode;
            }
            set
            {
                _Entry.szAreaCode = value;
            }
        }

        public string LocalPhoneNumber
        {
            get
            {
                return _Entry.szLocalPhoneNumber;
            }
            set
            {
                _Entry.szLocalPhoneNumber = value;
            }
        }

        //
        // PPP/Ip
        //
        public RASIPADDR IpAddress
        {
            get
            {
                return _Entry.ipaddr;
            }
            set
            {
                _Entry.ipaddr = value;
            }
        }

        public RASIPADDR Dns
        {
            get
            {
                return _Entry.ipaddrDns;
            }
            set
            {
                _Entry.ipaddrDns = value;
            }
        }

        public RASIPADDR DnsAlternate
        {
            get
            {
                return _Entry.ipaddrDnsAlt;
            }
            set
            {
                _Entry.ipaddrDnsAlt = value;
            }
        }

        public RASIPADDR Wins
        {
            get
            {
                return _Entry.ipaddrWins;
            }
            set
            {
                _Entry.ipaddrWins = value;
            }
        }

        public RASIPADDR WinsAlternate
        {
            get
            {
                return _Entry.ipaddrWinsAlt;
            }
            set
            {
                _Entry.ipaddrWinsAlt = value;
            }
        }

        //
        // Framing
        //
        public int FrameSize
        {
            get
            {
                return _Entry.dwFrameSize;
            }
            set
            {
                _Entry.dwFrameSize = value;
            }
        }

        public int NetProtocols
        {
            get
            {
                return _Entry.dwfNetProtocols;
            }
            set
            {
                _Entry.dwfNetProtocols = value;
            }
        }

        public int FramingProtocol
        {
            get
            {
                return _Entry.dwFramingProtocol;
            }
            set
            {
                _Entry.dwFramingProtocol = value;
            }
        }

        //
        // Scripting
        //
        public string Script
        {
            get
            {
                return _Entry.szScript;
            }
            set
            {
                _Entry.szScript = value;
            }
        }

        //
        // Device
        //
        public string DeviceType
        {
            get
            {
                return _Entry.szDeviceType;
            }
            set
            {
                _Entry.szDeviceType = value;
            }
        }

        public string DeviceName
        {
            get
            {
                return _Entry.szDeviceName;
            }
            set
            {
                _Entry.szDeviceName = value;
            }
        }
        //
        // X.25
        //
        public string X25PadType
        {
            get
            {
                return _Entry.szX25PadType;
            }
            set
            {
                _Entry.szX25PadType = value;
            }
        }

        public string X25Address
        {
            get
            {
                return _Entry.szX25Address;
            }
            set
            {
                _Entry.szX25Address = value;
            }
        }

        public string X25Facilities
        {
            get
            {
                return _Entry.szX25Facilities;
            }
            set
            {
                _Entry.szX25Facilities = value;
            }
        }

        public string X25UserData
        {
            get
            {
                return _Entry.szX25UserData;
            }
            set
            {
                _Entry.szX25UserData = value;
            }
        }

        public int Channels
        {
            get
            {
                return _Entry.dwChannels;
            }
            set
            {
                _Entry.dwChannels = value;
            }
        }
        //
        // Reserved
        //
#if WINVER4
  //
  // Multilink and BAP
  //
		public int SubEntries
		{
			get
			{
				return _Entry.dwSubEntries;
			}
			set
			{
				_Entry.dwSubEntries=value;
			}
		}

		public int DialMode
		{
			get
			{
				return _Entry.dwDialMode;
			}
			set
			{
				_Entry.dwDialMode=value;
			}
		}

		public int DialExtraPercent
		{
			get
			{
				return _Entry.dwDialExtraPercent;
			}
			set
			{
				_Entry.dwDialExtraPercent=value;
			}
		}

		public int DialExtraSampleSeconds
		{
			get
			{
				return _Entry.dwDialExtraSampleSeconds;
			}
			set
			{
				_Entry.dwDialExtraSampleSeconds=value;
			}
		}

		public int HangUpExtraPercent
		{
			get
			{
				return _Entry.dwHangUpExtraPercent;
			}
			set
			{
				_Entry.dwHangUpExtraPercent=value;
			}
		}

		public int HangUpExtraSampleSeconds
		{
			get
			{
				return _Entry.dwHangUpExtraSampleSeconds;
			}
			set
			{
				_Entry.dwHangUpExtraSampleSeconds=value;
			}
		}
		//
		// Idle time out
		//
		public int IdleDisconnectSeconds
		{
			get
			{
				return _Entry.dwIdleDisconnectSeconds;
			}
			set
			{
				_Entry.dwIdleDisconnectSeconds=value;
			}
		}
#endif
#if WINVER5
		public EntryTypes Type
		{
			get
			{
				return _Entry.dwType;
			}
			set
			{
				_Entry.dwType=value;
			}
		}

		public EncryptionTypes EncryptionType
		{
			get
			{
				return _Entry.dwEncryptionType;
			}
			set
			{
				_Entry.dwEncryptionType=value;
			}
		}

		public int CustomAuthKey
		{
			get
			{
				return _Entry.dwCustomAuthKey;
			}
			set
			{
				_Entry.dwCustomAuthKey=value;
			}
		}

		public GUID GuidId
		{
			get
			{
				return _Entry.guidId;
			}
		}
#endif
        #endregion

        public RasEntry(string entryName, string localPhoneNumber, string deviceType, string deviceName)
            : this(entryName, localPhoneNumber, deviceType, deviceName, 1, 0x3d0d0318)
        { }

        public RasEntry(string entryName, string localPhoneNumber, string deviceType, string deviceName, int framingProtocol, uint options)
        {
            this.EntryName = entryName;
            this._Entry.dwSize = Marshal.SizeOf(typeof(_RASENTRY));
            this.LocalPhoneNumber = localPhoneNumber;
            this.DeviceType = deviceType;
            this.DeviceName = deviceName;
            this.FramingProtocol = framingProtocol;
            this.Options = options;
            this._Entry.dwAlternateOffset = this._Entry.dwSize;
        }

        internal RasEntry(string entryName)
            : this(null, entryName)
        { }

        internal RasEntry(string phoneBook, string entryName)
        {
            this.EntryName = entryName;
            int entrySize = Marshal.SizeOf(typeof(_RASENTRY));
            int lpSize = entrySize;
            IntPtr buff = IntPtr.Zero;
        GetProperty:
            try
            {
                buff = Marshal.AllocHGlobal(lpSize);
                Marshal.WriteInt32(buff, entrySize);
                RasAPI.RasCheck(RasAPI.RasGetEntryProperties(phoneBook, entryName, buff, ref lpSize, 0, 0));
                _Entry = (_RASENTRY)Marshal.PtrToStructure(buff, typeof(_RASENTRY));
                char[] sbuff;
                if (lpSize > entrySize)
                {
                    int count = lpSize - entrySize;
                    sbuff = new char[count / Marshal.SystemDefaultCharSize];
                    Marshal.Copy(new IntPtr(buff.ToInt32() + entrySize), sbuff, 0, count / Marshal.SystemDefaultCharSize);
                    StringBuilder sb = new System.Text.StringBuilder();
                    int zeroChar = 0;
                    foreach (char ch in sbuff)
                    {
                        if (ch != '\0')
                        {
                            zeroChar = 0;
                            sb.Append(ch);
                        }
                        else
                        {
                            zeroChar++;
                            if (zeroChar > 1)
                                break;
                            this._AlternateNumbers.Add(sb.ToString());
                            sb.Length = 0;
                        }
                    }
                }

                Marshal.FreeHGlobal(buff);
            }
            catch (RasException e)
            {
                if (e.ErrorCode == (uint)RasError.ERROR_BUFFER_TOO_SMALL)
                {
                    Marshal.FreeHGlobal(buff);
                    goto GetProperty;
                }
                throw;
            }
        }

        public static bool Exist(string entryName)
        {
            return Exist(entryName, null);
        }

        public static bool Exist(string entryName, string phoneBook)
        {
            try
            {
                RasAPI.RasCheck(RasAPI.RasValidateEntryName(phoneBook, entryName));
            }
            catch (RasException e)
            {
                if (e.ErrorCode == (uint)RasError.ERROR_ALREADY_EXISTS)
                    return true;
            }
            return false;
        }

        public static string[] GetEntryNames()
        {
            return GetEntryNames(null);
        }

        public static string[] GetEntryNames(string phoneBook)
        {
            string[] ret = new string[0];
            int entryNameSize = Marshal.SizeOf(typeof(RasEntryName));
            int lpNames = 1;
        EnumNames:
            try
            {
                int lpSize = lpNames * entryNameSize;
                RasEntryName[] names = new RasEntryName[lpNames];
                for (int i = 0; i < names.Length; i++)
                {
                    names[i].dwSize = entryNameSize;
                }
                RasAPI.RasCheck(RasAPI.RasEnumEntries(null, phoneBook, names, ref lpSize, out lpNames));
                if (lpNames > 0)
                {
                    ret = new string[lpNames];
                    for (int i = 0; i < lpNames; i++)
                    {
                        ret[i] = names[i].szEntryName;
                    }
                }
            }
            catch (RasException e)
            {
                if (e.ErrorCode == (uint)RasError.ERROR_BUFFER_TOO_SMALL)
                {
                    goto EnumNames;
                }
                throw;
            }
            return ret;
        }

        public static RasEntry[] GetEntrys()
        {
            return GetEntrys(null);
        }

        public static RasEntry[] GetEntrys(string phoneBook)
        {
            RasEntry[] ret = new RasEntry[0];
            string[] entryNames = GetEntryNames(phoneBook);
            if (entryNames.Length > 0)
            {
                ret = new RasEntry[entryNames.Length];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = new RasEntry(entryNames[i]);
                }
            }
            return ret;
        }

        public static RasEntry GetEntry(string entryName)
        {
            return GetEntry(null, entryName);
        }

        public static RasEntry GetEntry(string phoneBook, string entryName)
        {
            return new RasEntry(phoneBook, entryName);
        }

        public static void SetEntry(RasEntry entry)
        {
            SetEntry(null, entry);
        }

        public static void SetEntry(string phoneBook, RasEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException();
            int altNumbersSize = 0;
            IntPtr buff;
            int buffSize;
            int entrySize = Marshal.SizeOf(typeof(_RASENTRY));
            buffSize = entrySize;
            if (entry.AlternateNumbers.Count > 0)
            {
                entry._Entry.dwAlternateOffset = entrySize;
                foreach (string s in entry.AlternateNumbers)
                {
                    altNumbersSize += (s.Length + 1);
                }
                altNumbersSize++;
                char[] chbuff = new char[altNumbersSize];
                int offset = 0;
                foreach (string s in entry.AlternateNumbers)
                {
                    char[] chs = s.ToCharArray();
                    Array.Copy(chs, 0, chbuff, offset, chs.Length);
                    offset += (chs.Length + 1);
                }
                buffSize += (altNumbersSize * Marshal.SystemDefaultCharSize);
                buff = Marshal.AllocHGlobal(buffSize);
                IntPtr pEntry = Marshal.AllocHGlobal(entrySize);
                Marshal.StructureToPtr(entry._Entry, pEntry, false);
                byte[] tmpBuff = new byte[entrySize];
                Marshal.Copy(pEntry, tmpBuff, 0, entrySize);
                Marshal.Copy(tmpBuff, 0, buff, entrySize);
                Marshal.Copy(chbuff, 0, new IntPtr(buff.ToInt32() + entrySize), chbuff.Length);
                RasAPI.RasCheck(RasAPI.RasSetEntryProperties(phoneBook, entry.EntryName, buff, buffSize, 0, 0));
                Marshal.DestroyStructure(pEntry, typeof(_RASENTRY));
                Marshal.FreeHGlobal(pEntry);
                Marshal.FreeHGlobal(buff);
            }
            else
            {
                RasAPI.RasCheck(RasAPI.RasSetEntryProperties(phoneBook, entry.EntryName, ref entry._Entry, buffSize, 0, 0));
            }
        }

        public static void DeleteEntry(string entryName)
        {
            DeleteEntry(null, entryName);
        }

        public static void DeleteEntry(string phoneBook, string entryName)
        {
            RasAPI.RasCheck(RasAPI.RasDeleteEntry(phoneBook, entryName));
        }
    }
}
