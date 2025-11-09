import useCurrencyExchange from '@/lib/hooks/useCurrencyExchange';
import Rating from '@/components/shared/productCard/Rating';
import { Link } from 'react-router';
import type { ProductShortDto } from '@/lib/models/productShortDto';

type ProductCardProps = ProductShortDto;

export default function ProductCard({
  id,
  brandName,
  modelName,
  imagePath,
  price,
  discountPercentage,
  rating,
  isTop
}: ProductCardProps) {
  const { exchangeCurrency } = useCurrencyExchange();

  return (
    <Link
      to={`/products/${id}`}
      className='w-[345px] h-[375px] flex flex-col font-montserrat px-6 py-3 gap-5'
    >
      <img src={`${import.meta.env.VITE_STATIC_FILES_URL}/${imagePath}`} className='object-contain' />
      <div className='flex flex-col items-center gap-1'>
        <p className='text-gray-600'>{brandName}</p>
        <p className='font-bold text-theme-eerie-black line-clamp-1'>{modelName}</p>
        <div className='flex items-center gap-2'>
          <p className='font-bold text-theme-crimson'>
            {exchangeCurrency(price.discounted)}
          </p>
          <p className='text-sm line-through text-gray-500'>
            {exchangeCurrency(price.initial)}
          </p>
        </div>
        <Rating stars={rating} />
      </div>
    </Link>
  );
}
