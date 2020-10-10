import { Component, OnInit, Injector } from "@angular/core";
import {
  SitePageDto,
  SitePageServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { AppComponentBase } from "../shared/components/app-component-base";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent extends AppComponentBase implements OnInit {
  page: SitePageDto = new SitePageDto();

  constructor(injector: Injector, private _pageService: SitePageServiceProxy) {
    super(injector);
  }

  ngOnInit() {
    this._pageService.getHomePage().subscribe((result: SitePageDto) => {
      this.page = result;
    });

    this.titleService.setTitle(this.siteSetting.siteName);
  }
}
