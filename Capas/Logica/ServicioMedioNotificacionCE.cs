
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       11/08/2016
** Componente:  
** Descripcion: ServicioCE de MedioNotificacion. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using Componentes_MOBILE.Clases;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.
{
    public class ServicioMedioNotificacionCE:AccesoBDCE
    {
        
        public ServicioMedioNotificacionCE()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  MedioNotificacion
        public String InsertarMedioNotificacion(string vc_NombreMedio,int i_activoMedio)
        {
            consulta = @"insert into Cat_MedioNotificacion(vc_NombreMedio,i_activoMedio)
            values ('"+vc_NombreMedio+"','"+i_activoMedio+"')";

             return Procesamiento(consulta);
        }
		//Modificar  MedioNotificacion
        public String ModificarMedioNotificacion(int i_PK_idMedio,string vc_NombreMedio,int i_activoMedio)
        {
            consulta = @" update Cat_MedioNotificacion set 
                        
						vc_NombreMedio= '"+vc_NombreMedio+@"',
						i_activoMedio= '"+i_activoMedio+@"'
                        where i_PK_idMedio= '"+i_PK_idMedio+"'";

            return Procesamiento(consulta);

        }
		//Consultar  MedioNotificacion
        public DataRow ConsultarMedioNotificacion(int i_PK_idMedio)
        {
            consulta = @"select
						i_PK_idMedio,
						vc_NombreMedio,
						i_activoMedio

                        from Cat_MedioNotificacion
                        where   i_PK_idMedio= '"+i_PK_idMedio+"'";

            return Consultar(consulta);

        }
		//Listar  MedioNotificacion
        public DataTable ListarMedioNotificacion(string filtro)
        {
            consulta = @" select
                      i_PK_idMedio as PK,
								vc_NombreMedio as NombreMedio,
								i_activoMedio as activoMedio
								

                            from Cat_MedioNotificacion
                            where   i_PK_idMedio + vc_NombreMedio like '%'+"+filtro+"+'%'";


            return Listar(consulta);
        }
    }
}
