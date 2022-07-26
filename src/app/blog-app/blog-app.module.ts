import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatInputModule} from '@angular/material/input';
import {HttpClientModule} from "@angular/common/http";
import {MatExpansionModule} from '@angular/material/expansion';
import {ReactiveFormsModule} from "@angular/forms";
import {PostPageComponent} from "./post-page/post-page.component";
import {CategoryItemComponent} from "./category-item/category-item.component";
import {PostItemComponent} from "./post-item/post-item.component";
import {TagItemComponent} from "./tag-item/tag-item.component";
import {BlogAppRoutingModule} from "./blog-app-routing.module";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatIconModule} from "@angular/material/icon";
import {MatDividerModule} from "@angular/material/divider";
import { CategoryPageComponent } from './category-page/category-page.component';
import { TagPageComponent } from './tag-page/tag-page.component';

@NgModule({
  declarations: [
    PostPageComponent,
    CategoryItemComponent,
    PostItemComponent,
    TagItemComponent,
    CategoryPageComponent,
    TagPageComponent
  ],
  imports: [
    CommonModule,
    BlogAppRoutingModule,
    MatTabsModule,
    MatButtonModule,
    MatCardModule,
    HttpClientModule,
    MatInputModule,
    MatExpansionModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatDividerModule
  ]
})
export class BlogAppModule {
}
