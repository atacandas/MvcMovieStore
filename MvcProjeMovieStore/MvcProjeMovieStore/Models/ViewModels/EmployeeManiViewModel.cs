using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeMovieStore.Models.ViewModels
{
    public class EmployeeManiViewModel
    {
        public Employee Employee { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
        public List<Title> Titles { get; set; }
    }
}