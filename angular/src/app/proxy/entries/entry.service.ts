import type { CreateUpdateEntryDto, EntryDto, GetEntryListDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EntryService {
  apiName = 'Default';
  

  create = (entryDto: CreateUpdateEntryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EntryDto>({
      method: 'POST',
      url: '/api/app/entry',
      body: entryDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/entry/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EntryDto>({
      method: 'GET',
      url: `/api/app/entry/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetEntryListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EntryDto>>({
      method: 'GET',
      url: '/api/app/entry',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (guid: string, entryDto: CreateUpdateEntryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EntryDto>({
      method: 'PUT',
      url: '/api/app/entry',
      params: { guid },
      body: entryDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
