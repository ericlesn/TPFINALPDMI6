using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinal.XamarinSQLite;
using Xamarin.Forms;

namespace TpFinal
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();           
        }
        

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            
            var personList = await App.SQLiteDb.GetItemsAsync();
            if (personList != null)
            {
                lstPersons.ItemsSource = personList;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                Person person = new Person()
                {
                    NomeProduto = txtNomeProduto.Text,
                    Peso = txtPeso.Text,
                    NomeProdutor = txtNomeProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = txtNCM.Text
                };

              
                await App.SQLiteDb.SaveItemAsync(person);
                txtNomeProduto.Text = string.Empty;
                txtNomeProdutor.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPeso.Text = string.Empty;
                txtNCM.Text = string.Empty;

                await DisplayAlert("Successo", "Produto Cadastrado", "OK");
               
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Erro", "Insira os dados corretos", "OK");
            }
        }

        public async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtId.Text));
                if (person != null)
                {
                    
                    await DisplayAlert("Produto", "ID:"+ person.PersonID + " ,Nome Produto:" + person.NomeProduto + " ,Peso: " + person.Peso + " ,Nome Produtor: " + person.NomeProdutor + " ,Email: " + person.Email + " ,NCM: " + person.NCM, "OK");
                    
                }
            }
            else
            {
                await DisplayAlert("Erro", "ID invalido", "OK");
            }
        }

            private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Person person = new Person()
                {
                    PersonID = Convert.ToInt32(txtId.Text),
                    NomeProduto = txtNomeProduto.Text,
                    Peso = txtPeso.Text,
                    NomeProdutor = txtNomeProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = txtNCM.Text
                };

                
                await App.SQLiteDb.SaveItemAsync(person);

                txtId.Text = string.Empty;
                txtNomeProduto.Text = string.Empty;
                txtPeso.Text = string.Empty;
                txtNomeProdutor.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtNCM.Text = string.Empty;
                await DisplayAlert("Successo", "Produto Atualizado", "OK");
                
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }

            }
            else
            {
                await DisplayAlert("Erro", "ID invalido", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
               
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtId.Text));
                if (person != null)
                {
                   
                    await App.SQLiteDb.DeleteItemAsync(person);
                    txtId.Text = string.Empty;
                    await DisplayAlert("Successo", "Produto Deletado", "OK");

                  
                    var personList = await App.SQLiteDb.GetItemsAsync();
                    if (personList != null)
                    {
                        lstPersons.ItemsSource = personList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Erro", "ID invalido", "OK");
            }
        }
       
    }
}
