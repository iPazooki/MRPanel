import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef } from "ngx-bootstrap/modal";
import * as _ from "lodash";
import { AppComponentBase } from "@shared/app-component-base";
import {
  PageDto,
  PageServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  templateUrl: "./create-page-dialog.component.html",
})
export class CreatePageDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  page = new PageDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _pageService: PageServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {}

  save(): void {
    this.saving = true;

    this._pageService
      .create(this.page)
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
