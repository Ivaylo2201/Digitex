export function parseNumber(value: any) {
  const number = Number(value);
  return Number.isFinite(number) ? number : null;
}
