using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class ProgramsModel
    {
        public virtual string obsprgCode { get; set; }
        public virtual string description { get; set; }
        public virtual string comments { get; set; }

        public ProgramsModel() { }

        public ProgramsModel( Programs  programs)
        {
            this. obsprgCode= programs. ObsprgCode;
            this.description = programs.Description;
            this.comments = programs.Comments;
        }
    }
}