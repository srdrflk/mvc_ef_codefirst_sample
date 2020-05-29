using mvc_ef_codefirst_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_ef_codefirst_sample.ViewModels.Home
{
    public class IndexViewModels
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler> Adresler { get; set; }
    
    }
}