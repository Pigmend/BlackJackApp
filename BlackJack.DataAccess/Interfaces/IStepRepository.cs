﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IStepRepository: IRepository<Step>
    {
        IEnumerable<Step> GetStepByGameID(long ID);
    }
}
