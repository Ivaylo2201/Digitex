import Rating from '@/components/shared/Rating';
import { Link } from 'react-router';
import type { ProductShortDto } from '@/lib/models/productShortDto';
import Price from './Price';

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
  return (
    <Link
      to={`/products/${id}`}
      className='w-[345px] h-[375px] flex flex-col font-montserrat px-6 py-3 gap-5'
    >
      <img
        src={`${import.meta.env.VITE_STATIC_FILES_URL}/${imagePath}`}
        className='object-contain'
      />
      <div className='flex flex-col items-center gap-1'>
        <p className='text-gray-600'>{brandName}</p>
        <p className='font-bold text-theme-eerie-black line-clamp-1'>
          {modelName}
        </p>
        <div className='flex items-center gap-2'>
          <Price price={price} discountPercentage={discountPercentage} />
        </div>
        <Rating stars={rating} />
      </div>
    </Link>
  );
}
