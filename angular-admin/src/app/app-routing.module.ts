import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { AppRouteGuard } from "@shared/auth/auth-route-guard";
import { HomeComponent } from "app/home/home.component";
import { AboutComponent } from "app/about/about.component";
import { UsersComponent } from "app/users/users.component";
import { RolesComponent } from "app/roles/roles.component";
import { ChangePasswordComponent } from "./users/change-password/change-password.component";
import { PagesComponent } from "app/pages/pages.component";
import { SiteSettingComponent } from "app/site-setting/site-setting.component";
import { SiteMenuComponent } from "./site-menu/site-menu.component";

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: "",
        component: AppComponent,
        children: [
          {
            path: "home",
            component: HomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "pages",
            component: PagesComponent,
            data: { permission: "Pages.Pages" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "users",
            component: UsersComponent,
            data: { permission: "Pages.Users" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "roles",
            component: RolesComponent,
            data: { permission: "Pages.Roles" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "site-setting",
            component: SiteSettingComponent,
            data: { permission: "Pages.SiteSetting" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "site-menu",
            component: SiteMenuComponent,
            data: { permission: "Pages.Menus" },
            canActivate: [AppRouteGuard],
          },
          { path: "about", component: AboutComponent },
          { path: "update-password", component: ChangePasswordComponent },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
