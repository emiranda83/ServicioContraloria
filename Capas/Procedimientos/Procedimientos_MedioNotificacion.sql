USE ServiciosContraloria
GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Procedimiento para insertar MedioNotificacion. 
*****************************************************************************/

Create procedure SPR_Cat_MedioNotificacion_insertar
(
@vc_NombreMedio varchar(200)
)
as
begin tran


insert into Cat_MedioNotificacion(vc_NombreMedio,i_activoMedio)
values (@vc_NombreMedio ,1)



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
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Procedimiento para modificar MedioNotificacion. 
*****************************************************************************/

Create procedure SPR_Cat_MedioNotificacion_modificar
(
@i_PK_idMedio int,
@vc_NombreMedio varchar(200),
@i_activoMedio int
)
as
begin tran


update Cat_MedioNotificacion set 

	vc_NombreMedio= @vc_NombreMedio,
	i_activoMedio= @i_activoMedio
where i_PK_idMedio= @i_PK_idMedio



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
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Procedimiento para Consultar MedioNotificacion. 
*****************************************************************************/

Create procedure SPR_Cat_MedioNotificacion_Consultar
(
@i_PK_idMedio int
)
as
begin 

select
	i_PK_idMedio,
	vc_NombreMedio,
	i_activoMedio

from Cat_MedioNotificacion
where   i_PK_idMedio= @i_PK_idMedio



end


GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Procedimiento para Listar MedioNotificacion. 
*****************************************************************************/

Create procedure SPR_Cat_MedioNotificacion_Listar
(
@filtro varchar(100)
)
as
begin 

select
i_PK_idMedio as PK,
vc_NombreMedio as NombreMedio,
case i_activoMedio when 1 then 'Activo' else 'Inactivo' end as activoMedio,
i_activoMedio as activoMedio2


from Cat_MedioNotificacion
where   i_PK_idMedio + vc_NombreMedio like '%'+@filtro+'%'



end

