import {Component, OnInit, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {ICategory} from "../shared/interface.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {BreakpointObserver} from "@angular/cdk/layout";
import {CategoryService} from "../shared/category.service";

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.scss']
})
export class CategoryPageComponent implements OnInit {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  categories: ICategory[] = [];

  public formCategory!: FormGroup;

  constructor(private observer: BreakpointObserver, private categoryService: CategoryService) {
    this.updateInfo();
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

  public ngOnInit(): void {
    this.formCategory = new FormGroup({
      id: new FormControl(null, [Validators.required]),
      title: new FormControl(null, [Validators.required])
    });
  }

  public deleteCategory(category: ICategory) {
    this.categoryService.delete(category.id).subscribe(() => this.updateInfo());
  }

  public updateInfo() {
    this.categoryService.getAll().subscribe((raw) => this.categories = raw);
  }

  public createCategory() {
    if (this.formCategory.invalid) {
      return;
    }
    this.categoryService.create({
      id: 0,
      title: this.titleCategoryControl.value
    }).subscribe(() => {
      this.updateInfo();
      this.idCategoryControl.setValue(null);
      this.titleCategoryControl.setValue(null);
      this.formCategory.markAsUntouched();
    });
  }

  public updateCategory() {
    if (this.formCategory.invalid) {
      return;
    }
    this.categoryService.update({
      id: this.idCategoryControl.value,
      title: this.titleCategoryControl.value
    }).subscribe(() => {
      this.updateInfo();
      this.idCategoryControl.setValue(null);
      this.titleCategoryControl.setValue(null);
      this.formCategory.markAsUntouched();
    });
  }

  get idCategoryControl(): AbstractControl {
    return this.formCategory.get('id')!;
  }

  get titleCategoryControl(): AbstractControl {
    return this.formCategory.get('title')!;
  }
}
