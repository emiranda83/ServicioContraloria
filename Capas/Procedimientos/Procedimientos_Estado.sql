
GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Procedimiento para insertar Estado. 
*****************************************************************************/

Create procedure SPR_Cat_Estado_insertar
(
@vc_nombreEstado varchar(200)
)
as
begin tran


insert into Cat_Estado(vc_nombreEstado)
values (@vc_nombreEstado)



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
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Procedimiento para modificar Estado. 
*****************************************************************************/

Create procedure SPR_Cat_Estado_modificar
(
@i_PK_idEstado int,
@vc_nombreEstado varchar(200),
@i_activoEstado int
)
as
begin tran


update Cat_Estado set 

	vc_nombreEstado= @vc_nombreEstado,
	i_activoEstado= @i_activoEstado
where i_PK_idEstado= @i_PK_idEstado



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
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Procedimiento para Consultar Estado. 
*****************************************************************************/

Create procedure SPR_Cat_Estado_Consultar
(
@i_PK_idEstado int
)
as
begin 

select
	i_PK_idEstado,
	vc_nombreEstado,
	i_activoEstado

from Cat_Estado
where   i_PK_idEstado= @i_PK_idEstado



end


GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Procedimiento para Listar Estado. 
*****************************************************************************/

Create procedure SPR_Cat_Estado_Listar
(
@filtro varchar(100)
)
as
begin 

select
i_PK_idEstado as PK,
vc_nombreEstado as nombreEstado,
i_activoEstado as activoEstado


from Cat_Estado
where   i_PK_idEstado + vc_nombreEstado like '%'+@filtro+'%'



end

