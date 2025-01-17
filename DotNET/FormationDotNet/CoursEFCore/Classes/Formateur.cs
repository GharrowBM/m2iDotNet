﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursEFCore.Classes
{
    public class Formateur
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public virtual List<Ecole> Ecoles { get; set; }

        public Formateur()
        {
            Ecoles = new List<Ecole>();
        }
    }
}
