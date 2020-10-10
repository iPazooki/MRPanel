import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { AbpHttpInterceptor } from "abp-ng2-module";

import * as ApiServiceProxies from "./service-proxies";

@NgModule({
  providers: [
    ApiServiceProxies.SitePageServiceProxy,
    ApiServiceProxies.WebSiteSettingServiceProxy,
    { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
  ],
})
export class ServiceProxyModule {}
