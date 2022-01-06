using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContract
{
    public class BookDto
    {
        public BookDto(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
