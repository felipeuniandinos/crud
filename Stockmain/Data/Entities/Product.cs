using Stockmain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stockmain.Data.Entities
{
    public class Product
    {
        public Product()
        {

        }
        [Key]
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string ESTADO { get; set; }


        public static Productostock EntitytoModel(Product entity)
        {
            var model = new Productostock { ID_PRODUCTO = entity.ID_PRODUCTO, NOMBRE_PRODUCTO = entity.NOMBRE_PRODUCTO, ESTADO = entity.ESTADO };
            return model;
        }

        public static Product ModeltoEntity(Productostock model)
        {
            var entity = new Product { ID_PRODUCTO = model.ID_PRODUCTO, NOMBRE_PRODUCTO = model.NOMBRE_PRODUCTO, ESTADO = model.ESTADO };
            return entity;
        }
        public static Product ModeltoEntityId(Productostock model)
        {
            var entity = new Product { ID_PRODUCTO=model.ID_PRODUCTO ,NOMBRE_PRODUCTO = model.NOMBRE_PRODUCTO, ESTADO = model.ESTADO };
            return entity;
        }
    }

    

}
