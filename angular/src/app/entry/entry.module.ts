import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EntryRoutingModule } from './entry-routing.module';
import { EntryComponent } from './entry.component';
import { SharedModule } from '../shared/shared.module';
import { CategoriesComponent } from './categories/categories.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { MyEntriesComponent } from './my-entries/my-entries.component';

@NgModule({
  declarations: [EntryComponent, MyEntriesComponent, CategoriesComponent],
  imports: [SharedModule, EntryRoutingModule, NgbDatepickerModule],
})
export class EntryModule {}
