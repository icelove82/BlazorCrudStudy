using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudStudy.Shared
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string HeroName { get; set; } = String.Empty;

        /* Relationship */
        public int ComicId { get; set; }
        public Comic? Comic { get; set; }
    }
}
