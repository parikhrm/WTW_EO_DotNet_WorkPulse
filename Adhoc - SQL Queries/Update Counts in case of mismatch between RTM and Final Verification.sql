declare @logindatefinal date
declare @LastUpdatedBy_Associate nvarchar(100)
set @logindatefinal = '2023-09-29'
set @LastUpdatedBy_Associate = 'DeshmukhKa'
;with cte1
			as
			(
			select ActivityNameID,TeamNameID,sum(Volumes) as Volumes 
			from aom.vw_daily_dotnet
			where convert(date,LoginDate) = convert(date,@logindatefinal)
			and LastUpdatedBy_Associate = @LastUpdatedBy_Associate
			and ActivityNameID not in 
			(110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132)
			group by ActivityNameID,TeamNameID
			)
			update a
			set a.Volumes = b.Volumes
			from aom.tbl_verification_volumes_dotnet a inner join cte1 b on a.ActivityNameID = b.ActivityNameID and a.TeamNameID = b.TeamNameID
			where 1=1
			and convert(date,a.AOM_Date) = convert(date,@logindatefinal)
			and a.AssociateName = @LastUpdatedBy_Associate
