using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccessLayer.EF;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private DatabaseContext db;

        private CardRepository cardRepository;
        private GameRepository gameRepository;
        private PlayerHandRepository playerHandRepository;
        private StepRepository stepRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new DatabaseContext(connectionString);
        }

        public ICardRepository Cards
        {
            get
            {
                if (cardRepository == null)
                {
                    cardRepository = new CardRepository(db);
                }
                return cardRepository;
            }
        }

        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new GameRepository(db);
                }
                return gameRepository;
            }
        }

        public IPlayerHandRepository PlayerHands
        {
            get
            {
                if (playerHandRepository == null)
                {
                    playerHandRepository = new PlayerHandRepository(db);
                }
                return playerHandRepository;
            }
        }

        public IStepRepository Steps
        {
            get
            {
                if (stepRepository == null)
                {
                    stepRepository = new StepRepository(db);
                }
                return stepRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
