using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        categorieRepository catR = new categorieRepository();
        int tmps = 0;
        int tmpajt = 5;
        int depotnappe = 0;
        int departct = 0;
        int nappesalle = 0;
        int nappepropre = 0;
        int tmpct = 1000;
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Lancement de la salle de restauration");

            pic.Location = new Point(15, 15);
            //pic.Location = new Point(101, 101);
            picMH.Location = new Point(15, 160);
            picTB.Location = new Point(350, 200);
            picCR.Location = new Point(15, 330);
            //picCR.Location = new Point(19, 412);
            //picCR.Location = new Point(632, 403);
            picSR.Location = new Point(630, 110);
            picCS.Location = new Point(630, 330);
            tmps = 0;
        }
        SimpleTcpClient client2, client3;

        private void button4_Click(object sender, EventArgs e)
        {
            int ty = Convert.ToInt32(txtTmp.Text);
            //MessageBox.Show(""+ty);
            tmps = ty;
            String mm = "temps" + ty;
            client2.WriteLineAndGetReply(mm, TimeSpan.FromSeconds(3));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int datagrd = 0;
            Thread datagrid = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    dataGridView1.DataSource = catR.GetAll();
                    datagrd = 1;
                });
            });
            tmps = 10;
            Thread debut = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    // deplacement client
                    //Axe X

                    Console.WriteLine("Entré du client dans le restaurant");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    if (pic.Location.X < 35)
                    {
                        for (int px = pic.Location.X; px <= 100; px++)
                        {
                            pic.Location = new Point(pic.Location.X + 1, pic.Location.Y + 1);
                            System.Threading.Thread.Sleep(tmps);
                        }
                    }

                    //Axe Y
                    if (pic.Location.Y < 100)
                    {
                        for (int py = pic.Location.Y; py <= 35; py++)
                        {
                            pic.Location = new Point(pic.Location.X, pic.Location.Y + 1);
                            System.Threading.Thread.Sleep(tmps);
                        }

                    }


                    //depalcement maitre hotel
                    //Axe Y
                    Console.WriteLine("Accueil du client par le maitre d'hotel");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    //Axe X
                    for (int px = picMH.Location.X; px <= 40; px++)
                    {
                        picMH.Location = new Point(picMH.Location.X + 1, picMH.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int px = 0; px <= 60; px++)
                    {
                        picMH.Location = new Point(picMH.Location.X + 1, picMH.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Deplacement Chef Rang
                    //Axe X
                    Console.WriteLine("Le maître d'hôtel fait appel au chef de rang");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 135; px++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    //Axe Y
                    for (int py = 0; py <= 210; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Retour du maitre d'hotel
                    //Axe X
                    Console.WriteLine("Retour du maitre d'hotel à sa position");
                    System.Threading.Thread.Sleep(tmps + tmpajt);

                    for (int px = 0; px <= 80; px++)
                    {
                        picMH.Location = new Point(picMH.Location.X - 1, picMH.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Deplacement Chef de rang + client
                    //Axe X
                    Console.WriteLine("Le chef de rang demande au client de le suivre");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 245; px++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        pic.Location = new Point(pic.Location.X + 1, pic.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Axe Y
                    for (int py = 0; py <= 60; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y + 1);
                        pic.Location = new Point(pic.Location.X, pic.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    Console.WriteLine("Installation du client sur une table");
                    System.Threading.Thread.Sleep(tmps);
                    //Deplacement Chef de rang
                    //Axe X+
                    Console.WriteLine("Le chef de rang s'en va chercher le menu au comptoir");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 235; px++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Axe X-
                    Console.WriteLine("Le chef de rang prend le menu");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 235; px++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    datagrid.Start();
                    System.Threading.Thread.Sleep(10);
                    if (datagrd == 1)
                    {
                        datagrid.Abort();
                    }

                    //dataGridView1.DataSource = catR.GetAll();
                    //Axe X+
                    Console.WriteLine("Le chef de rang donne le menu au client");
                    System.Threading.Thread.Sleep(tmps);
                    Console.WriteLine("Le client regarde le menu");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    Console.WriteLine("Le client demande du Poulet");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 235; px++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    Console.WriteLine("Le chef de rang donne la commande à la cuisine");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    String mm = "CommandeClient";
                    client2.WriteLineAndGetReply(mm, TimeSpan.FromSeconds(3));

                    Console.WriteLine("Le chef de rang reprend sa position initiale");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    System.Threading.Thread.Sleep(1);
                    //Axe y
                    for (int py = 0; py <= 60; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y + 1);

                        System.Threading.Thread.Sleep(tmps);
                    }
                    Console.WriteLine("Le commis amène de l'eau et du pain à la table du client");
                    for (int py = 0; py <= 170; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y + 1);
                        picCS.Location = new Point(picCS.Location.X - 1, picCS.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int py = 0; py <= 150; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        picCS.Location = new Point(picCS.Location.X - 1, picCS.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int py = 0; py <= 145; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        picCS.Location = new Point(picCS.Location.X, picCS.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    Console.WriteLine("Le commis arrive à la table du client et depose l'eau et le pain");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int py = 0; py <= 150; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        picCS.Location = new Point(picCS.Location.X, picCS.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int py = 0; py <= 165; py++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        picCS.Location = new Point(picCS.Location.X + 1, picCS.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int py = 0; py <= 155; py++)
                    {
                        picCS.Location = new Point(picCS.Location.X + 1, picCS.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                });
            });

            debut.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client2 = new SimpleTcpClient();
            client2.StringEncoder = Encoding.UTF8;
            client2.DataReceived += Client_DataReceived;
            client3 = new SimpleTcpClient();
            client3.StringEncoder = Encoding.UTF8;
            client3.DataReceived += Client_DataReceived;
            //String adip = "192.168.43.15";
            String adip = "127.0.0.1";
            String adport = "8910";
            client2.Connect(adip, Convert.ToInt32(adport));
            client3.Connect(adip, Convert.ToInt32(adport));
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            object ob = new object();
            EventArgs ev = new EventArgs();
            if (e.MessageString == "Cuisine!!")
            {
                //MessageBox.Show("Vous avez envoyé Cuisine");
                button5_Click_1(ob, ev);
            }
            if (e.MessageString == "Nappe")
            {
                //MessageBox.Show("Vous avez envoyé Cuisine");
                button8_Click(ob, ev);
            }
            if (e.MessageString == "NappeOK!!")
            {
                //MessageBox.Show("Vous avez envoyé Cuisine");
                button8_Click(ob, ev);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread cc = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {

                    //Deplacement Serveur
                    //Axe X-
                    Console.WriteLine("Le serveur reçoit le plat de la commande du client");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    for (int px = 0; px <= 330; px++)
                    {
                        picSR.Location = new Point(picSR.Location.X - 1, picSR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Axe Y+
                    for (int py = 0; py <= 90; py++)
                    {
                        picSR.Location = new Point(picSR.Location.X, picSR.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    //Axe Y-
                    for (int py = 0; py <= 90; py++)
                    {
                        picSR.Location = new Point(picSR.Location.X, picSR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    //Axe X+
                    for (int px = 0; px <= 330; px++)
                    {
                        picSR.Location = new Point(picSR.Location.X + 1, picSR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    Console.WriteLine("Le serveur depose la commande");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    //Axe Y-
                    Console.WriteLine("Le serveur reprend sa position initiale");
                    departct = 1;
                    System.Threading.Thread.Sleep(tmps + 10);
                    button6_Click(sender, e);
                    
                });
            });
            cc.Start(); 

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread dpct = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {

                    Console.WriteLine("Départ du client");
                    System.Threading.Thread.Sleep(tmps + tmpajt);
                    //Axe Y-
                    for (int py = 0; py <= 60; py++)
                    {
                        pic.Location = new Point(pic.Location.X, pic.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }

                    //Axe X-
                    for (int px = 0; px <= 245; px++)
                    {
                        pic.Location = new Point(pic.Location.X - 1, pic.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int px = 0; px <= 80; px++)
                    {
                        picMH.Location = new Point(picMH.Location.X + 1, picMH.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int px = 0; px <= 80; px++)
                    {
                        picMH.Location = new Point(picMH.Location.X - 1, picMH.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    button10_Click(sender, e);
                });
            });
            dpct.Start(); 
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            Thread depotnap = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    for (int p = 0; p <= 150; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 170; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 35; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 160; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 133; p++)
                    {

                        picCR.Location = new Point(picCR.Location.X - 1, picCR.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                });
            });
            depotnap.Start();
            
        }

        

        private void button10_Click(object sender, EventArgs e)
        {
            Thread dpcr = new Thread(() =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    for (int p = 0; p <= 133; p++)
                    {
                        pic.Location = new Point(pic.Location.X - 1, pic.Location.Y - 1);
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 78; p++)
                    {

                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y - 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 75; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 35; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X, picCR.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 170; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y + 1);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    for (int p = 0; p <= 150; p++)
                    {
                        picCR.Location = new Point(picCR.Location.X + 1, picCR.Location.Y);
                        System.Threading.Thread.Sleep(tmps);
                    }
                    envoinapp();

                });
            });
            dpcr.Start();
        }

        public void envoinapp()
        {
            String dd = "Nappe";
            //client2.WriteLine(dd);
            client3.WriteLineAndGetReply(dd, TimeSpan.FromSeconds(1));
            //MessageBox.Show("msg envoyé");
        }

    }
}
