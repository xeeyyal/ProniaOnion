﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Application.DTOs.Tokens
{
    public record TokenResponseDto(string Toeken,DateTime ExpireTime,string UserName);
}
