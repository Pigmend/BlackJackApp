using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository: IRepository<Game>
    {
        IEnumerable<Game> SelectGamesByUserId(int userId);
    }
}
