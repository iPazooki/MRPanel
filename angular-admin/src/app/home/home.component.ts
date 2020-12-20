import {
  Component,
  Injector,
  ChangeDetectionStrategy,
  OnInit,
} from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PageServiceProxy,
  TopPageDto,
} from "@shared/service-proxies/service-proxies";
import { AppPageType } from "@shared/AppEnums";

@Component({
  templateUrl: "./home.component.html",
  animations: [appModuleAnimation()],
})
export class HomeComponent extends AppComponentBase implements OnInit {
  pages: TopPageDto[] = [];

  constructor(injector: Injector, private _pageService: PageServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this._pageService.getAllTopPages(10).subscribe((result: TopPageDto[]) => {
      this.pages = result;
    });
  }

  getPageTypeName(type: AppPageType): string {
    switch (type) {
      case AppPageType.Page:
        return "Page";
      case AppPageType.News:
        return "News";
      case AppPageType.Article:
        return "Article";

      default:
        break;
    }
  }
}
