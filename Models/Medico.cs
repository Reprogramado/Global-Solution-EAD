using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{

    public class Medico
    {

        public int MedicoId { get; set; }
        [Required]
        public string? Nome { get; set; }
        public Especializacao Especial { get; set; }
        public bool Ativo { get; set; }


        //1:N
        public IList<Atendimento> Atendimentos { get; set; }

        public enum Especializacao
        {
            Física, Psicológica, Dentária
        }
    }
}
