using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionsAPI.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public double Pocetna_cena { get; set; }

        public double Trenutna_cena { get; set; }

        public string Kategorija { get; set; }
        
        public string Picture { get; set; }

        
    }
}
