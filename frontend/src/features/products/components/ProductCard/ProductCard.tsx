import { Rating } from '@/features/products/components/Rating';
import { Link } from 'react-router';
import type { ProductShort } from '@/features/products/models/base/ProductShort';
import { useCurrencyExchange } from '@/features/currency/hooks/useCurrencyExchange';

type ProductCardProps = ProductShort & { category: string };

export function ProductCard({
  id,
  brandName,
  modelName,
  imagePath,
  price,
  discountPercentage,
  rating,
  category,
}: ProductCardProps) {
  const { exchangeCurrency } = useCurrencyExchange();

  const imageSrc = `${import.meta.env.VITE_STATIC_FILES_URL}/${imagePath}`;
  const exchangedDiscountedPrice = exchangeCurrency(price.discounted);
  const exchangedInitialPrice = exchangeCurrency(price.initial);

  return (
    <Link
      to={`/products/${category}/${id}`}
      className='w-[345px] h-[375px] flex flex-col font-montserrat px-6 py-3 gap-5 relative group'
    >
      <span
        className={`${
          discountPercentage > 0 ? 'block' : 'hidden'
        } rounded-sm z-20 absolute right-12 -top-0.5 bg-theme-crimson px-3 py-1 text-sm text-theme-white font-medium`}
      >
        -{discountPercentage}%
      </span>

      <img
        src={imageSrc}
        className='object-contain group-hover:scale-105 transition-transform duration-200'
      />
      <div className='flex flex-col items-center gap-1'>
        <p className='text-gray-600'>{brandName}</p>

        <p className='font-bold text-theme-eerie-black line-clamp-1'>
          {modelName}
        </p>

        <div className='flex items-center gap-2'>
          <p className='font-bold text-theme-crimson'>
            {exchangedDiscountedPrice}
          </p>
          <p
            className={`text-sm line-through text-gray-500 ${
              discountPercentage > 0 ? 'block' : 'hidden'
            }`}
          >
            {exchangedInitialPrice}
          </p>
        </div>

        <Rating stars={rating} />
      </div>
    </Link>
  );
}
