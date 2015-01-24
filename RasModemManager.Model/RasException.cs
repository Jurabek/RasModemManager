using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasModemManager.Model
{
    /// <summary>
    /// RasException
    /// </summary>
    public class RasException : Exception
    {
        private uint _ErrorCode;

        public uint ErrorCode
        {
            get
            {
                return _ErrorCode;
            }
        }

        public RasException()
        {
        }

        public RasException(uint errorCode)
            : base(RasException.Code2RasErrorMessage(errorCode))
        {
            _ErrorCode = errorCode;
        }

        internal static string Code2RasErrorMessage(uint errorCode)
        {
            string ret = "";
            try
            {
                StringBuilder sb = new StringBuilder(512);
                if (RasAPI.RasGetErrorString(errorCode, sb, sb.Capacity) > 0)
                    throw new Exception("Unknow RAS exception.");
                ret = sb.ToString();
            }
            catch (Exception e)
            {
                ret = string.Format("ErrorCode:{0},{1}", errorCode, e.Message);
            }
            return ret;
        }
    }
}
