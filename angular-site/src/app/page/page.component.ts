import { Component, Injector, OnInit } from "@angular/core";
import { AppComponentBase } from "@app/shared/components/app-component-base";
import { Router, ActivatedRoute, ParamMap, UrlSegment } from "@angular/router";
import {
  PageDto,
  SitePageDto,
  SitePageServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-page",
  templateUrl: "./page.component.html",
  styleUrls: ["./page.component.scss"],
})
export class PageComponent extends AppComponentBase implements OnInit {
  url: string;
  page: SitePageDto;

  constructor(
    injector: Injector,
    private route: ActivatedRoute,
    private sitePageSerivce: SitePageServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.route.url.subscribe((urls: UrlSegment[]) => {
      this.sitePageSerivce
        .getPageByUrl(urls[0].path)
        .subscribe((result: SitePageDto) => {
          this.page = result;
        });
    });
  }
}
