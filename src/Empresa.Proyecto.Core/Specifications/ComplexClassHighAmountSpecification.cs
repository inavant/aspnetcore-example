using Empresa.Proyecto.Core.Entities;

namespace Empresa.Proyecto.Core.Specifications
{
    /// <summary>
    /// Ejemplo clase de especificacion. Se crean las especificaciones necesarias para 
    /// las diferentes consultas necesarias
    /// </summary>
    public class ComplexEntityHighAmountSpecification : BaseSpecification<ComplexEntity>
    {
        /// <summary>
        /// Esta especificacion recibe un parametro y aplica un filtro. 
        /// Tambine se definen configuraciones auxiliares como Includes, orders y paginacion
        /// </summary>
        /// <param name="amount">Monto a filtrar, para ejemplo.</param>
        public ComplexEntityHighAmountSpecification(decimal amount) :
            base(c=> c.Amount >= amount)
        {
            ApplyOrderBy(c=> c.Amount);

            //Para incluir propiedades de navegacion auxiliar
            //AddInclude(c => c.Mercantile);
        }
    }


}
