import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PostPageComponent} from "./blog-app/post-page/post-page.component";
import {CategoryPageComponent} from "./blog-app/category-page/category-page.component";
import {TagPageComponent} from "./blog-app/tag-page/tag-page.component";

const routes: Routes = [
  {path: 'posts', component: PostPageComponent},
  {path: 'categories', component: CategoryPageComponent},
  {path: 'tags', component: TagPageComponent},
  {
    path: '**',
    component: PostPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
