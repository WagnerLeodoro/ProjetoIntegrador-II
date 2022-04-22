using System.Collections.Generic;

namespace PetVet.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public string TipoAnimal { get; set; }
        public string TipoServico { get; set; }
    }
}