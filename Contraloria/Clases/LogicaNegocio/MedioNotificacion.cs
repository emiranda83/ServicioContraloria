using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contraloria.Clases.LogicaNegocio
{
    public class MedioNotificacion
    {
        private int id;
        private string nombre;
        private int estado;

        public MedioNotificacion()
        { }

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

        public MedioNotificacion(int id, string nombre, int estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
        }


        public MedioNotificacion(string nombre)
        {
            this.id = 0;
            this.nombre = Nombre;
            this.estado = 1;

        }

        public string EstadoMostrar
        {
            get
            {
                return estado == 1 ? "ACTIVO" : "INACTIVO";
            }
        }

    }
 }

