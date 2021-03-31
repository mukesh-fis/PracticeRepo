REM                       ELECTRONIC PAYMENT SERVICES
REM       BATCH PROCESSING
REM
REM     LAST UPDATE:
REM       Rik Emerick         08/18/06             - original PRODUCTION VERSION
REM                       Chris Strowig      02/16/2007        - added FTP verification rewrite
REM      Chris Strowig   01/13/09               - Updated ftp command to use %FTPSERVER% as destination
REM      Rohit Karwal    03/17/2021           - Updated to download WACHOVIA Ret file from MoveIt server using SFTP
REM
REM      DESCRIPTION:
REM      Retrieves WACHOVIA return files from moveit server via SFTP connection
REM      and copies them to prod server for storage
REM
REM      Copy From:    <sftp server>/WACHOVIA/FromDMZ
REM      Copy To:    \\<data server>\d_drive\BPPS_DATA\mleftp\WachoviaReturn
REM      Move To:    \\<app server>\d_drive\BPPS_DATA\mlep\mlep_datain\input
REM      Log:        \\<data server>\d_drive\BPPS_LOGS\MLEFTPBATCH\import\%jobname%_%COMPUTERNAME%.log
REM
REM ***************************************************************************

d:
cd\mle\xfrsvc\bin

set JOBNAME=EBWVRTPUSH
set LOGPATH=D:\BPPS_LOGS\MLEFTPBATCH\import\%jobname%_%COMPUTERNAME%.log
set err_level=0
set RetFileName=EBSPAY-WACHOVIA-RETURN*
set LocalDir=D:\BPPS_DATA\MLEFTP\WachoviaReturn
set InputDir=D:\BPPS_DATA\MLEP\mlep_datain\input
set NumberOfFiles=2
set SftpDir=/WACHOVIA/FromDMZ

IF NOT EXIST %LOGPATH%     echo.                                                            >> %LOGPATH%

echo *****************************************                                              >> %LOGPATH%
now.exe                                                                                     >> %LOGPATH%

REM IF LocalDir does not exist, first create it
IF not exist %LocalDir%  ( mkdir %LocalDir% && echo %LocalDir% created >> %LOGPATH%)


:DOWNLOAD_RETURN_FILE
echo Downloading file via FileTransferUtil.exe                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    >> %LOGPATH%
D:\Mlep\mlep_exe\batch\FileTransfer\FileTransferUtil.exe -lp="%LocalDir%" -lf=*.* -rp=%SftpDir% -rf=%RetFileName% -tm=SFTP -td="download" -tc=Config_SFTP_01 -ds              >> %LOGPATH%
set err_level=%errorlevel%
if not "%err_level%"=="0" goto FILE_TRANSFER_ERR

:verifySFTP
dir /B %LocalDir%%RetFileName% > %LOGPATH%%JOBNAME%_files.txt
for /F "tokens=1-4 delims=          " %%k in ('grep -i -c %RetFileName% %LOGPATH%%JOBNAME%_files.txt') do set FILECOUNT=%%k
if %NumberOfFiles% NEQ %FILECOUNT% goto FILE_DOWNLOAD_ERROR

:process
now.exe                                                                                                                                                                                                                                                                                                                                                              >> %LOGPATH%
echo Move files to engine for processing                                                                                                                                                                                                               >> %LOGPATH%
Move %LocalDir%\*.* %InputDir%                                                                                                                                                                                                                                                           >> %LOGPATH%
if not "%errorlevel%"=="0" goto MOVE_FILE_ERROR

:SUCCESS
now.exe                                                                                                                                                        >> %LOGPATH%
echo Retrieval of wachovia Return files successful                                                                                                           >> %LOGPATH%
set err_level=0
goto FINISH

:FILE_TRANSFER_ERR
set err_level=1
echo Error occurred in File Transfer Utility. Please research.                                                                                                                         >> %LOGPATH%
goto FINISH

:MOVE_FILE_ERROR
echo Error occurred while moving file to Input folder. Please research.                                                                    >> %LOGPATH%
set err_level=2

:FILE_DOWNLOAD_ERROR
set err_level=3
echo Error occurred with downloading the files. Please research.                                                                                                               >> %LOGPATH%
goto FINISH


:FINISH
echo *****************************************                                                                                                               >> %LOGPATH%
echo.                                                                                                                                                              >> %LOGPATH%

c:\ctmag\util\_exit %err_level%

