using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuisine
{
    public partial class Cuisine : Form
    {
        SimpleTcpServer server;
        int tmp = 0;
        int okc = 0;
        int tmpajt = 5;
        int np = 0;
        public Cuisine()
        {
            InitializeComponent();
            Cuisiniere.Location = new Point(1328, 150);
            ChefCuisine.Location = new Point(430, 55);
            ChefPartie.Location = new Point(500, 300);
            CommisCuisine.Location = new Point(1000, 100);
            LaveLinge.Location = new Point(1000, 450);
            LaveVaisselle.Location = new Point(1150, 450);
            Plongeur.Location = new Point(1150, 300);
            //Plongeur.Location = new Point(1229, 300);
            StockAliment.Location = new Point(1328, 10);
            StockAssiette.Location = new Point(1328, 300);
            StockLingeSale.Location = new Point(850, 450);
            StockAssietteSale.Location = new Point(1328, 450);
            
        }
}
