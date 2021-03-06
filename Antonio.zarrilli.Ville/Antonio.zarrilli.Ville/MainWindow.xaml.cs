﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Antonio.zarrilli.Ville
{
    public partial class MainWindow : Window
    {
        List<Alloggio> Alloggi = new List<Alloggio>();
        List<Villa> Ville = new List<Villa>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("ElencoAlloggi.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    bool errore = false;
                    foreach (var dato in dati)
                    {
                        if (string.IsNullOrEmpty(dato))
                        {
                            errore = true;
                        }
                    }
                    if (Convert.ToInt32(dati[4]) == 0)
                    {
                        if (errore == false)
                        {
                            Alloggio alloggi = new Alloggio(Convert.ToInt32(dati[0]), Convert.ToInt32(dati[1]), Convert.ToInt32(dati[2]), Convert.ToDouble(dati[3]));
                            Alloggi.Add(alloggi);
                        }
                    }
                    else
                    {
                        if (errore == false)
                        {
                            Villa villa = new Villa(Convert.ToInt32(dati[0]), Convert.ToInt32(dati[1]), Convert.ToInt32(dati[2]), Convert.ToDouble(dati[3]), Convert.ToInt32(dati[4]));
                            Ville.Add(villa);
                        }
                    }
                }
                grigliaVille.ItemsSource = Ville;
                grigliaAlloggi.ItemsSource = Alloggi;
            }
        }
    }
}
