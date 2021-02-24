using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi.Models
{
    public class Category
    {
        //[key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name {get; set;}
    }
}