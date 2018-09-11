using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BLL.Infrastructure;
using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.BLL.DTO;
using AutoMapper;

namespace BlackJack.BLL.Services
{
    public class UserService: IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void CreateUser(UserDTO user)
        {
            Database.Users.Create(new User() {Name = user.Name});
            Database.Save();
        }

        public UserDTO GetUser(int id)
        {
            User user = Database.Users.Get(id);

            return new UserDTO() { ID= user.ID, Name = user.Name};
        }

        public IEnumerable<UserDTO> GetUsers()
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void DeleteUser(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public UserDTO GetLastUser()
        {
            User lastUser = Database.Users.ReturnLastUser();

            return new UserDTO() { ID = lastUser.ID, Name = lastUser.Name };
        }


    }
}
