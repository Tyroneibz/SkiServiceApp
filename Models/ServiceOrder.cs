using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServiceApp.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public string Kundenname { get; set; }
        public string Dienstleistung { get; set; }
        public string Priorität { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


        // Weitere Eigenschaften...
    }
}
