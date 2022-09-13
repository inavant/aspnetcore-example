using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;

namespace Empresa.Proyecto.Web.Pages.Catalogos
{
    public class SimpleEntityModel : BaseCatalogPageModel<SimpleEntity>
    {
        public SimpleEntityModel(ILogger<BaseCatalogPageModel<SimpleEntity>> logger, IAsyncRepository<SimpleEntity> repo) : base(logger, repo)
        {
        }

    }
}
