﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string path = @"fuzzysearch/inspire/search/" +
                            @"roundTripCity?callback=jQuery17205575992022641003_1448759871196&depCode=BJS" +
                            @"&arr=%E4%B8%9C%E4%BA%AC(TYO)&arrType=1&interval=4%2C5&filter=%7B%7D&" +
                            @"depDateRange =2016-01-01~2016-01-" +
                            @"31%7C1%2C2016-02-01~2016-02-29%7C1%2C2016-03-01~2016-03-31%7C1&_=1448764182303";
            
            WebUtil webUtil = new WebUtil();
            webUtil.GetResponse(domain, path);
        }
    }
}
