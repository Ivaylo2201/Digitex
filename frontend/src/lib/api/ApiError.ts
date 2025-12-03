import type { AxiosError } from 'axios';

type ErrorObject = {
  message: string;
  details?: object;
};

export type ApiError = AxiosError<ErrorObject>;
