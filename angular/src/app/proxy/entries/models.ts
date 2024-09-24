import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateEntryDto {
  title: string;
  content: string;
  publicationDate: string;
  categoryId: string;
}

export interface EntryDto extends AuditedEntityDto<string> {
  title?: string;
  content?: string;
  publicationDate?: string;
  authorName?: string;
  authorId?: string;
  categoryName?: string;
  categoryId?: string;
}

export interface GetEntryListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
