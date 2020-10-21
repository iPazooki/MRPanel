import { Component, Injector, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { SitePageServiceProxy } from "@shared/service-proxies/service-proxies";
import { AppComponentBase } from "../components/app-component-base";

@Component({
  selector: "app-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"],
})
export class FooterComponent extends AppComponentBase implements OnInit {
  test: Date = new Date();

  constructor(
    injector: Injector,
    private route: ActivatedRoute,
    private sitePageSerivce: SitePageServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {}
}
