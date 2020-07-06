using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webmotors.Models
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio
    {
        [Key, Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Marca"), Required, DataType(DataType.Text)]
        public string marca { get; set; }
        [Display(Name = "Modelo"), Required, DataType(DataType.Text)]
        public string modelo { get; set; }
        [Display(Name = "Versão"), Required, DataType(DataType.Text)]
        public string versao { get; set; }
        [Display(Name = "Ano"), Required]
        public int ano { get; set; }
        [Display(Name = "Quilometragem"), Required]
        public int quilometragem { get; set; }
        [Display(Name = "Observação"), Required, DataType(DataType.Text)]
        public string observacao { get; set; }
    }
}