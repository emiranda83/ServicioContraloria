USE ServiciosContraloria
GO
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       07/09/2016
** Componente:  
** Descripcion: Procedimiento para insertar Adjunto. 
*****************************************************************************/

Create procedure SPR_Sol_Adjunto_insertar
(
@img_archivoAdjunto image,
@vc_descripcionAdjunto varchar(200),
@vc_tipoAdjunto varchar(200)
)
as
begin tran


insert into Sol_Adjunto(img_archivoAdjunto,vc_descripcionAdjunto,vc_tipoAdjunto)
values (@img_archivoAdjunto ,@vc_descripcionAdjunto ,@vc_tipoAdjunto)



if @@error <>0
Begin
	rollback
	goto salir
End


Commit tran

Salir:

