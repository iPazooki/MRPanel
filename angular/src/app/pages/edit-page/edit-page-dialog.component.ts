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
import * as _ from "lodash";
import {
  PageServiceProxy,
  PageDto,
  PageType,
} from "@shared/service-proxies/service-proxies";

import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { AppPageType } from "@shared/AppEnums";

@Component({
  templateUrl: "./edit-page-dialog.component.html",
  styleUrls: ["../../pages/page.css"],
})
export class EditPageDialogComponent
  extends AppComponentBase
  implements OnInit {
  public Editor = ClassicEditor;
  saving = false;
  page = new PageDto();
  id: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _pageService: PageServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  pageTypes: string[] = new EnumConvertor<AppPageType>(AppPageType).getValues();

  ngOnInit(): void {
    this._pageService.get(this.id).subscribe((result) => {
      this.page = result;
    });
  }

  save(): void {
    this.saving = true;

    this._pageService
      .update(this.page)
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

class EnumConvertor<T> {
  private readonly enumObj: T;
  constructor(enumObject: any) {
    this.enumObj = enumObject;
    return this;
  }
  getValue<U = any>(key: any): U {
    return this.enumObj[this.enumObj[key]];
  }
  getValues(): string[] {
    debugger;
    const keys = Object.keys(this.enumObj);
    return keys.slice(0, keys.length / 2);
  }
  getKeys(): string[] {
    const keys = Object.keys(this.enumObj);
    return keys.slice(keys.length / 2, keys.length);
  }
}
