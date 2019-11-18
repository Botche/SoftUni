echo on

CALL DeleteScript.bat

for /f "tokens=3,2,4 delims=/- " %%x in ("%date%") do set d=%%y_%%x_%%z
set data=%d%

Echo zipping...

for /d %%X in (*) do "C:\Program Files\WinRAR\Rar.exe" a -zip "./Submit_%d%.zip" ".\%%X"

echo Done!