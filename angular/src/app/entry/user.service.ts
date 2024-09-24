import { CurrentUserDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private currentUser: CurrentUserDto) {}

  getCurrentUserId(): string | null {
    return this.currentUser.id;
  }
}
