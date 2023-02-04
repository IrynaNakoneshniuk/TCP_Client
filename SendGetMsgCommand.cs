using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TCP_Client;
using TCPClient;

namespace TCP_Client
{
    public class SendGetMsgCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MainMV mv;
        public SendGetMsgCommand(MainMV mv)
        {
            this.mv = mv;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            TCP client = new TCP("127.0.0.1",8080);
            client.GetConnection();
            Task.Run(async () => { await client.SendMsg(mv.OutMsg); });
            mv.OutMsg= await client.GetMsg();
        }
    }
}
