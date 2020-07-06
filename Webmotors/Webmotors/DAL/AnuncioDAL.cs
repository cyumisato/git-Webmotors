using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webmotors.Models;

namespace Webmotors.DAL
{
    public class AnuncioDAL
    {
        public AnuncioDAL()
        {

        }

        public List<Anuncio> List()
        {
            using (var db = new WebmotorsContext())
            {
                return db.Anuncio.ToList();
            }
        }

        public Anuncio Get(int? id)
        {
            using (var db = new WebmotorsContext())
            {
                return db.Anuncio.Find(id);
            }
        }

        public bool Add(Anuncio entity)
        {
            entity.marca = entity.marca.Length > 45 ? $"{entity.marca.Substring(0, 42)}..." : entity.marca;
            entity.modelo = entity.modelo.Length > 45 ? $"{entity.modelo.Substring(0, 42)}..." : entity.modelo;
            entity.versao = entity.versao.Length > 45 ? $"{entity.versao.Substring(0, 42)}..." : entity.versao;

            using (var db = new WebmotorsContext())
            {
                db.Anuncio.Add(entity);

                return db.SaveChanges() > 0;
            }
        }

        public bool Edit(Anuncio entity)
        {
            using (var db = new WebmotorsContext())
            {
                try
                {
                    db.Anuncio.Attach(entity);

                    db.Entry(entity).State = EntityState.Modified;

                    db.SaveChanges();

                    return true;

                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new WebmotorsContext())
            {
                var entity = db.Anuncio.Find(id);

                if (entity == null)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        db.Anuncio.Attach(entity);

                        db.Entry(entity).State = EntityState.Deleted;

                        db.SaveChanges();

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
        }
    }
}