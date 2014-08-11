C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /m:8 /p:Configuration=Release "Nancy.ViewEngines.Razor.HtmlHelpers.sln"
if %errorlevel% neq 0 exit /b %errorlevel%

.nuget\nuget pack "Nancy.ViewEngines.Razor.HtmlHelpers\Nancy.ViewEngines.Razor.HtmlHelpers.csproj" -Properties Configuration=Release
if %errorlevel% neq 0 exit /b %errorlevel%


mkdir NuGetPackage
copy *.nupkg NuGetPackage\*.nupkg
del *.nupkg