using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace GetTickets
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string domain = @"http://flight.qunar.com/";
            string depDate = "2015-12-01~2015-12-31%7C1%2C2016-01-01~2016-01-31%7C1%2C2016-02-01~2016-02-29%7C1%2C2016-03-01~2016-03-31";
            //string days = "3-15";
            string days = "3%2C4%2C5%2C6%2C7%2C8";
            string path = @"fuzzysearch/inspire/search/" +
                            @"roundTripCity?callback=jQuery17205575992022641003_1448759871196&depCode=BJS" +
                            @"&arr=%E4%B8%9C%E4%BA%AC(TYO)&arrType=1&" +
                            @"interval=" + days +
                            @"&filter=%7B%7D&" +
                            @"depDateRange=" + depDate + "%7C1&_=1448764182303";

            


            Start(domain, path);
        }

        private async void Start(string domain, string path)
        {
            WebUtil webUtil = new WebUtil();
            while (true)
            {
                await webUtil.GetResponse(new URL(domain, path));
                Thread.Sleep(15 * 1000);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(@"Start a new circle" + DateTime.Now);
            }
        }

    }
}
