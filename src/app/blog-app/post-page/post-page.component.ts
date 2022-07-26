import {Component, OnInit, ViewChild} from '@angular/core';
import {IPost} from "../shared/interface.interface";
import {PostService} from "../shared/post.service";
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {BreakpointObserver} from "@angular/cdk/layout";
import {MatSidenav} from "@angular/material/sidenav";

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.scss'],
  providers: [
    PostService,
  ]
})
export class PostPageComponent implements OnInit {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  posts: IPost[] = [];
  public formPost!: FormGroup;

  constructor(private observer: BreakpointObserver, private postService: PostService) {
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
    this.formPost = new FormGroup({
      id: new FormControl(null, [Validators.required]),
      title: new FormControl(null, [Validators.required]),
      content: new FormControl(null, [Validators.required]),
      isPublished: new FormControl(null, [Validators.required]),
      categoryId: new FormControl(null, [Validators.required])
    });
  }

  public deletePost(post: IPost) {
    this.postService.delete(post.id).subscribe(() => this.updateInfo());
  }

  public updateInfo() {
    this.postService.getAll().subscribe((raw) => this.posts = raw);
  }

  public createPost() {
    if (this.formPost.invalid) {
      return;
    }
    this.postService.create({
      id: 0,
      title: this.titlePostControl.value,
      content: this.contentControl.value,
      isPublished: this.isPublishedControl.value,
      categoryId: this.categoryIdControl.value,
    }).subscribe(() => {
      this.updateInfo();
      this.idPostControl.setValue(null);
      this.titlePostControl.setValue(null);
      this.contentControl.setValue(null);
      this.isPublishedControl.setValue(1);
      this.categoryIdControl.setValue(null);
      this.formPost.markAsUntouched();
    });
  }

  public updatePost() {
    if (this.formPost.invalid) {
      return;
    }
    this.postService.update({
      id: this.idPostControl.value,
      title: this.titlePostControl.value,
      content: this.contentControl.value,
      isPublished: this.isPublishedControl.value,
      categoryId: this.categoryIdControl.value,
    }).subscribe(() => {
      this.updateInfo();
      this.idPostControl.setValue(null);
      this.titlePostControl.setValue(null);
      this.contentControl.setValue(null);
      this.isPublishedControl.setValue(1);
      this.categoryIdControl.setValue(1);
      this.formPost.markAsUntouched();
    });
  }

  get idPostControl(): AbstractControl {
    return this.formPost.get('id')!;
  }

  get titlePostControl(): AbstractControl {
    return this.formPost.get('title')!;
  }

  get contentControl(): AbstractControl {
    return this.formPost.get('content')!;
  }

  get isPublishedControl(): AbstractControl {
    return this.formPost.get('isPublished')!;
  }

  get categoryIdControl(): AbstractControl {
    return this.formPost.get('categoryId')!;
  }
}
