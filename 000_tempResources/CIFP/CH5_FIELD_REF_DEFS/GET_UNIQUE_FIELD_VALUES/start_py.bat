@echo off
cd "C:\Users\ksand\Desktop\ProjFolder\FAA DATA HANDLER\CIFP CODING\CH 5 FIELD REFERENCE DEFINITIONS\GET UNIQUE FIELD VALUES"
:runbat
python get_unique_field_values.py
echo.
echo.
echo.
echo.
echo press any key to restart
pause>nul
cls
goto runbat