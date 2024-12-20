import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'AbpApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44370/',
    redirectUri: baseUrl,
    clientId: 'AbpApp_App',
    responseType: 'code',
    scope: 'offline_access AbpApp',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44370',
      rootNamespace: 'Ord.AbpApp',
    },
  },
} as Environment;
