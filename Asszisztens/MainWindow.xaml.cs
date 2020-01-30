using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using Asszisztens.Models;
using Asszisztens.Controllers;
namespace Asszisztens
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betegBtn_Click(object sender, RoutedEventArgs e)
        {
            if(InputCheck.NameCheck(this.lastName.Text)!="OK")
            {
                MessageBox.Show(InputCheck.NameCheck(this.lastName.Text), "Hiba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (InputCheck.NameCheck(this.firstName.Text) != "OK")
            {
                MessageBox.Show(InputCheck.NameCheck(this.firstName.Text), "Hiba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (InputCheck.TajCheck(this.taj.Text) != "OK")
            {
                MessageBox.Show(InputCheck.TajCheck(this.taj.Text), "Hiba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var Person = (Person)null;
            string newTaj = this.taj.Text.Trim();
            if (this.taj.Text.Length == 9)
            {
                newTaj = newTaj.Insert(3, "-");
                newTaj = newTaj.Insert(7, "-");

                Person = new Person
                {
                    Nev = this.lastName.Text.Trim() + " " + this.firstName.Text.Trim(),
                    Lakcim = this.address.Text,
                    Tajszam = newTaj,
                    Panasz = this.patientComplaints.Text,
                    Idopont = DateTime.Now
                };

            }
            else
            {
                Person = new Person
                {
                    Nev = this.lastName.Text.Trim() + " " + this.firstName.Text.Trim(),
                    Lakcim = this.address.Text,
                    Tajszam = newTaj,
                    Panasz = this.patientComplaints.Text,
                    Idopont = DateTime.Now
                };
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(Person);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = httpClient.PostAsync("http://localhost:80/person", stringContent);
                    if (result.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Beteg felvéve!", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        this.lastName.Clear();
                        this.firstName.Clear();
                        this.address.Clear();
                        this.taj.Clear();
                        this.patientComplaints.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hiba történt a betegfelvételkor!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                }
            }
            catch (System.AggregateException)
            {
                MessageBox.Show("Hálózati hiba!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

        }
    }
}
