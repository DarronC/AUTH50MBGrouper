Get-ChildItem -Path $PSScriptRoot -Directory -Name -Force | Tee-Object -Variable foldName | foreach-object{
$Archivename = Join-Path -path $PSScriptRoot -ChildPath " $($_).zip"
$foldname = Join-Path -Path $PSScriptRoot -ChildPath "$($_)\*"
Compress-Archive -Path $foldname  -DestinationPath $Archivename -CompressionLevel Fastest
}