declare @logindatefinal date
declare @LastUpdatedBy_Associate nvarchar(100)
set @logindatefinal = '2023-10-06'
set @LastUpdatedBy_Associate = 'ChahbraAn'

select 
			ActivityNameID
			,TeamNameID
			,sum(DATEDIFF(MINUTE,LastUpdatedDateTime,LastUpdatedDateTime_Final)) as Minutes
			--,sum(DATEDIFF(HOUR,LastUpdatedDateTime,LastUpdatedDateTime_Final)) as Hours
			,sum(convert(decimal(18,2),DATEDIFF(MINUTE,LastUpdatedDateTime,LastUpdatedDateTime_Final))/60) as Hours
			from aom.vw_daily_dotnet
			where convert(date,LoginDate) = convert(date,@logindatefinal)
			and LastUpdatedBy_Associate = @LastUpdatedBy_Associate
			group by ActivityNameID,TeamNameID

;with cte2
			as
			(
			select 
			ActivityNameID
			,TeamNameID
			,sum(DATEDIFF(MINUTE,LastUpdatedDateTime,LastUpdatedDateTime_Final)) as Minutes
			--,sum(DATEDIFF(HOUR,LastUpdatedDateTime,LastUpdatedDateTime_Final)) as Hours
			,sum(convert(decimal(18,2),DATEDIFF(MINUTE,LastUpdatedDateTime,LastUpdatedDateTime_Final))/60) as Hours
			from aom.vw_daily_dotnet
			where convert(date,LoginDate) = convert(date,@logindatefinal)
			and LastUpdatedBy_Associate = @LastUpdatedBy_Associate
			group by ActivityNameID,TeamNameID
			)
			update a
			set a.TotalTime_Hours = convert(decimal(18,2),b.Hours)
			,a.TotalTime_Minutes = convert(decimal(18,2),b.Minutes)
			from aom.tbl_verification_volumes_dotnet a inner join cte2 b on a.ActivityNameID = b.ActivityNameID and a.TeamNameID = b.TeamNameID
			where 1=1
			and convert(date,a.AOM_Date) = convert(date,@logindatefinal)
			and a.AssociateName = @LastUpdatedBy_Associate