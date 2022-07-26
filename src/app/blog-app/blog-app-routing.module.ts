import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import {PostPageComponent} from "./post-page/post-page.component";
import {CategoryPageComponent} from "./category-page/category-page.component";

const routes: Routes = [
  {path: 'posts', component: PostPageComponent},
  {path: 'categories', component: CategoryPageComponent},
  {path: 'tags', component: PostPageComponent},
  {
    path: 'blog-app',
    component: PostPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class BlogAppRoutingModule { }
