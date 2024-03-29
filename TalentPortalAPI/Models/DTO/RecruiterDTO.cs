﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Models.DTO
{
    public class RecruiterDTO
    {
        public int RecruiterId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        //public int DeptId { get; set; }
        //public Dept Dept { get; set; }

        public int JobId { get; set; }
        public Job? Job { get; set; }
    }
}
