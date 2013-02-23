using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class HomeModel
    {
        public List<string> Names { get; set; }

        public HomeModel()
        {
            Names = new List<string> { 
                "Brian",
                "Ajay",
                "John",
                "Tim"
            };
        }
    }
}