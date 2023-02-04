using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TCP_Client
{
    public class MainMV : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public MainMV()
        {
            GetSendMsg = new  SendGetMsgCommand(this);
        }

        private string _message;
        private string outMsg;
        public ICommand GetSendMsg { get; set; }
        public string OutMsg
        {
            get
            {
                return outMsg;
            }
            set
            {
                outMsg = value;
                OnPropertyChanged(nameof(OutMsg));
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

    }
}
