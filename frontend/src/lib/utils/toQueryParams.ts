export function toQueryParams(obj: Record<string, any>): string {
  const params: string[] = [];
  console.log(obj)

  for (const key in obj) {
    if (!Object.prototype.hasOwnProperty.call(obj, key)) continue;

    if (key.startsWith("Criteria[")) continue;

    const value = obj[key];
    if (value === undefined || value === null) continue;

    if (Array.isArray(value)) {
      if (!value.length) continue;

      const encoded = value
        .map(v => encodeURIComponent(v.toString().trim()))
        .join(",");

      params.push(`Criteria[${encodeURIComponent(key)}]=${encoded}`);
    } else {
      params.push(
        `Criteria[${encodeURIComponent(key)}]=${encodeURIComponent(
          value.toString()
        )}`
      );
    }
  }

  console.log(params.join("&"))
  return params.join("&");
}
