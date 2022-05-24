using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_proekt.Models;

namespace MVC_proekt.ViewModels
{
    public class PredmetFilter
    {
        public IList<Subject> Subject { get; set; }
        public SelectList SemestarList { get; set; }
        public string SemestarString { get; set; }
        public SelectList ProgramaList { get; set; }
        public int ProgramaString { get; set; }
        public string SearchString { get; set; }

    }
}
