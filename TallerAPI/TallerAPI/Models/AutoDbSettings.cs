﻿namespace TallerAPI.Models
{
    public class AutoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }

    /* Parametros para crear DB
     * Nombre: taller
     * Colección: autos
     */
}
