import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/blog-app',
        name: '::Menu:BlogApp',
        iconClass: 'fas fa-blog',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/entries',
        name: '::Menu:Entries',
        parentName: '::Menu:BlogApp',
        layout: eLayoutType.application,
      },
      {
        path: '/my-entries',
        name: '::Menu:MyEntries',
        parentName: '::Menu:BlogApp',
        layout: eLayoutType.application,
      },
      {
        path: '/entries/categories',
        name: '::Menu:Categories',
        parentName: '::Menu:BlogApp',
        layout: eLayoutType.application,
      },
    ]);
  };
}
