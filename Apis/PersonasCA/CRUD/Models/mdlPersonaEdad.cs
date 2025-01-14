using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class mdlPersonaEdad
    {
        private clsPersona persona;
        private int edad;

        public clsPersona Persona { get { return persona; } set { persona = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public mdlPersonaEdad(clsPersona p) 
        {
            persona = p;
            edad = DateTime.Now.Year - p.FechaNacimiento.Year;
        }
    }
}
