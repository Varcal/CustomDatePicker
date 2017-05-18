using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatePickerSample.Models
{
    public partial class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
    }

    [MetadataType(typeof(Pessoa))]
    public partial class Pessoa
    {
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}