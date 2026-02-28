export function toQueryParams(obj: Record<string, any>): string {
  const params: string[] = [];

  for (const key in obj) {
    if (!obj.hasOwnProperty(key)) continue;

    const value = obj[key];
    if (value === undefined || value === null) continue;

    if (Array.isArray(value)) {
      if (value.length === 0) continue;

      const encoded = value
        .map((v) => encodeURIComponent(v.toString().trim()))
        .join(',');

      params.push(`Criteria[${encodeURIComponent(key)}]=${encoded}`);
    } else {
      params.push(
        `Criteria[${encodeURIComponent(key)}]=${encodeURIComponent(value.toString())}`,
      );
    }
  }

  return params.join('&');
}
