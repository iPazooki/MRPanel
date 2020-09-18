import { Component, OnInit } from "@angular/core";
import { finalize } from "rxjs/operators";
import {
  SitePageDto,
  SitePageServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent implements OnInit {
  pages: SitePageDto[] = [];
  model = {
    left: true,
    middle: false,
    right: false,
  };

  focus;
  focus1;
  constructor(private _pageService: SitePageServiceProxy) {}

  ngOnInit() {
    this._pageService
      .getAll()
      .subscribe((result: SitePageDto[]) => {
        this.pages = result;
        console.log(this.pages);
      });
  }
  result1() {
    debugger;
    let t = this.pages;
  }
}
