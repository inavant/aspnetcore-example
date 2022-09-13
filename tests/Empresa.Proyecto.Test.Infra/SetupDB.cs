using System;
using Microsoft.EntityFrameworkCore;
using Empresa.Proyecto.Infra.Data;


namespace Empresa.Proyecto.Test.Infra
{
    public static class SetupDB
    {
        public static MyProjectContext GetDefaultContext(bool seed = true)
        {
            var options = new DbContextOptionsBuilder<MyProjectContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new MyProjectContext(options);

            if (seed)
            {
                //inicializar la BD

            }

            return dbContext;

        }
    }
}