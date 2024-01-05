using SkiServiceApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.Json;
using System.Configuration; // Stellen Sie sicher, dass Sie diese Zeile hinzugefügt haben

namespace SkiServiceApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ServiceOrder> _serviceOrders;

        public ObservableCollection<ServiceOrder> ServiceOrders
        {
            get { return _serviceOrders; }
            set
            {
                _serviceOrders = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ServiceOrders = new ObservableCollection<ServiceOrder>();
            LoadOrdersFromBackend(); // Daten laden
        }

        private async Task LoadOrdersFromBackend()
        {
            var backendUrl = "https://localhost:7285/SkiService"; // Aktualisierte URL hier einfügen

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(backendUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var orders = JsonSerializer.Deserialize<List<ServiceOrder>>(jsonContent, options);

                        ServiceOrders.Clear();
                        foreach (var order in orders)
                        {
                            ServiceOrders.Add(order);
                        }
                    }
                    else
                    {
                        // Behandeln Sie den Fall, dass die Anforderung an Ihr Backend fehlgeschlagen ist
                    }
                }
                catch (Exception ex)
                {
                    // Behandeln Sie Ausnahmen, die während des HTTP-Aufrufs auftreten können
                }
            }
        }

        public void AddOrder(ServiceOrder order)
        {
            // Implementieren Sie die Logik zum Hinzufügen eines Auftrags
            ServiceOrders.Add(order);
        }

        // Ähnlich für UpdateOrder und DeleteOrder

        // Methoden zum Hinzufügen, Aktualisieren, Löschen von Aufträgen...

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
