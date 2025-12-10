export function toQueryParams(obj: Record<string, any>, prefix = ''): string {
  const params: string[] = [];

  for (const key in obj) {
    if (!obj.hasOwnProperty(key)) continue;

    const value = obj[key];
    const paramKey = prefix
      ? `${prefix}[${encodeURIComponent(key)}]`
      : encodeURIComponent(key);

    if (value === null || value === undefined) continue;
    if (typeof value === 'object' && !Array.isArray(value)) {
      params.push(toQueryParams(value, paramKey));
    } else if (Array.isArray(value)) {
      value.forEach((v) => {
        params.push(`${paramKey}[]=${encodeURIComponent(v)}`);
      });
    } else {
      params.push(`${paramKey}=${encodeURIComponent(value)}`);
    }
  }

  return params.join('&');
}
