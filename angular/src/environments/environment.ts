 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44380/',
  redirectUri: baseUrl,
  clientId: 'BlogsApp_App',
  responseType: 'code',
  scope: 'offline_access BlogsApp',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'BlogsApp',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44380',
      rootNamespace: 'BlogsApp',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
