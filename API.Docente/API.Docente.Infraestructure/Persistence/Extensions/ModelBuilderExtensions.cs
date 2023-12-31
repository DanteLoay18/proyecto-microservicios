﻿using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Infraestructure.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterAllEntities(this ModelBuilder modelBuilder, IEnumerable<Type> types)
        {
            foreach (Type type in types) modelBuilder.Entity(type);
        }
    }
}
