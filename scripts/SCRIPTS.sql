-- 26/11/2019 - adicionado coluna
alter table Cartao add Arquivado int;
-- 26/11/2019 - adicionado coluna
alter table Cartao add Retrabalho int;
-- 02/12/2019 - adicionado coluna 
alter table Cartao add UltraCargo int;
-- 02/02/2020 - adicionado coluna 
alter table Acoes add ListaIdOld varchar(30);

-- Adicionado na view VW_Chamados a coluna adicionada
-- 26/11/2019 - Coluna Arquivado
-- 27/11/2019 - Adicionado formatação de data sem milisegundos
-- 28/11/2019 - Coluna Retrabalho
-- 02/12/2019 - Coluna UltraCargo
-- 09/12/2019 - adicionado fuso horário de 3h
-- 10/12/2019 - adicionado coluna ReabertoRetrabalho, DataUatHML e DataReadyForPRD
-- 30/12/2019 - modificado busca de abertura de retrabalho	
SELECT            
        C.CartaoId, 		
		SUBSTRING(C.Texto, 0, 11) AS CHAMADO, 
		C.Texto, 
		ISNULL(format(DateAdd(hh,-3,C.DataPrometida), 'yyyy-MM-dd HH:mm:ss'),'') as DataPrometida, 
		ISNULL(C.Tipo,'') AS Tipo, 
		ISNULL(u.Nome,'') AS usuario,
        ISNULL((SELECT format(MIN(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d6d25bf6330e8379d698585')),'') AS DataDirecionado,
        ISNULL((SELECT format(MIN(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d6d262916bfba7c3a83a2f1')),'') AS DataIniDes,
        ISNULL((SELECT format(MAX(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d6d264cf742f075ef752c62')),'') AS DataFimDes,		  		
		ISNULL((SELECT format(MIN(DateAdd(hh,-3, dev.DataAcao)),'yyyy-MM-dd HH:mm:ss')         		                    	
			    FROM dbo.Acoes AS dev 				  
				 WHERE dev.ListaId = '5d6d262916bfba7c3a83a2f1' 
				    AND dev.ListaIdOld IN('5d6d264cf742f075ef752c62','5d6d2668d7f14a847de51634','5d6d266e8575e71d8e5b95d3')					                    
				    AND dev.CartaoId = c.CartaoId),'') AS ReabertoRetrabalho, 		
		ISNULL((SELECT format(MAX(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d6d266e8575e71d8e5b95d3')),'') AS DataUatHML,
        ISNULL((SELECT format(MAX(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d836c1ef3f67c32a79de120')),'') AS DataReadyForPRD,			
        ISNULL((SELECT format(MAX(DateAdd(hh,-3,DataAcao)), 'yyyy-MM-dd HH:mm:ss') AS Expr1
                FROM dbo.Acoes AS A
                WHERE (CartaoId = C.CartaoId) AND (ListaId = '5d6d26b47dd6de7db7572373')),'') AS DataPRD,		       		  
        ISNULL((SELECT TOP (1) L.Lista
                FROM dbo.Acoes AS A 
		        INNER JOIN dbo.Listas AS L ON A.ListaId = L.IdLista
                WHERE (A.CartaoId = C.CartaoId)
                ORDER BY A.DataAcao DESC),'') AS Quadro,
		CASE C.Arquivado WHEN 1 THEN 'sim'  ELSE 'não' END AS Arquivado, 
		CASE C.Retrabalho WHEN 1 THEN 'sim' ELSE 'não' END AS Retrabalho, 
		CASE C.UltraCargo WHEN 1 THEN 'sim' ELSE 'não' END AS UltraCargo
FROM            
    dbo.Cartao AS C 
	LEFT OUTER JOIN dbo.Usuarios AS u ON u.UsuarioId = C.UsuarioId	
		
--02/01/2020 - criação da procedure
--[CREATE] 
ALTER PROCEDURE SP_AtlzListaAnterior 
AS BEGIN
  DECLARE
   @ListaId varchar(30), 
   @ListaIdOld varchar(30),
   @AcaoId varchar(30),
   @CartaoId varchar(30),
   @CartaoIdOld varchar(30)      
   
   SET @ListaIdOld = ''
   SET @CartaoIdOld = ''      
   
   DECLARE
     acoes_cursor CURSOR 
	 FOR SELECT ListaId, AcaoId, CartaoId FROM Acoes ORDER BY CartaoId,DataAcao ASC

   OPEN acoes_cursor     
   FETCH NEXT FROM acoes_cursor into @ListaId, @AcaoId, @CartaoId; 

   WHILE @@FETCH_STATUS = 0  
    BEGIN        
	  IF(@CartaoId <> @CartaoIdOld)
	   BEGIN	     
         SET @CartaoIdOld = ''
		 SET @ListaIdOld = ''
	   END  

      if (@ListaIdOld <> '')
	    UPDATE Acoes SET ListaIdOld = @ListaIdOld WHERE AcaoId = @AcaoId 
	  else
	    UPDATE Acoes SET ListaIdOld = @ListaId WHERE AcaoId = @AcaoId 	 	  	  

	  SET @ListaIdOld = @ListaId
	  SET @CartaoIdOld  = @CartaoId

	  FETCH NEXT FROM acoes_cursor into @ListaId, @AcaoId, @CartaoId
	END

   CLOSE acoes_cursor
   DEALLOCATE acoes_cursor   
END   	