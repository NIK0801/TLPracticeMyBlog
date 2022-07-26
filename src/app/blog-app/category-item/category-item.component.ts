import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import { ICategory} from "../shared/interface.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-category-item',
  templateUrl: './category-item.component.html',
  styleUrls: ['./category-item.component.scss']
})
export class CategoryItemComponent {

  @Input() public category!: ICategory;
  @Output() public delete: EventEmitter<ICategory> = new EventEmitter<ICategory>();

  constructor() {
  }
  public deleteCategory() {
    this.delete.emit(this.category);
  }
}
