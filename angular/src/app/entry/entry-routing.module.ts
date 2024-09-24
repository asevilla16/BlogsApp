import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EntryComponent } from './entry.component';
import { CategoriesComponent } from './categories/categories.component';
import { MyEntriesComponent } from './my-entries/my-entries.component';

const routes: Routes = [
  { path: '', component: EntryComponent },
  { path: 'my-entries', component: MyEntriesComponent },
  { path: 'categories', component: CategoriesComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EntryRoutingModule {}
