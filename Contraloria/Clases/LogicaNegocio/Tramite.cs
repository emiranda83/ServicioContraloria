using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contraloria.Clases.LogicaNegocio
{
    public class Tramite
    {
        private int id;
        private string nombre;
        private int estado;

        public Tramite()
        { }

        public  Tramite(int id, string nombre, int estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
        }


        public  Tramite(string nombre)
        {
            this.id = 0;
            this.nombre = nombre;
            this.estado = 1;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }


        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
        public string  EstadoMostrar
        {
            get
            {
                return estado == 1?"ACTIVO":"INACTIVO" ;
            }

           
        }


    }
}