using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudR.Models
{
    public class Country
    {
        [Key]
        public int c_Id { get; set; }
        public string c_Name { get; set; }
    }
}
