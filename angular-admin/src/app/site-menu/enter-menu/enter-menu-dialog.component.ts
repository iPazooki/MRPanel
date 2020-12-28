import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef } from "ngx-bootstrap/modal";
import {
  forEach as _forEach,
  includes as _includes,
  map as _map,
} from "lodash-es";
import { AppComponentBase } from "@shared/app-component-base";
import {
  MenuServiceProxy,
  MenuDto,
  PageDto,
  PageServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  templateUrl: "enter-menu-dialog.component.html",
})
export class EnterMenuDialogComponent
  extends AppComponentBase
  implements OnInit {
  saving = false;
  id: string;
  menu = new MenuDto();
  pages: PageDto[];
  menus: MenuDto[];

  // Drop-down labels
  pageName: string;
  parentName: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _menuService: MenuServiceProxy,
    private _pageService: PageServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.pageName = "PleaseSelect";
    this.parentName = "PleaseSelect";
    this._pageService.getAllPages().subscribe((result: PageDto[]) => {
      this.pages = result;
    });
    this._menuService.getAllMenus().subscribe((result: MenuDto[]) => {
      this.menus = result;
    });

    if (this.id != undefined) {
      this._menuService.get(this.id).subscribe((result: MenuDto) => {
        this.menu = result;
        if (this.menu.parentId) {
          this._menuService
            .get(this.menu.parentId)
            .subscribe((parentResult: MenuDto) => {
              this.parentName = parentResult.title;
            });
        }

        if (result.pageId) {
          this._pageService
            .get(result.pageId)
            .subscribe((pageResult: PageDto) => {
              this.pageName = pageResult.title;
            });
        }
      });
    }
  }

  save(): void {
    this.saving = true;

    if (this.menu.id) {
      this._menuService
        .update(this.menu)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe(() => {
          this.notify.info(this.l("SavedSuccessfully"));
          this.bsModalRef.hide();
          this.onSave.emit();
        });
    } else {
      this._menuService
        .create(this.menu)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe(() => {
          this.notify.info(this.l("SavedSuccessfully"));
          this.bsModalRef.hide();
          this.onSave.emit();
        });
    }
  }

  selectPage(page: PageDto) {
    this.pageName = page.title;
    this.menu.pageId = page.id;
  }

  selectMenu(menu: MenuDto) {
    this.parentName = menu.title;
    this.menu.parentId = menu.id;
  }
}
