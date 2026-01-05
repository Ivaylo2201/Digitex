import { unauthorized } from './constants';
import { httpClient } from './httpClient';

httpClient.interceptors.request.use((config) => {
  const token =
    localStorage.getItem('token') ?? sessionStorage.getItem('token');

  if (token) {
    config.headers['Authorization'] = `Bearer ${token}`;
  }

  return config;
});

httpClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (
      error.response &&
      error.response.status === unauthorized &&
      window.location.pathname !== '/auth/sign-in'
    ) {
      localStorage.removeItem('token');
      sessionStorage.removeItem('token');
      window.location.href = '/auth/sign-in';
    }

    return Promise.reject(error);
  }
);
