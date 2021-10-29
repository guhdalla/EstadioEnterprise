using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    //Classe que mapeia a tabela associativa
    [Table("Tbl_Desconto")]
    public class Desconto
    {
        public Drone Drone { get; set; }
        public int DroneId { get; set; }
        public Corrida Corrida { get; set; }
        public int CorridaId { get; set; }
    }
}
