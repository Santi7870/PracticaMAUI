using System;
using Microsoft.Maui.Controls;

namespace PracticaMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Evento cuando se selecciona un monto
        private void OnMontoSelected(object sender, EventArgs e)
        {
            if (MontoPicker.SelectedIndex != -1)
            {
                var monto = MontoPicker.SelectedItem.ToString();
                RecargaMessage.Text = $"Se ha seleccionado una recarga de {monto} dólares.";
            }
        }

        // Evento al presionar el botón de recarga
        private async void OnRecargaButtonClicked(object sender, EventArgs e)
        {
            // Validar que el número telefónico no esté vacío
            if (string.IsNullOrWhiteSpace(PhoneEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un número telefónico", "OK");
                return;
            }

            // Validar que se haya seleccionado un operador
            if (OperadorPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Debe seleccionar un operador", "OK");
                return;
            }

            // Validar que se haya seleccionado un monto
            if (MontoPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Debe seleccionar un monto", "OK");
                return;
            }

            // Confirmar recarga
            var confirm = await DisplayAlert(
                "Confirmación",
                $"¿Confirma realizar una recarga de {MontoPicker.SelectedItem} dólares a {PhoneEntry.Text} con el operador {OperadorPicker.SelectedItem}?",
                "Confirmar",
                "Cancelar");

            if (confirm)
            {
                await DisplayAlert("Éxito", "Recarga realizada con éxito", "OK");
            }
            else
            {
                await DisplayAlert("Cancelación", "La recarga ha sido cancelada.", "OK");
            }
        }
    }
}


