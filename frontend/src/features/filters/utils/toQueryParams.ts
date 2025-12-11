function buildQueryParameter(key: string, value: string) {
  return `${encodeURIComponent(key)}=${encodeURIComponent(value)}`
}

export function toQueryParams(obj: Record<string, any>): string {
  const params: string[] = [];

  for (const key in obj) {
    if (!obj.hasOwnProperty(key))
       continue;

    const value = obj[key];
    if (!value)
       continue;

    if (Array.isArray(value)) {
      value.forEach((v) =>
        params.push(buildQueryParameter(key, v.toString()))
      );
    } else {
      params.push(buildQueryParameter(key, value.toString()));
    }
  }

  return params.join('&');
}