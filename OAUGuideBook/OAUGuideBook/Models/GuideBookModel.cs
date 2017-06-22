using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAUGuideBook.Models
{
    public class GuideBookModel
    {
       
            public int ContentId { get; set; }
            public string Title { get; set; }
            public string ContentDescription { get; set; }
            public string ContentPicture { get; set; }
            public string ContentVideo { get; set; }
            public bool ContentApproval { get; set; }
            public List<GuideBookModel> OAUGuideList { get; set; }

            [Display(Name = "Search")]
            public string Search { get; set; }
        
    }

    public class GuideBookListModel
    {
        public List<GuideBookModel> OAUGuideListCollction { get; set; }
        public GuideBookModel StudentListDetail { get; set; }
        [Display(Name = "Search")]
        public string Search { get; set; }


    }
}