import axios from 'axios';

export const http = axios.create({
  baseURL: `${import.meta.env.VITE_API_URL}`
});

http.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token') ?? sessionStorage.getItem('token');

    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    
    return config;
  },
);

http.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      localStorage.removeItem('token');
      sessionStorage.removeItem('token');
      window.location.href = '/auth/sign-in';
    }

    return Promise.reject(error);
  }
);