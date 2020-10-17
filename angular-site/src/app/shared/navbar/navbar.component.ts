import { Component, OnInit } from "@angular/core";
import { Router, NavigationEnd, NavigationStart } from "@angular/router";
import { Location, PopStateEvent } from "@angular/common";
import {
  SiteMenuDto,
  SiteMenuServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { filter as _filter } from "lodash-es";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styleUrls: ["./navbar.component.scss"],
})
export class NavbarComponent implements OnInit {
  public isCollapsed = true;
  private lastPoppedUrl: string;
  private yScrollStack: number[] = [];
  siteMenus: SiteMenuDto[];
  parentSiteMenus: SiteMenuDto[];
  childSiteMenus: SiteMenuDto[];

  constructor(
    public location: Location,
    private router: Router,
    private siteMenuService: SiteMenuServiceProxy
  ) {}

  ngOnInit() {
    this.siteMenuService.getAll().subscribe((result: SiteMenuDto[]) => {
      this.siteMenus = result;
      this.updateMenu();
    });

    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
      if (event instanceof NavigationStart) {
        if (event.url != this.lastPoppedUrl)
          this.yScrollStack.push(window.scrollY);
      } else if (event instanceof NavigationEnd) {
        if (event.url == this.lastPoppedUrl) {
          this.lastPoppedUrl = undefined;
          window.scrollTo(0, this.yScrollStack.pop());
        } else window.scrollTo(0, 0);
      }
    });
    this.location.subscribe((ev: PopStateEvent) => {
      this.lastPoppedUrl = ev.url;
    });
  }

  private updateMenu() {
    this.parentSiteMenus = _filter(this.siteMenus, (item: SiteMenuDto) => {
      return item.parentId == null;
    });

    this.childSiteMenus = _filter(this.siteMenus, (item: SiteMenuDto) => {
      return item.parentId != null;
    });
  }

  isHome() {
    var titlee = this.location.prepareExternalUrl(this.location.path());

    if (titlee === "#/home") {
      return true;
    } else {
      return false;
    }
  }

  isDocumentation() {
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if (titlee === "#/documentation") {
      return true;
    } else {
      return false;
    }
  }
}
