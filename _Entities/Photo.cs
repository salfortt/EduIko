using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Entities
{
   public class Photo
    {
        public HttpPostedFileBase  PhotoFile { get; set; }
        public string ResimYerlesimYeri { get; set; }
        public string FileURL { get; set; }
        public string Description { get; set; }
       
      
    }
}
