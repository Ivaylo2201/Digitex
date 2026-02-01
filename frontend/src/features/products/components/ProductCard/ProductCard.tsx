import { Rating } from '@/features/products/components/Rating';
import { Link } from 'react-router';
import type { ProductShort } from '@/features/products/models/base/ProductShort';
import { DiscountLabel } from './DiscountLabel';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

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
  const { currency } = useCurrencyStore();

  return (
    <Link
      to={`/products/${category}/${id}`}
      className='w-[345px] h-[375px] flex flex-col font-montserrat px-6 py-3 gap-5 relative group'
    >
      <DiscountLabel discountPercentage={discountPercentage} />

      <img
        src={getStaticFile(imagePath)}
        className='w-[297px] h-[222px] object-contain group-hover:scale-105 transition-transform duration-200'
      />
      <div className='flex flex-col items-center gap-1'>
        <p className='text-gray-600'>{brandName}</p>

        <p className='font-bold text-theme-eerie-black line-clamp-1'>
          {modelName}
        </p>

        <div className='flex items-center gap-2'>
          <p className='font-bold text-theme-crimson'>
            {currency.sign}{price.discounted.toFixed(2)}
          </p>
          <p
            className={`text-sm line-through text-gray-500 ${
              discountPercentage > 0 ? 'block' : 'hidden'
            }`}
          >
            {currency.sign}{price.initial.toFixed(2)}
          </p>
        </div>

        <Rating stars={rating} />
      </div>
    </Link>
  );
}
