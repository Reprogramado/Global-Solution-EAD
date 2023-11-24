using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{
    
    public class Atendimento
    {
        
        public int AtendimentoId { get; set; }

        [Required, MaxLength(40), Display(Name = "Dor")]
        public string? Dor { get; set; }

        [MaxLength(100)]
        public string? LocalDor { get; set; }

        public CategoriaDor Categoria { get; set; }


        public string Fator { get; set; }

        
        public Medico Medico{ get; set; }
        public int MedicoId { get; set; }

       
        public IList<AtendimentoBeneficiario> AtendimentosBeneficiarios { get; set; }
    }

    public enum CategoriaDor
    {
        Física , Psicológica , Dentária
    }
}
