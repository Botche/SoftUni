using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO
{
    class UsersDTO
    {
        public int UsersCount { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}
