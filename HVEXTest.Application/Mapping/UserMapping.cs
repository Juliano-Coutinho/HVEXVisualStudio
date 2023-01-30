using HVEXTest.Application.Models.User;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Mapping
{
    public static class UserMapping
    {
        public static User ToEntity(this UserDto userDto)
        {
            if (userDto.TransformersId is null) return new User {Id = userDto.Id, Name = userDto.Name, Email = userDto.Email, TransformersId = new List<string>() };

            else return new User {Id = userDto.Id, Name = userDto.Name, Email = userDto.Email, TransformersId = userDto.TransformersId };
        }

        public static UserDto ToDto(this User user)
        {
            if(user.TransformersId is null) return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, TransformersId = new List<string>() };

            else return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, TransformersId = user.TransformersId };
        }
    }
}
