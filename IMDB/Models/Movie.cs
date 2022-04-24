using IMDB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        [Key]
        public int MovieId{ get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // relathionship betweem actor & movie
        public List<ActorMovie> ActorsMovies { get; set; }

        // relathionship betweem actor & author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        // relathionship betweem directory & movie
        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }

    }
}