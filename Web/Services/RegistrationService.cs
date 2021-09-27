using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRoomService roomService;

        public RegistrationService(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public bool ValidateUser(Room room ,User user)
        {
            var userAge = user.Age;
            var userGender = user.Gender;    

            if (userAge < 18 || userGender == Gender.Women )
                return false;

            return true;
        }
    }
}
