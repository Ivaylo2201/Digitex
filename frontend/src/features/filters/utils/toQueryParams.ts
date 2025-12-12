function buildQueryParameter(key: string, value: string) {
  const encodedKey = encodeURIComponent(key);
  const encodedValue = value
    .split(',')
    .map((v) => encodeURIComponent(v.trim().replace(/\s+/g, '')))
    .join(',');

  return `${encodedKey}=${encodedValue}`;
}

export function toQueryParams(obj: Record<string, any>): string {
  const params: string[] = [];

  for (const key in obj) {
    if (!obj.hasOwnProperty(key)) continue;

    const value = obj[key];
    if (!value) continue;

    if (Array.isArray(value)) {
      if (value.length === 0) continue;

      params.push(
        buildQueryParameter(key, value.map((v) => v.toString()).join(','))
      );
    } else {
      params.push(buildQueryParameter(key, value.toString()));
    }
  }

  return params.join('&');
}
