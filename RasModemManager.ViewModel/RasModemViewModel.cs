using RasModemManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RasModemManager.ViewModel
{
    public class RasModemViewModel : INotifyPropertyChanged
    {
       
        public ObservableCollection<string> EntryNames 
        { 
            get 
            {
                var entryNames = new ObservableCollection<string>();
                foreach (string entryName in RasEntry.GetEntryNames())
                {
                    entryNames.Add(entryName);
                }
                return entryNames;
            } 
        }

        private string selectedEntryName;
        public string SelectedEntryName 
        {
            get { return selectedEntryName; }
            set { selectedEntryName = value; NotifyPropertyChanged(); }
        }

        private IntPtr _Handle;
        
        private const int ERROR_INVALID_HANDLE = 6;

        private RASDIALPARAMS _Params = new RASDIALPARAMS();
        
        public void Dial()
        {
            if (_Handle != IntPtr.Zero)
            {
                RASCONNSTATUS status = new RASCONNSTATUS();
                uint res = RasAPI.RasGetConnectStatus(_Handle, status);
                if (res == ERROR_INVALID_HANDLE) //res=ERROR_INVALID_HANDLE
                    _Handle = IntPtr.Zero;
                else
                    return;
            }
            else
            {
                _Params.dwSize = Marshal.SizeOf(_Params);
                _Params.szEntryName = SelectedEntryName;
                IntPtr notifyHandle = (IntPtr)null;
                RasAPI.RasDial(null, null, _Params, 0xFFFFFFFF, notifyHandle, ref _Handle);
            }
        }

        public void HandUp()
        {
            if (_Handle == IntPtr.Zero)
                return;
            uint res;
            RASCONNSTATUS status = new RASCONNSTATUS();
            res = RasAPI.RasGetConnectStatus(_Handle, status);
            if (res == 0 && status.rasconnstate != RASCONNSTATE.RASCS_Disconnected)
            {
                try
                {
                    RasAPI.RasCheck(RasAPI.RasHangUp(_Handle));
                    for (int i = 0; i < 30; i++)
                    {
                        res = RasAPI.RasGetConnectStatus(_Handle, status);
                        if (res == ERROR_INVALID_HANDLE || status.rasconnstate == RASCONNSTATE.RASCS_Disconnected)
                            break;
                    }
                }
                catch (RasException e)
                {
                    //OnError(e.ErrorCode, e.Message);
                }
            }
            _Handle = IntPtr.Zero;
        }

        public RasStats GetStats()
        {
            RasStats rs = new RasStats();
            try
            {
                RasAPI.RasCheck(RasAPI.RasGetConnectionStatistics(this._Handle, rs));
            }
            catch (RasException)
            {
            }
            return rs;
        }

        #region Notify

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
