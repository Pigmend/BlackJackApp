using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerInfoRepository : IPlayerInfoRepository
    {
        private DatabaseContext db;

        public PlayerInfoRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(PlayerInfo playerInfo)
        {
            db.PlayerInfos.Add(playerInfo);
        }

        public PlayerInfo Get(int id)
        {
            return db.PlayerInfos.Find(id);
        }

        public void Update(PlayerInfo playerInfo)
        {
            db.Entry(playerInfo).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PlayerInfo playerInfo = db.PlayerInfos.Find(id);
            if (playerInfo != null)
            {
                db.PlayerInfos.Remove(playerInfo);
            }
        }

        public IEnumerable<PlayerInfo> GetAll()
        {
            return db.PlayerInfos;
        }

    }
}


