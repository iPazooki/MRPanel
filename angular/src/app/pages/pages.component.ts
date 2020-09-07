import { Component, Injector } from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "shared/paged-listing-component-base";
import {
  PageServiceProxy,
  PageDto,
  PageDtoPagedResultDto,
} from "@shared/service-proxies/service-proxies";
import { EditPageDialogComponent } from "./enter-page/enter-page-dialog.component";
import { AppPageType } from "@shared/AppEnums";

@Component({
  templateUrl: "./pages.component.html",
  animations: [appModuleAnimation()],
})
export class PagesComponent extends PagedListingComponentBase<PageDto> {
  pages: PageDto[] = [];
  keyword = "";
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _pageService: PageServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  CreateOrEditPage(page?: PageDto): void {
    if (page != undefined) {
      this.showCreateOrEditPageDialog(page.id);
    }
    else {
      this.showCreateOrEditPageDialog();
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
    this._pageService
      .getAll("", request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: PageDtoPagedResultDto) => {
        this.pages = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(page: PageDto): void {
    abp.message.confirm(
      this.l("AreYouSureWantToDelete", page.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._pageService.delete(page.id).subscribe(() => {
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditPageDialog(id?: string): void {
    let createOrEditPageDialog: BsModalRef;

    createOrEditPageDialog = this._modalService.show(
      EditPageDialogComponent,
      {
        class: "modal-lg",
        initialState: {
          id: id,
        },
      }
    );

    createOrEditPageDialog.content.onSave.subscribe(() => {
      this.refresh();
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
