using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Response
{
    public class GameSubmitNewUser
    {
        public string Name { get; set; }

        public int SelectedBots { get; set; }
    }
}
