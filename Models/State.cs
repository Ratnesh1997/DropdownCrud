using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudR.Models
{
    public class State
    {[Key]
        public int s_Id { get; set; }
        public string s_Name { get; set; }

        public Country country { get; set; }
    }
}
