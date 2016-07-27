USE ServiciosContraloria
GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Procedimiento para insertar Tramite. 
*****************************************************************************/

Create procedure SPR_Cat_Tramite_insertar
(
@vc_NombreTramite varchar(200)
)
as
begin tran


insert into Cat_Tramite(vc_NombreTramite, i_activoTramite)
values (@vc_NombreTramite, 1)



if @@error <>0
Begin
	rollback
	goto salir
End


Commit tran

Salir:


GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Procedimiento para modificar Tramite. 
*****************************************************************************/

Create procedure SPR_Cat_Tramite_modificar
(
@i_PK_idTramite int,
@vc_NombreTramite varchar(200),
@i_activoTramite int
)
as
begin tran


update Cat_Tramite set 

	vc_NombreTramite= @vc_NombreTramite,
	i_activoTramite= @i_activoTramite
where i_PK_idTramite= @i_PK_idTramite



if @@error <>0
Begin
	rollback
	goto salir
End


Commit tran

Salir:


GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Procedimiento para Consultar Tramite. 
*****************************************************************************/

Create procedure SPR_Cat_Tramite_Consultar
(
@i_PK_idTramite int
)
as
begin 

select
	i_PK_idTramite,
	vc_NombreTramite,
	i_activoTramite

from Cat_Tramite
where   i_PK_idTramite= @i_PK_idTramite



end


GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Procedimiento para Listar Tramite. 
*****************************************************************************/

Create procedure SPR_Cat_Tramite_Listar
(
@filtro varchar(100)
)
as
begin 

select
i_PK_idTramite as id,
vc_NombreTramite as Nombre,
case i_activoTramite when 1 then 'Activo' else 'Inactivo' end as Estado


from Cat_Tramite
where   vc_NombreTramite like '%'+@filtro+'%'



end

