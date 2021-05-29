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

## PUBLISH ANGULAR SITE UI PROJECT #################################################

Set-Location $ngSiteFolder
Write-Output $ngSiteFolder

# Change Site UI configuration
$ngSiteConfigPath = Join-Path $ngSiteFolder "src/shared/appConsts.ts"
(Get-Content $ngSiteConfigPath) -replace "http://localhost:21021", "http://mrpanel-lb-145608741.eu-west-2.elb.amazonaws.com:9901" | Set-Content $ngSiteConfigPath

& yarn
& ng build --prod
Copy-Item (Join-Path $ngSiteFolder "dist") (Join-Path $outputFolder "ng-site") -Recurse
Copy-Item (Join-Path $ngSiteFolder "Dockerfile") (Join-Path $outputFolder "ng-site")

$ngSiteConfigPath = Join-Path $ngSiteFolder "src/shared/appConsts.ts"
(Get-Content $ngSiteConfigPath) -replace "http://mrpanel-lb-145608741.eu-west-2.elb.amazonaws.com:9901", "http://localhost:21021" | Set-Content $ngSiteConfigPath
## CREATE DOCKER IMAGES #######################################################

# Host
Set-Location (Join-Path $outputFolder "host")

docker rmi pazooki/mrpanel_host -f
docker build -t pazooki/mrpanel_host:1.4 .

# Angular Admin UI
Set-Location (Join-Path $outputFolder "ng-admin")

docker rmi pazooki/mrpanel_ng_admin -f
docker build -t pazooki/mrpanel_ng_admin:1.4 .

# Angular Site UI
Set-Location (Join-Path $outputFolder "ng-site")

docker rmi pazooki/mrpanel_ng_site -f
docker build -t pazooki/mrpanel_ng_site:1.4 .

## DOCKER COMPOSE FILES #######################################################

Copy-Item (Join-Path $slnFolder "docker/ng/*.*") $outputFolder

## FINALIZE ###################################################################

Set-Location $outputFolder
