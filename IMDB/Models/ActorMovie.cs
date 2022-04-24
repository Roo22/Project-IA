using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class ActorMovie
    {
        [Key]
        [Column(Order = 0)]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}