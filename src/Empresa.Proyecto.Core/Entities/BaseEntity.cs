using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Proyecto.Core.Entities
{
    /// <summary>
    /// Clase base para entidades de EF
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id de la entidad, PK
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Fecha creacion de la entidad
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Ultima modificacion de la entidad
        /// </summary>
        public DateTime Modified { get; set; }
    }

}
