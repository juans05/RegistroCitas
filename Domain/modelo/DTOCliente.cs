using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.modelo
{
    public  class DTOCliente
    {
        public int idCliente { get; set; }
      
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Nombre debe tener como máximo 50 caracteres.")]
        public string nombreCompleto { get; set; }
        public int id_Tipodocumento { get; set; }
        [Required(ErrorMessage = "El campo IdEspecialidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor de IdEspecialidad debe ser mayor que 0.")]
        public int id_Especialidad { get; set; }


        public int existeUusario { get; set; }
    }
}
