using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWPF_Week6.Models
{
    public class ItemCatogory
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }



    }
}
