using System.IO;
using System.Text;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MűveltségiVerseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<verseny> feladatook = new List<verseny>();
        public MainWindow()
        {
            InitializeComponent();
            using StreamReader sr = new StreamReader(
                 path: @"..\..\..\src\feladatok.txt",
                 encoding: Encoding.UTF8
                 );
            while (!sr.EndOfStream)
            {
                feladatook.Add(new verseny(sr.ReadLine()));
            }
            sr.Close();

            //1. feladat
            for (int i = 0; i < feladatook.Count; i++)
            {
                lst2.Items.Add(feladatook[i].Kerdes);
            }


        }

        //2.feladat
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int szam = 0;
            for (int i = 0; i < feladatook.Count; i++)
            {
                if (feladatook[i].Kerdes.Contains("?"))
                {
                    szam++;
                    text.Text = $"A kérdőjeles feladatok száma: {szam}";
                }
            }


        }
        //3.feladat
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int szam = 0;
            for (int i = 0; i < feladatook.Count; i++)
            {
                if (feladatook[i].Terulet.Contains("kemia") && feladatook[i].Pontszam == 3)
                {
                    szam++;

                }
                txt2.Text = $"Az adatfájlban {szam}db 3 pontos kémia feladat van.";
            }
        }
        //4.feladat
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var min = feladatook.Min(x => x.Valasz);
            var max = feladatook.Max(x => x.Valasz);
            txt3.Text = $"A válaszok értéke {min} és {max} között terjed. ";
        }

        //5.feladat
        private void buttonotos_Click(object sender, RoutedEventArgs e)
        {
            List<string> abc = new List<string>();
            for (int i = 0; i < feladatook.Count; i++)
            {
                if (!abc.Contains(feladatook[i].Terulet))
                {
                    abc.Add(feladatook[i].Terulet);
                }
            }
            abc.Sort();

            foreach (var item in abc)
            {
                temakorbox.Items.Add(item);
            }
        }
        //6.feladat
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool yes = false;

            for (int i = 0; i < feladatook.Count; i++)
            {
                if (feladatook[i].Kerdes.Contains(aaaaaa.Text))
                {
                    kereseséistbox.Items.Add(feladatook[i].Kerdes);
                    yes = true;
                }

            }
            if (!yes)
            {
                MessageBox.Show("Nincs ilyen találat!");
            }
            Random rnd = new Random();
            if (kereseséistbox.Items.Count != 0)
            {
                int rndNext = rnd.Next(0, kereseséistbox.Items.Count);
                bbbbbb.Content = kereseséistbox.Items[rndNext];
            }

        }


        //7.feladat
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            List<string> list = new List<string>();
            Random rnd = new Random();
            int osszes = 0;
            int szam = 0;

            using (StreamWriter sw = new StreamWriter(path: @"..\..\..\src\15_feladat.txt"))
            {
                for (int i = 0; i < feladatook.Count; i++)
                {
                    szam = rnd.Next(0, feladatook.Count);
                    if (list.Count< 15 && !list.Contains(feladatook[szam].Kerdes)) 
                    {
                        
                        list.Add(feladatook[szam].Kerdes);
                        osszes += feladatook[szam].Pontszam;
                    }
                        
                 }
                sw.WriteLine($"Összes pontszám :{osszes}");
                foreach (var item in list)
                {
                    sw.Write($"{item} @ ");  
                }
            }
        }
    }
}