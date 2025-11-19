type DiscountLabelProps = { discountPercentage: number };

export function DiscountLabel({ discountPercentage }: DiscountLabelProps) {
  return (
    <span
      className={`${
        discountPercentage > 0 ? 'block' : 'hidden'
      } rounded-sm z-20 absolute right-12 -top-0.5 bg-theme-crimson px-3 py-1 text-sm text-theme-white font-medium`}
    >
      -{discountPercentage}%
    </span>
  );
}
