import {Component, OnInit, ViewChild} from '@angular/core';
import {ITag} from "../shared/interface.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {TagService} from "../shared/tag.service";
import {BreakpointObserver} from "@angular/cdk/layout";
import {MatSidenav} from "@angular/material/sidenav";

@Component({
  selector: 'app-tag-page',
  templateUrl: './tag-page.component.html',
  styleUrls: ['./tag-page.component.scss'],
})
export class TagPageComponent implements OnInit {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  tags: ITag[] = [];

  public formTag!: FormGroup;

  constructor(private observer: BreakpointObserver, private tagService: TagService) {
  }

  ngOnInit(): void {
    this.formTag = new FormGroup({
      id: new FormControl(null, [Validators.required]),
      title: new FormControl(null, [Validators.required])
    });
  }

  ngAfterViewInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if (res.matches) {
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
    });
  }

  public deleteTag(tag: ITag) {
    this.tagService.delete(tag.id).subscribe(() => this.updateInfo());
  }

  public updateInfo() {
    this.tagService.getAll().subscribe((raw) => this.tags = raw);
  }

  public createTag() {
    if (this.formTag.invalid) {
      return;
    }
    this.tagService.create({
      id: 0,
      title: this.titleTagControl.value
    }).subscribe(() => {
      this.updateInfo();
      this.idTagControl.setValue(null);
      this.titleTagControl.setValue(null);
      this.formTag.markAsUntouched();
    });
  }

  public updateTag() {
    if (this.formTag.invalid) {
      return;
    }
    this.tagService.update({
      id: this.idTagControl.value,
      title: this.titleTagControl.value
    }).subscribe(() => {
      this.updateInfo();
      this.idTagControl.setValue(null);
      this.titleTagControl.setValue(null);
      this.formTag.markAsUntouched();
    });
  }

  get idTagControl(): AbstractControl {
    return this.formTag.get('id')!;
  }

  get titleTagControl(): AbstractControl {
    return this.formTag.get('title')!;
  }
}
