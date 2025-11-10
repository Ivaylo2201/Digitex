type DiscountLabelProps = {
  discountPercentage: number;
};

export default function DiscountLabel({
  discountPercentage
}: DiscountLabelProps) {
  if (discountPercentage <= 0) return null;

  return (
    <span className='rounded-sm z-20 absolute right-12 -top-0.5 bg-theme-crimson px-3 py-1 text-theme-white font-medium'>
      -{discountPercentage}%
    </span>
  );
}
