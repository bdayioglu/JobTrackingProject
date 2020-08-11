using System;
using System.Collections.Generic;
using System.Text;
using DTO.DTOs.GorevDtos;

namespace DTO.DTOs.AppUserDtos
{
    public class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public GorevListDto Gorev { get; set; }
    }
}
