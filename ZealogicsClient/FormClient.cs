using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZealogicsSocket.App;

namespace ZealogicsClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private async void RequestBtn_Click(object sender, EventArgs e)
        {
            ResultText.Text = "";
            this.Refresh();

            Thread.Sleep(300);

            string result = string.Empty;

            await Task.Run(() =>
            {
                ClientService client = new ClientService(new TcpClientAdapter(),IpText.Text, PortText.Text);
                result = client.DownloadFile(FileNameText.Text, SavePathText.Text);
            });
     
            ResultText.Text = result;
        }
    }
}
