echo off
set build_path="d:\SmartGit\ssar1\SSAR1\Assets\RawConfig\Tools\"
set config_path="d:\SmartGit\ssar1\SSAR1\Assets\Resources\Config\"
rem for %I in (2) do copy %I d:\SmartGit\ssar1\SSAR1\Assets\RawConfig\Tools\
copy /y %2 %build_path%
D:
cd %build_path%
java -jar configtool.jar
copy /y *.txt %config_path%
del /F *.xlsx *.txt
pause