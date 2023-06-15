using System.ComponentModel.DataAnnotations;

namespace DemoAPI_Complete.DTO
{
    public class GameDTO
    {
        [Required]
        public string Titre { get; set; }
        [Range(0, 5, ErrorMessage = "Note doit être entre 0 et 5")]
        public int Note { get; set; }

        public string Genre { get; set; }
        public int DateDeSortie { get; set; }
    }
}
