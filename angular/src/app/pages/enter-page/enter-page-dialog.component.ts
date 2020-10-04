import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";

import { finalize } from "rxjs/operators";
import { BsModalRef } from "ngx-bootstrap/modal";
import { filter as _filter } from "lodash-es";
import {
  PageServiceProxy,
  PageDto,
  WidgetServiceProxy,
  WidgetDto,
  WidgetType,
  Position,
  SizeType,
} from "@shared/service-proxies/service-proxies";

import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import {
  AppPageType,
  AppWidgetType,
  AppSizeType,
  AppPosition,
} from "@shared/AppEnums";

@Component({
  templateUrl: "./enter-page-dialog.component.html",
  styleUrls: ["../../pages/page-style.scss"],
})
export class EnterPageDialogComponent
  extends AppComponentBase
  implements OnInit {
  editor = ClassicEditor;
  widgetEditor = ClassicEditor;
  saving = false;
  page = new PageDto();
  widget = new WidgetDto();
  parentWidgets: WidgetDto[];
  childWidgets: WidgetDto[];
  widgets: WidgetDto[];
  allWidgets: WidgetDto[];
  isCollapsed = false;
  buttonName: any = "show";
  id: string;
  isFormVisible = false;

  // Drop-down labels
  pageTypeName: string;
  addWidgetLable: string;
  positionLable: string;
  size: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _pageService: PageServiceProxy,
    public _widgetService: WidgetServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  pageTypes: any = Object.keys(AppPageType).map((item, index) => {
    return { id: index, name: item };
  });

  widgetTypes: any = Object.keys(AppWidgetType).map((item, index) => {
    return { id: index, name: item };
  });

  positions: any = Object.keys(AppPosition).map((item, index) => {
    return { id: index, name: item };
  });

  sizeTypes: any = Object.keys(AppSizeType).map((item, index) => {
    return { id: index, name: item };
  });

  ngOnInit(): void {
    this.pageTypeName = "PleaseSelect";
    this.addWidgetLable = "PleaseSelect";
    this.positionLable = "PleaseSelect";

    if (this.id != undefined) {
      this._pageService.get(this.id).subscribe((result: PageDto) => {
        this.page = result;
        this.selectPageType(this.page.pageType);

        this._widgetService
          .getByPageId(this.id)
          .subscribe((widgetResult: WidgetDto[]) => {
            this.allWidgets = widgetResult;
            this.updateWidgets();
          });
      });
    }
  }

  private updateWidgets() {
    this.parentWidgets = _filter(this.allWidgets, (item) => {
      return item.parentId == null;
    });

    this.childWidgets = _filter(this.allWidgets, (item) => {
      return item.parentId != null;
    });
  }

  toggleIsFormVisible(i: number) {
    this.isFormVisible = !this.isFormVisible;
  }

  save(): void {
    this.saving = true;

    if (this.id != undefined) {
      this._pageService
        .update(this.page)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe(() => {
          this._widgetService
            .saveList(this.id, this.allWidgets)
            .subscribe(() => {
              this.notify.info(this.l("SavedSuccessfully"));
              this.bsModalRef.hide();
              this.onSave.emit();
            });
        });
    } else {
      this._pageService
        .create(this.page)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe((result: PageDto) => {
          if (this.allWidgets) {
            this._widgetService
              .saveList(result.id, this.allWidgets)
              .subscribe(() => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.bsModalRef.hide();
                this.onSave.emit();
              });
          } else {
            this.notify.info(this.l("SavedSuccessfully"));
            this.bsModalRef.hide();
            this.onSave.emit();
          }
        });
    }
  }

  selectPageType(type: AppPageType) {
    switch (type) {
      case AppPageType.Page: {
        this.page.pageType = AppPageType.Page;
        this.pageTypeName = "Page";
        break;
      }
      case AppPageType.News: {
        this.page.pageType = AppPageType.News;
        this.pageTypeName = "News";
        break;
      }
      case AppPageType.Article: {
        this.page.pageType = AppPageType.Article;
        this.pageTypeName = "Article";
        break;
      }

      default:
        break;
    }
  }

  addWidget(type: WidgetType, parentId: string = null) {
    let widget = new WidgetDto({
      widgetType: type,
      content: "",
      imageAddress: "",
      sizeType: SizeType._1,
      order: 1,
      position: Position._0,
      pageId: this.id,
      parentId: parentId,
      id: null,
    });

    this.allWidgets.push(widget);

    this.updateWidgets();
  }

  widgetName(widgetIndex: WidgetType) {
    return Object.keys(AppWidgetType).map((item, index) => {
      if (index === widgetIndex) return item;
    })[widgetIndex];
  }

  setPosition(position: AppPosition, widget: WidgetDto) {
    const index = this.allWidgets.findIndex((item: WidgetDto, i: number) => {
      return item.id === widget.id;
    });

    this.allWidgets[index].position = position["id"];
  }

  setSize(size: AppSizeType, widget: WidgetDto) {
    const index = this.allWidgets.findIndex((item: WidgetDto, i: number) => {
      return item.id === widget.id;
    });

    this.allWidgets[index].sizeType = size["id"];
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
