using JapaneseStudy.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapaneseStudy.Models
{
    public class KanjiReview
    {
        public int PersonID { get; set; }
        public int KanjiID { get; set; }
        public string ReviewType { get; set; }
        public int ReviewNo { get; set; }
        public bool IsLeech { get; set; }
    }
}
