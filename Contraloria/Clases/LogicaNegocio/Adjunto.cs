using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contraloria.Clases.LogicaNegocio
{
    public class Adjunto
    {
        int id;
        byte imagen;
        string descripcion;
        string tipo;

        public Adjunto() { }

        public Adjunto(int id, byte imagen, string descripcion, string tipo) {

            this.id = id;
            this.imagen = imagen;
            this.descripcion = descripcion;
            this.tipo = tipo;

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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public byte Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }
    }
}