import Star from '@/components/icons/Star';

type RatingProps = {
  stars: number;
  className?: string;
};

export default function Rating({ stars, className = '' }: RatingProps) {
  const minStars = 0;
  const maxStars = 5;

  const rating = Math.min(Math.max(stars, minStars), maxStars);
  const emptyStars = maxStars - rating;

  return (
    <div className={`flex ${className}`}>
      {Array.from({ length: rating }).map((_, idx) => (
        <Star key={idx} className='text-theme-crimson' />
      ))}
      {Array.from({ length: emptyStars }).map((_, idx) => (
        <Star key={idx} className='text-gray-400' />
      ))}
    </div>
  );
}
