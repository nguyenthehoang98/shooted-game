echo off
set build_path=%1
cd %build_path%
java -jar configtool.jar
pause