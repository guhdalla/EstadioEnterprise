using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    [Table("Tbl_Corrida")]
    public class Corrida
    {
        [Column("Id"), HiddenInput]
        public int CorridaId { get; set; }

        [Column("Dt_Corrida"), Display(Name = "Data Corrida")]
        public DateTime DataCorrida { get; set; }

        //Relacionamento muitos-para-um
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        //Relacionamento muitos-para-muitos
        public IList<Desconto> Descontos { get; set; }

        public decimal Valor { get; set; }
        
        public decimal? Desconto { get; set; }
        
        [Column("Forma_Pagamento"), Display(Name = "Forma de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
    }

    public enum FormaPagamento
    {
        Credito, Debito, Dinheiro, Boleto, Pix
    }
}
