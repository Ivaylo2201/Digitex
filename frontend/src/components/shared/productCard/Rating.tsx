import Star from "@/components/icons/Star";

type RatingProps = {
  stars: number;
  className?: string;
};

export default function Rating({ stars, className = '' }: RatingProps) {
  const min = 0;
  const max = 5;
  const rating = Math.min(Math.max(stars, min), max);

  return (
    <div className={`flex ${className}`}>
      {Array.from({ length: rating }).map(() => (
        <Star className='text-theme-crimson' />
      ))}
      {Array.from({ length: 5 - rating }).map(() => (
        <Star className='text-gray-400' />
      ))}
    </div>
  );
}
