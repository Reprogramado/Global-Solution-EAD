using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{
   
    public class Beneficiario
    {
        public int BeneficiarioId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public RedeAtendimento RedeAtendimento { get; set; }
        public bool UsoSubstancias { get; set; }

        
        public IList<AtendimentoBeneficiario> AtendimentosBeneficiarios { get; set; }
    }

    public enum RedeAtendimento
    {
        Saúde, Odontologia
    }
}
