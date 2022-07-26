import {Component, EventEmitter, Input, Output} from '@angular/core';
import {IPost} from "../shared/interface.interface";

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.scss']
})
export class PostItemComponent {
  @Input() public post!: IPost;
  @Output() public delete: EventEmitter<IPost> = new EventEmitter<IPost>();

  constructor() {}

  public deletePost() {
    this.delete.emit(this.post);
  }
}
