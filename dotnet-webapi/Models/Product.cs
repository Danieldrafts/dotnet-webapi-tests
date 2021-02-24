using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi.Models
{
    public class Product
    {
        //[key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name {get; set;}

        [MaxLength(1024, ErrorMessage = "Este campo tem no maximo 1024 caracteres")]
        public string Description { get; set; }

        public int CategoryId { get; set;}
        public Category Category { get; set; }
    }
}