using DAL;
using ENT;

namespace CRUD.Models
{
    public class mdlPersonaEdad
    {
        private clsPersona persona;
        private int edad;
        private string departamento;

        public clsPersona Persona { get { return persona; } set { persona = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string Departamento { get { return departamento; } set { departamento = value; } }
        public mdlPersonaEdad(clsPersona p) 
        {
            persona = p;
            edad = DateTime.Now.Year - p.FechaNacimiento.Year;
            getNombreDept(p.IdDepartamento);
        }

        private async void getNombreDept(int id)
        {
            clsDepartamento dept;
            dept = await Services.getDepartamentoID(id);
            if (dept.Nombre != null) { departamento = dept.Nombre; }
                
        }
    }
}
