echo off
set build_path="f:\Projects\SOD1\Backup\SSAR1\SSAR1\Assets\RawConfig\Tools\"
set config_path="f:\Projects\SOD1\Backup\SSAR1\SSAR1\Assets\Resources\Config\"
rem for %I in (2) do copy %I f:\Projects\SOD1\Backup\SSAR1\SSAR1\Assets\RawConfig\Tools\
copy /y %2 %build_path%
F:
cd %build_path%
java -jar configtool.jar
copy /y *.txt %config_path%
del /F *.xlsx *.txt
pause