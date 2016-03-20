using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDoMercado.Models
{
    public class MercadoriaModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }
        public string TipoNegocio { get; set; }
    }

    public class MercadoriaModelDBContext : DbContext
    {
        public DbSet<MercadoriaModel> MercadoriaModels { get; set; }
    }
}
