import { Component, Injector, OnInit } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { finalize } from "rxjs/operators";
import {
  SiteSettingDto,
  SiteSettingServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-site-setting",
  templateUrl: "./site-setting.component.html",
  animations: [appModuleAnimation()],
})
export class SiteSettingComponent extends AppComponentBase implements OnInit {
  siteSetting: SiteSettingDto = new SiteSettingDto();
  saving: boolean = false;

  constructor(
    injector: Injector,
    public _siteSettingService: SiteSettingServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._siteSettingService.get().subscribe((result: SiteSettingDto) => {
      this.siteSetting = result;
    });
  }

  save(): void {
    this.saving = true;
    this._siteSettingService
      .save(this.siteSetting)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l("SavedSuccessfully"));
      });
  }
}
