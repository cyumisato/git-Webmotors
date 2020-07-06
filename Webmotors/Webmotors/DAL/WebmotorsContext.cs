using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webmotors.Models;

namespace Webmotors.DAL
{
    public class WebmotorsContext : DbContext
    {
        public WebmotorsContext() : base("WebmotorsContext")
        {

        }

        public DbSet<Anuncio> Anuncio { get; set; }
    }
}