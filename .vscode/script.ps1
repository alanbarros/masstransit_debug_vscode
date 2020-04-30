[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12;
$ParentPath = (Get-Location).Path
$Request = Invoke-WebRequest -useb 'https://aka.ms/getvsdbgps1'
$ScriptBlock = [scriptblock]::Create(($Request))
.($ScriptBlock) -Version latest -RuntimeID linux-x64 -InstallPath "$ParentPath\vsdbg"