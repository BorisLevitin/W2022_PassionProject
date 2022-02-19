using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace W2022_PassionProject.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public string PetAge { get; set; }
        public string PetCharacter { get; set; }

        //weight is in kg
        public int PetWeight { get; set; }
        //A Pet can have one favorite park
        //A Park can have many pets
        [ForeignKey("Parks")]
        public int ParkID { get; set; }
        public virtual Park Parks { get; set; }

        /*
         Add: color,toys
         */
    }

    public class PetDto
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public string PetAge { get; set; }
        public string PetCharacter { get; set; }

        //weight is in kg
        public int PetWeight { get; set; }

        public string ParkName { get; set; }
    }
}