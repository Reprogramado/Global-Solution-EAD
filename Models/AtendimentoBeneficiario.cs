using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{
    
    public class AtendimentoBeneficiario
    {
        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public int BeneficiarioId { get; set; }
    }
}
