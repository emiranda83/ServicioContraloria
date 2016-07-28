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
        private int estado1;

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

        

        public Estado (int id, string nombre, int estado)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.estado1 = Estado1;
            
        }


        public Estado(string nombre)
        {
            this.id = 0;
            this.nombre = Nombre;
            this.estado1 = 1;
        }

        public string EstadoMostrar
        {
            get
            {
                return estado1 == 1 ? "ACTIVO" : "INACTIVO";
            }

        }

        public int Estado1
        {
            get
            {
                return estado1;
            }

            set
            {
                estado1 = value;
            }
        }

        public Estado()
        { }
    }

 }