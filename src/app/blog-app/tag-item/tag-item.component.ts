import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ITag} from "../shared/interface.interface";

@Component({
  selector: 'app-tag-item',
  templateUrl: './tag-item.component.html',
  styleUrls: ['./tag-item.component.scss']
})
export class TagItemComponent {
  @Input() public tag!: ITag;
  @Output() public delete: EventEmitter<ITag> = new EventEmitter<ITag>();

  constructor() { }

  public deleteTag() {
    this.delete.emit(this.tag);
  }

}
