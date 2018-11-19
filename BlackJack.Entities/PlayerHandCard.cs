using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerHandCard : BaseEntity
    {
        public long PlayerHandId { get; set; }
        public long CardId { get; set; }
    }
}
