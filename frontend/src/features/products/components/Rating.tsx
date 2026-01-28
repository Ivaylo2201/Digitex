import { Star } from 'lucide-react';

type RatingProps = {
  stars: number;
  starSize?: number;
  className?: string;
  onStarClick?: (starIndex: number) => void;
};

export function Rating({
  stars,
  starSize = 18,
  className = '',
  onStarClick,
}: RatingProps) {
  const maxStars = 5;
  const rating = Math.min(Math.max(stars, 0), maxStars);

  return (
    <div className={`flex ${className}`}>
      {Array.from({ length: maxStars }).map((_, i) => {
        const starNumber = i + 1;
        const filled = starNumber <= rating;
        return (
          <Star
            key={i}
            size={starSize}
            fill={filled ? 'var(--color-theme-crimson)' : '#9CA3AF'}
            strokeWidth={0}
            className='cursor-pointer transition-colors'
            onClick={() => onStarClick && onStarClick(starNumber)}
          />
        );
      })}
    </div>
  );
}
