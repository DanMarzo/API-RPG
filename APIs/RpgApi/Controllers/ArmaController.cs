using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using RpgApi. Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{
    [ApiController]

    [Route("[Controller]")]
    public class ArmaController :  ControllerBase
    {
        private readonly DataContext _context;

        public ArmaController(DataContext context) //deixa o banco publico
        {
            _context = context;
        }

        []
    }

}