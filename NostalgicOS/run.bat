@ECHO OFF

:choice
set /P c=Rebuild Project?[Y/N]?
if /I "%c%" EQU "Y" goto :rebuild
if /I "%c%" EQU "N" goto :somewhere_else
goto :choice


:rebuild
echo Starting Project Build....
devenv "C:\dev\NostalgicOS\NostalgicOS.sln" /rebuild Debug /project "NostalgicOS\NostalgicOS.csproj" /projectconfig Debug

:somewhere_else
echo Project Build Skipped

::qemu-system-x86_64 -boot d -cdrom bin/Debug/net6.0/NostalgicOS.iso -m 512
::vboxmanage startvm NostalgicOS
vmrun start "C:\Users\Retr0A\Documents\Virtual Machines\NostalgicOS\NostalgicOS.vmx"
