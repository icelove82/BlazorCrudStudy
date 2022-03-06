using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudStudy.Shared
{
    internal class SuperHero
    {
        public int Id { get; set; }
        public string FirstName { get; set; }=String.Empty;
        public string LastName { get; set; }=String.Empty;
        public string HeroName { get; set; } = String.Empty;

        /* Relationship */
        public Comic? Comic { get; set; }
        public int ComicId { get; set; }
    }
}
