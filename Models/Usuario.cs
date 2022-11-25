using Microsoft.Win32;
using RpgApi.Controllers;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RpgApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Foto { get; set; }
        public double? Latitude { get; set; }// a '?' permite que o valor seja nulo
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; }

        [NotMapped]
        public string PasswordString { get; set; }
        
        public List<Personagem> Personagens { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
    }
}