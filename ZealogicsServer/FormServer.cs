using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using ZealogicsSocket.App;

namespace ZealogicsServer
{
    public partial class FormServer : Form
    {
        private delegate void DelSetText(Control ctrl, string text);
        public FormServer()
        {
            InitializeComponent();

            var localIp = ConfigurationManager.AppSettings["LocalIp"];
            var port = ConfigurationManager.AppSettings["Port"];

            Server server = new Server(localIp, port);
            server.Start(result =>
            {
                SetText(IpText, result.ip);
                SetText(PortText, result.port);
                SetText(FileNameText, result.fileName);
            });
        }

        private void SetText(Control ctrl, string text)
        {
            if (this.InvokeRequired)
            {
                DelSetText del = new DelSetText(SetText);
                this.Invoke(del, ctrl, text);
            }
            else
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = text;
                }
            }
        }
    }
}
