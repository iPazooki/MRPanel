import { Injectable } from "@angular/core";
import {
  SiteSettingDto,
  WebSiteSettingServiceProxy,
} from "../shared/service-proxies/service-proxies";

@Injectable({
  providedIn: "root",
})
export class AppInitializer {
  private _siteSetting: SiteSettingDto = new SiteSettingDto();

  constructor(private _webSiteSettingService: WebSiteSettingServiceProxy) {}

  get siteSetting(): SiteSettingDto {
    return this._siteSetting;
  }

  init(): () => Promise<boolean> {
    return () => {
      return new Promise<boolean>((resolve, reject) => {
        this._webSiteSettingService
          .get()
          .toPromise()
          .then(
            (result: SiteSettingDto) => {
              this._siteSetting = result;
              resolve(true);
            },
            (err) => {
              reject(err);
            }
          );
      });
    };
  }
}
