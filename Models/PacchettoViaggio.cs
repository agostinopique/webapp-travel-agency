using Microsoft.Build.Framework;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public int Price { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public string Destination { get; set; }

        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        public PacchettoViaggio()
        {

        }

        public PacchettoViaggio(string name, int price, int days, string destination, string image)
        {
            int id = 0;
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Days = days;
            this.Destination = destination;
            this.Image = image;
            id++;
        }
    }
}
