﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        bool IsExists(User user);
        bool IsExists(int id);
        User ReturnLastUser();
    }
}
