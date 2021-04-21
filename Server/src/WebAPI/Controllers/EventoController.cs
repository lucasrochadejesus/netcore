﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
             
        public EventoController()
        {
          
        }

        [HttpGet]
        public Evento Get()
        {
           return new Evento();
        }

        [HttpPost]
        public string Post()
        {
           return "value";
        }

        [HttpPut("{id}")]
        public string Put()
        {
           return "value";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           return "value";
        }
    }
}