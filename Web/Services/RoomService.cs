﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class RoomService : IRoomService
    {
       

        public bool isUserAllowed(Room room)
        {
            return room.IsColerAllaved;
        }
    }
}
