setlocal

cd /d %~dp0

set TOOLS_PATH=.\tools\windows_x86
set OUT_PUT=.\Service

%TOOLS_PATH%\protoc.exe -I ./protos --csharp_out %OUT_PUT%  .\protos\sample.proto --grpc_out  %OUT_PUT%\ --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal
