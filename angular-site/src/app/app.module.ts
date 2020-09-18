import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app.routing";

import { AppComponent } from "./app.component";
import { SignupComponent } from "./signup/signup.component";
import { LandingComponent } from "./landing/landing.component";
import { ProfileComponent } from "./profile/profile.component";
import { NavbarComponent } from "./shared/navbar/navbar.component";
import { FooterComponent } from "./shared/footer/footer.component";

import { HomeModule } from "./home/home.module";
import { LoginComponent } from "./login/login.component";
import { ServiceProxyModule } from "@shared/service-proxies/service-proxy.module";
import { HttpClientJsonpModule, HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { API_BASE_URL } from "@shared/service-proxies/service-proxies";
import { AppConsts } from "@shared/AppConsts";
import { AbpHttpInterceptor } from "abp-ng2-module";

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LandingComponent,
    ProfileComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
  ],
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
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
