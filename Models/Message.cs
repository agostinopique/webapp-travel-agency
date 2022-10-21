using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        [EmailAddress(ErrorMessage= "Inserisci una mail valida!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        public string Content { get; set; }


        // Relazione con il pacchetto: un messaggio e' diretto ad un singolo pacchetto - un pacchetto puo' ricevere piu' messaggi
        public int? PacchettoViaggioId { get; set; }
        public PacchettoViaggio? PacchettoViaggio { get; set; }


        public Message()
        {

        }

        public Message(string email, string nameSurname, string content)
        {
            int id = 0;
            this.Id = id;
            this.Email = email;
            this.NameSurname = nameSurname;
            this.Content = content;
            id++;
        }
    }
}
