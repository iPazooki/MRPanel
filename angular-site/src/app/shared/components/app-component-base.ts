import { Injector } from "@angular/core";
import { Title } from "@angular/platform-browser";
import { SiteSettingDto } from "@shared/service-proxies/service-proxies";
import { AppInitializer } from "../../app-initializer";

export abstract class AppComponentBase {
  private appInitializer: AppInitializer;
  titleService: Title;

  constructor(injector: Injector) {
    this.appInitializer = injector.get(AppInitializer);
    this.titleService = injector.get(Title);
  }

  get siteSetting(): SiteSettingDto {
    return this.appInitializer.siteSetting;
  }

  getWidgetWidth(width: number) {
    switch (width) {
      case 0:
        return "col-3";
      case 1:
        return "col-4";
      case 2:
        return "col-6";
      case 3:
        return "col-8";
      case 4:
        return "col-9";
      default:
        return "col-12";
    }
  }
}
