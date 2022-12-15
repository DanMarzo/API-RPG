using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpgApi.Models;

namespace RpgApi.Models
{
    [Table("TB_Disputas")] //não esquecer de criar migrações
    public class Disputa
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Dt_Disputa")]
        public DateTime? DataDisputa { get; set; }

        [Column("AtacanteId")]
        public int AtacanteId { get; set; } 

        [Column("OponenteId")]
        public int OponenteId { get; set; }

        [Column("Tx_Narracao")]
        public string Narracao { get; set; }

        [NotMapped]
        public int HabilidadeId { get; set; }
        [NotMapped] //é ignorado e nao jogado no banco de dados
        public List<int> ListaIdPersonagens { get; set;}
        [NotMapped]
        public List<string> Resultados { get; set; }
        
    }
}