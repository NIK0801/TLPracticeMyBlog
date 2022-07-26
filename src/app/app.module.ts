import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {BlogAppModule} from "./blog-app/blog-app.module";
import {PostService} from "./blog-app/shared/post.service";
import {CategoryService} from "./blog-app/shared/category.service";
import {TagService} from "./blog-app/shared/tag.service";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BlogAppModule,
    BrowserAnimationsModule
  ],
  providers: [PostService,CategoryService,TagService],
  bootstrap: [AppComponent]
})
export class AppModule { }
