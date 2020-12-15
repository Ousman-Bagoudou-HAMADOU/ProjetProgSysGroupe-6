using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant;
using ProgSys;
using SimpleTCP;
using System.IO;
using System.Threading;

namespace Cuisine
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        int tmp = 0;
        int okc = 0;
        int tmpajt = 5;
        int np = 0;
        public Cuisine()
        {
            InitializeComponent();
        }
    }
}
