using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    class Game
    {
        public int ID { get; set; }
        
        //Keys from Steps
        public ICollection<Step> steps { get; set; }
    }
}
