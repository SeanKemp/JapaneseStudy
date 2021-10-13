using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapaneseStudy.Models
{
    public class Kanji
    {
        [Key]
        public int ID { get; set; }
        public string KanjiChar { get; set; }
        public string Meanings { get; set; }
        public string Story { get; set; }
        public string Primative { get; set; }
        public bool IsOnlyPrimative { get; set; }
    }
}
