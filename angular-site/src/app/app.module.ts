import { BrowserModule, Title } from "@angular/platform-browser";
import { APP_INITIALIZER, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app.routing";

import { AppComponent } from "./app.component";
import { NavbarComponent } from "./shared/navbar/navbar.component";
import { FooterComponent } from "./shared/footer/footer.component";

import { HomeModule } from "./home/home.module";
import { ServiceProxyModule } from "@shared/service-proxies/service-proxy.module";
import {
  HttpClientJsonpModule,
  HttpClientModule,
  HTTP_INTERCEPTORS,
} from "@angular/common/http";
import { API_BASE_URL } from "@shared/service-proxies/service-proxies";
import { AppConsts } from "@shared/AppConsts";
import { AbpHttpInterceptor } from "abp-ng2-module";
import { AppInitializer } from "./app-initializer";
import { PageComponent } from "./page/page.component";

@NgModule({
  declarations: [AppComponent, NavbarComponent, FooterComponent, PageComponent],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    HttpClientJsonpModule,
    AppRoutingModule,
    HomeModule,
    ServiceProxyModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
    { provide: API_BASE_URL, useFactory: () => AppConsts.remoteServiceBaseUrl },
    {
      provide: APP_INITIALIZER,
      useFactory: (appInitializer: AppInitializer) => appInitializer.init(),
      deps: [AppInitializer],
      multi: true,
    },
    Title,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
