﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTest.Models
{
    [Table("T_USERS")]
    public class User
    {
        [Column("ID_USER")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        
        [Column("NM_NOME")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        
        [Column("NM_EMAIL")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Column("SEC_PASSWORD")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public User() { }

    }
}
