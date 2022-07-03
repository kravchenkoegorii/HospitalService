﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase { }
}
