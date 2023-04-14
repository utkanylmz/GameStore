using Core.Persistence.Paging;
using GameStore.Application.Features.Users.Dtos.GetListUser;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Models.UserListUser
{
    public class UserListModel:BasePageableModel
    {
        public IList<UserListDto> Items { get; set; }
    }
}
