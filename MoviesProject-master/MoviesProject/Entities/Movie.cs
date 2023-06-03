using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesProject.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publish_date { get; set; }
        public DateTime Created { get; set; }
        public int Director_Id { get; set; }
        public int Rating_Id { get; set; }
        public bool isDeleted { get; set; }
    }
}
