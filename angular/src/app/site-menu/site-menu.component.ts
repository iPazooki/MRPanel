import { Component, Injector } from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "shared/paged-listing-component-base";
import {
  MenuServiceProxy,
  MenuDto,
  MenuDtoPagedResultDto,
} from "@shared/service-proxies/service-proxies";
import { EnterMenuDialogComponent } from "./enter-menu/enter-menu-dialog.component";

@Component({
  templateUrl: "./site-menu.component.html",
  animations: [appModuleAnimation()],
})
export class SiteMenuComponent extends PagedListingComponentBase<MenuDto> {
  menus: MenuDto[] = [];
  keyword = "";

  constructor(
    injector: Injector,
    private _menuService: MenuServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  CreateOrEditMenu(menu?: MenuDto): void {
    if (menu != undefined) {
      this.showCreateOrEditMenuDialog(menu.id);
    } else {
      this.showCreateOrEditMenuDialog();
    }
  }

  clearFilters(): void {
    this.keyword = "";
    this.getDataPage(1);
  }

  protected list(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    this._menuService
      .getAll("", request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: MenuDtoPagedResultDto) => {
        this.menus = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(menu: MenuDto): void {
    abp.message.confirm(
      this.l("AreYouSureWantToDelete", menu.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuService.delete(menu.id).subscribe(() => {
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditMenuDialog(id?: string): void {
    let createOrEditMenuDialog: BsModalRef;

    createOrEditMenuDialog = this._modalService.show(EnterMenuDialogComponent, {
      class: "modal-lg",
      initialState: {
        id: id,
      },
    });

    createOrEditMenuDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
