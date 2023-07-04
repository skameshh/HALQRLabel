



============================
Install the driver

============================
Sql
--============ JUNE 2022 ==================
SELECT REPLACE(LTRIM(REPLACE(A.[DLVRY_NBR],'0',' ')),' ','0') AS DLVRY_NBR
,REPLACE(LTRIM(REPLACE(A.[DLVRY_ITM],'0',' ')),' ','0') AS DLVRY_ITM
,REPLACE(LTRIM(REPLACE(B.Material_NOZERO,'0',' ')),' ','0') AS MATERIAL,B.RevLev
,REPLACE(LTRIM(REPLACE(A.BTCH_NBR,'0',' ')),' ','0') AS BATCH,[SHRT_TXT]
,[PLNT], b.Gross_Weight, b.Weight_UOM
FROM [DUN02_HESDATAMART01].[dbo].[DLVRY_ITM] A WITH(NOLOCK)
JOIN [CAR01_CPS_DATA].[dbo].[MATERIAL_MASTER_CPS_HEADER] B WITH(NOLOCK) ON B.Material = A.MTRL_NBR
where DLVRY_NBR like '%821623466' and DLVRY_ITM like '%10'

=========================