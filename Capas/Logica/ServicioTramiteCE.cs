
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: ServicioCE de Tramite. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using Componentes_MOBILE.Clases;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo
{
    public class ServicioTramiteCE:AccesoBDCE
    {
        
        public ServicioTramiteCE()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Tramite
        public String InsertarTramite(string vc_NombreTramite)
        {
            consulta = @"insert into Cat_Tramite(vc_NombreTramite)
            values ('"+vc_NombreTramite+"')";

             return Procesamiento(consulta);
        }
		//Modificar  Tramite
        public String ModificarTramite(int i_PK_idTramite,string vc_NombreTramite,int i_activoTramite)
        {
            consulta = @" update Cat_Tramite set 
                        
						vc_NombreTramite= '"+vc_NombreTramite+@"',
						i_activoTramite= '"+i_activoTramite+@"'
                        where i_PK_idTramite= '"+i_PK_idTramite+"'";

            return Procesamiento(consulta);

        }
		//Consultar  Tramite
        public DataRow ConsultarTramite(int i_PK_idTramite)
        {
            consulta = @"select
						i_PK_idTramite,
						vc_NombreTramite,
						i_activoTramite

                        from Cat_Tramite
                        where   i_PK_idTramite= '"+i_PK_idTramite+"'";

            return Consultar(consulta);

        }
		//Listar  Tramite
        public DataTable ListarTramite(string filtro)
        {
            consulta = @" select
                      i_PK_idTramite as PK,
								vc_NombreTramite as NombreTramite,
								i_activoTramite as activoTramite
								

                            from Cat_Tramite
                            where   i_PK_idTramite + vc_NombreTramite like '%'+"+filtro+"+'%'";


            return Listar(consulta);
        }
    }
}
