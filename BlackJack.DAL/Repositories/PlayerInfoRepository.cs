using System;
using System.Collections.Generic;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
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
            db.playerInfos.Add(playerInfo);
        }

        public PlayerInfo Get(int id)
        {
            return db.playerInfos.Find(id);
        }

        public void Update(PlayerInfo playerInfo)
        {
            db.Entry(playerInfo).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PlayerInfo playerInfo = db.playerInfos.Find(id);
            if (playerInfo != null)
            {
                db.playerInfos.Remove(playerInfo);
            }
        }

        public IEnumerable<PlayerInfo> GetAll()
        {
            return db.playerInfos;
        }

    }
}


