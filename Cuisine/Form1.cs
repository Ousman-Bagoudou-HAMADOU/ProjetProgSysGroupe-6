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
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        int tmp = 0;
        int okc = 0;
        int tmpajt = 5;
        int np = 0;
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            //MessageBox.Show("vs avez " + e.MessageString);
            EventArgs fe = new EventArgs();
            object ty = new object();
            String tth = e.MessageString.Remove(5);
            if(tth == "temps")
            {
                int rrt = e.MessageString.Length;
                String ttht = e.MessageString.Remove(0, 5);
                int tte = ttht.Length;
                String yyt = ttht.Remove(tte - 1);
                //MessageBox.Show("contenu: " + yyt);
                int t = Convert.ToInt32(yyt);
                tmp = t;
                e.ReplyLine(string.Format(""));
            }
            else if (e.MessageString == "CommandeClient")
            {
                button1_Click(ty, fe);
                Thread cc = new Thread(() =>
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        while (System.Threading.Thread.CurrentThread.IsAlive)
                        {
                            if (okc == 1)
                            {
                                e.ReplyLine(string.Format("Cuisine!!"));
                                okc = 2;
                            }
                        }


                    });
                });
                cc.Start();
                if(okc == 2)
                {
                    cc.Abort();
                }
                //MessageBox.Show("Vous avez envoyé La  du client");
                //txtStatus.Text += e.MessageString;
               
                //e.ReplyLine(string.Format("Cuisine!!"));
                
                 
            }
            else if (e.MessageString == "Nappe")
            {
                button3_Click(ty, fe);
                Thread nnp = new Thread(() =>
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        while (System.Threading.Thread.CurrentThread.IsAlive)
                        {
                            if (np == 1)
                            {
                                e.ReplyLine(string.Format("NappeOK!!"));
                                np = 2;
                            }
                        }


                    });
                });
                nnp.Start();
                if (np == 2)
                {
                    nnp.Abort();
                }
                //MessageBox.Show("Vous avez envoyé La  du client");
                //txtStatus.Text += e.MessageString;

                //e.ReplyLine(string.Format("Cuisine!!"));


            }
            else
            {
                MessageBox.Show("Vous avez envoyé " + e.MessageString);
            }
        }
        
        
        
        private void Cuisine_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; //enter 
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
            String adip = "192.168.43.217";
            String adport = "8910";
            //txtStatus.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(adip);
            server.Start(ip, Convert.ToInt32(adport));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Thread tre = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate (){
                    for (int px = ChefCuisine.Location.X; px <= 500; px++)
                    {

                        ChefCuisine.Location = new Point(ChefCuisine.Location.X + 1, ChefCuisine.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    //Deplacement du chef de cuisine
                    Console.WriteLine("Le chef de cuisine reçoit la commande");
                    Console.WriteLine("Le chef de cuisine appele le chef de partie");
                    System.Threading.Thread.Sleep(tmp);


                    //Deplacement du chef de partie
                    Console.WriteLine("Le chef de partie rejoins le chef de cuisine");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    for (int py = ChefPartie.Location.Y; py >= 145; py--)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X, ChefPartie.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Deplacement du chef de partie vers le commis de cuisine
                    Console.WriteLine("Le chef de partie va rejoindre le commis de cuisine");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    for (int pp = 0; pp <= 200; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y);
                        //CommisCuisine.Location = new Point(CommisCuisine.Location.X, CommisCuisine.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 155; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y);
                        //CommisCuisine.Location = new Point(CommisCuisine.Location.X, CommisCuisine.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Deplacement du commis de cuisine vers le chef de partie + Rencontre
                    Console.WriteLine("Le commis de cuisine se déplace également pour rencontrer le chef de partie");                    
                    for (int pp = 0; pp <= 45; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y);
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X, CommisCuisine.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Deplacement du commis de cuisine vers le stock
                    //Deplacement du chef de rang vers le stock des assiettes propre
                    Console.WriteLine("Le commis et le chef fassent un point sur la commande du client ");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    Console.WriteLine("Le commis de cuisine va vers le stock des denrées pour prendre les nécessaires");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    for (int pp = 0; pp <= 135; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X + 1, CommisCuisine.Location.Y - 1);
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 95; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X + 1, CommisCuisine.Location.Y);
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Deplacement du plonguer pour céder le passage
                    Console.WriteLine("Le plonguer se déplace pour céder la place");
                    for (int pp = 0; pp <= 100; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y + 1);
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Le chef de partie rejoins le stock des assiettes
                    Console.WriteLine("Le plonguer se déplace pour céder la place");
                    for (int pp = 0; pp <= 50; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X, ChefPartie.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    Console.WriteLine("Le commis prend le necessaire pour la commande du client au stock");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    Console.WriteLine("Le chef de cuisine va vers le stock d'assiettes pour prendre le necessaire pour la commande du client");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    //Le chef de partie et le commis se retrouve à la cuisinière pour préparer le plat du client
                    Console.WriteLine("Le chef de partie rejoint le commis à la cuisinière pour la cuisson du plat");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    for (int pp = 0; pp <= 100; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X, CommisCuisine.Location.Y + 1);
                        ChefPartie.Location = new Point(ChefPartie.Location.X, ChefPartie.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //Déplacement du commis vers le chef de cuisine et le chef de partie vers le plonguer
                    Console.WriteLine("Le commis de cuisine va vers le chef de cuisine pour la validation du plat");
                    System.Threading.Thread.Sleep(tmp);
                    Console.WriteLine("Le chef de cuisine donne les assiettes sales aux plongeur");
                    System.Threading.Thread.Sleep(tmp + tmpajt);
                    
                    for (int pp = 0; pp <= 15; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y - 1);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y + 1);
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    for (int pp = 0; pp <= 40; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y - 1);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 35; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 9; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                     
                    for (int pp = 0; pp <= 50; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X, Plongeur.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 150; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        ChefPartie.Location = new Point(ChefPartie.Location.X - 1, ChefPartie.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    Console.WriteLine("Le commis continue toujours son chemin");
                    
                    for (int pp = 0; pp <= 330; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);

                        System.Threading.Thread.Sleep(tmp);
                    }
                    Console.WriteLine("Le chef de cuisine vérifie si le plat qu'à le commis en main est effectivement la commande du client");
                    System.Threading.Thread.Sleep(tmp + 5);
                    for (int pp = 0; pp <= 90; pp++)
                    {
                        ChefCuisine.Location = new Point(ChefCuisine.Location.X, ChefCuisine.Location.Y + 1);

                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 90; pp++)
                    {
                        ChefCuisine.Location = new Point(ChefCuisine.Location.X, ChefCuisine.Location.Y + 1);
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 80; pp++)
                    {

                        CommisCuisine.Location = new Point(CommisCuisine.Location.X - 1, CommisCuisine.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    okc = 1;
                    for (int pp = 0; pp <= 60; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 15; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }

                    //

                    /*for (int pp = 0; pp <= 20; pp++)
                    {
                        ChefCuisine.Location = new Point(ChefCuisine.Location.X, ChefCuisine.Location.Y + 1);
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y - 1);
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 80; pp++)
                    {
                        ChefPartie.Location = new Point(ChefPartie.Location.X + 1, ChefPartie.Location.Y - 1);
                        ChefCuisine.Location = new Point(ChefCuisine.Location.X, ChefCuisine.Location.Y + 1);
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X + 1, CommisCuisine.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 500; pp++)
                    {

                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 30; pp++)
                    {
                        CommisCuisine.Location = new Point(CommisCuisine.Location.X + 1, CommisCuisine.Location.Y);
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 170; pp++)
                    {

                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 100; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 185; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 440; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 60; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 15; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }*/

                    
                });
                

            });
            tre.Start();
            
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread cc = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    for (int pp = 0; pp <= 500; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 50; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        ChefCuisine.Location = new Point(ChefCuisine.Location.X, ChefCuisine.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 30; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 215; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 470; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 25; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 73; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X + 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    } 

                    for (int pp = 0; pp <= 25; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    for (int pp = 0; pp <= 550; pp++)
                    {
                        Plongeur.Location = new Point(Plongeur.Location.X - 1, Plongeur.Location.Y);
                        System.Threading.Thread.Sleep(tmp);
                    }
                    np = 1; 
                });
            });
            cc.Start();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}



}
