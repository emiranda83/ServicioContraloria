using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contraloria.Clases.LogicaNegocio
{
    public class Estado
    {
        private int id;
        private string nombre;
        private int activo;

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

        public int Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }


        public Estado (int id, string nombre, int estado)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.activo = Activo;
        }


        public Estado(string nombre)
        {
            this.id = 0;
            this.nombre = Nombre;
            this.activo = 1;
        }

        public string ActivoMostrar
        {
            get
            {
                return activo == 1 ? "ACTIVO" : "INACTIVO";
            }

        }
    }

 }