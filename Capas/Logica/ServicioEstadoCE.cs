
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       27/07/2016
** Componente:  
** Descripcion: ServicioCE de Estado. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using Componentes_MOBILE.Clases;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo
{
    public class ServicioEstadoCE:AccesoBDCE
    {
        
        public ServicioEstadoCE()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Estado
        public String InsertarEstado(string vc_nombreEstado)
        {
            consulta = @"insert into Cat_Estado(vc_nombreEstado)
            values ('"+vc_nombreEstado+"')";

             return Procesamiento(consulta);
        }
		//Modificar  Estado
        public String ModificarEstado(int i_PK_idEstado,string vc_nombreEstado,int i_activoEstado)
        {
            consulta = @" update Cat_Estado set 
                        
						vc_nombreEstado= '"+vc_nombreEstado+@"',
						i_activoEstado= '"+i_activoEstado+@"'
                        where i_PK_idEstado= '"+i_PK_idEstado+"'";

            return Procesamiento(consulta);

        }
		//Consultar  Estado
        public DataRow ConsultarEstado(int i_PK_idEstado)
        {
            consulta = @"select
						i_PK_idEstado,
						vc_nombreEstado,
						i_activoEstado

                        from Cat_Estado
                        where   i_PK_idEstado= '"+i_PK_idEstado+"'";

            return Consultar(consulta);

        }
		//Listar  Estado
        public DataTable ListarEstado(string filtro)
        {
            consulta = @" select
                      i_PK_idEstado as PK,
								vc_nombreEstado as nombreEstado,
								i_activoEstado as activoEstado
								

                            from Cat_Estado
                            where   i_PK_idEstado + vc_nombreEstado like '%'+"+filtro+"+'%'";


            return Listar(consulta);
        }
    }
}
