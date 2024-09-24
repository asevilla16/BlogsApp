import { ListService, PagedResultDto, ConfigStateService } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoryDto, CategoryService } from '@proxy/categories';
import { EntryDto, EntryService } from '@proxy/entries';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from './user.service';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrl: './entry.component.scss',
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class EntryComponent {
  entries = { items: [], totalCount: 0 } as PagedResultDto<EntryDto>;
  categories = { items: [], totalCount: 0 } as PagedResultDto<CategoryDto>;
  selectedEntry = {} as EntryDto;

  currentUser = this.config.getOne('currentUser');

  form: FormGroup;

  searchQuery = '';

  isModalOpen: boolean = false;

  constructor(
    public readonly list: ListService,
    private entryService: EntryService,
    private categoryService: CategoryService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private config: ConfigStateService
  ) {}

  ngOnInit() {
    this.getEntries();
  }

  getEntries() {
    const entriesStreamCreator = query => {
      if (this.searchQuery != '') {
        query.filter = this.searchQuery;
      }
      return this.entryService.getList(query);
    };

    this.list.hookToQuery(entriesStreamCreator).subscribe(response => {
      this.entries = response;
    });
  }

  getCategories() {
    const categoryStreamCreator = query => this.categoryService.getList(query);

    this.list.hookToQuery(categoryStreamCreator).subscribe(response => {
      this.categories = response;
    });
  }

  searchBlogs() {
    this.getEntries();
  }

  createNewEntry() {
    this.selectedEntry = {} as EntryDto;
    this.buildForm();
    this.isModalOpen = true;
    this.getCategories();
  }

  editEntry(id: string) {
    this.entryService.get(id).subscribe(entry => {
      this.selectedEntry = entry;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      title: [this.selectedEntry.title || '', Validators.required],
      content: [this.selectedEntry.content || '', Validators.required],
      publicationDate: [this.selectedEntry.publicationDate || '', Validators.required],
      categoryId: [this.selectedEntry.categoryId || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedEntry.id
      ? this.entryService.update(this.selectedEntry.id, this.form.value)
      : this.entryService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
