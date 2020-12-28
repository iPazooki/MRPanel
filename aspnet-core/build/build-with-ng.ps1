# COMMON PATHS

$buildFolder = (Get-Item -Path "./" -Verbose).FullName
$slnFolder = Join-Path $buildFolder "../"
$outputFolder = Join-Path $buildFolder "outputs"
$webHostFolder = Join-Path $slnFolder "src/MRPanel.Web.Host"
$ngFolder = Join-Path $buildFolder "../../angular-admin"
$ngSiteFolder = Join-Path $buildFolder "../../angular-site"

## CLEAR ######################################################################

Remove-Item $outputFolder -Force -Recurse -ErrorAction Ignore
New-Item -Path $outputFolder -ItemType Directory

## RESTORE NUGET PACKAGES #####################################################

Set-Location $slnFolder
dotnet restore

## PUBLISH WEB HOST PROJECT ###################################################

Set-Location $webHostFolder
dotnet publish --output (Join-Path $outputFolder "host")

## PUBLISH ANGULAR UI PROJECT #################################################

Set-Location $ngFolder
& yarn
& ng build --prod
Copy-Item (Join-Path $ngFolder "dist") (Join-Path $outputFolder "ng-admin") -Recurse
Copy-Item (Join-Path $ngFolder "Dockerfile") (Join-Path $outputFolder "ng-admin")

# Change UI configuration
$ngConfigPath = Join-Path $outputFolder "ng-admin/assets/appconfig.json"
(Get-Content $ngConfigPath) -replace "21021", "9901" | Set-Content $ngConfigPath
(Get-Content $ngConfigPath) -replace "4200", "9902" | Set-Content $ngConfigPath

## PUBLISH ANGULAR SITE UI PROJECT #################################################

Set-Location $ngSiteFolder
Write-Output $ngSiteFolder

# Change Site UI configuration
$ngSiteConfigPath = Join-Path $ngSiteFolder "src/shared/appConsts.ts"
(Get-Content $ngSiteConfigPath) -replace "21021", "9901" | Set-Content $ngSiteConfigPath

& yarn
& ng build --prod
Copy-Item (Join-Path $ngSiteFolder "dist") (Join-Path $outputFolder "ng-site") -Recurse
Copy-Item (Join-Path $ngSiteFolder "Dockerfile") (Join-Path $outputFolder "ng-site")

$ngSiteConfigPath = Join-Path $ngSiteFolder "src/shared/appConsts.ts"
(Get-Content $ngSiteConfigPath) -replace "9901", "21021" | Set-Content $ngSiteConfigPath
## CREATE DOCKER IMAGES #######################################################

# Host
Set-Location (Join-Path $outputFolder "host")

docker rmi mrpanel_host -f
docker build -t mrpanel_host .

# Angular Admin UI
Set-Location (Join-Path $outputFolder "ng-admin")

docker rmi mrpanel_ng -f
docker build -t mrpanel_ng_admin .

# Angular Site UI
Set-Location (Join-Path $outputFolder "ng-site")

docker rmi mrpanel_ng_site -f
docker build -t mrpanel_ng_site .

## DOCKER COMPOSE FILES #######################################################

Copy-Item (Join-Path $slnFolder "docker/ng/*.*") $outputFolder

## FINALIZE ###################################################################

Set-Location $outputFolder
