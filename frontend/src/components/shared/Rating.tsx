import { Star } from "lucide-react";

type RatingProps = {
  stars: number;
  starSize?: number;
  className?: string;
};

export default function Rating({ stars, starSize = 18, className = '' }: RatingProps) {
  const minStars = 0;
  const maxStars = 5;

  const rating = Math.min(Math.max(stars, minStars), maxStars);
  const emptyStars = maxStars - rating;

  return (
    <div className={`flex ${className}`}>
      {Array.from({ length: rating }).map((_, idx) => (
        <Star key={idx} size={starSize} fill="var(--color-theme-crimson)" strokeWidth={0} />
      ))}
      {Array.from({ length: emptyStars }).map((_, idx) => (
        <Star key={idx} size={starSize} fill="#9CA3AF" strokeWidth={0} />
      ))}
    </div>
  );
}
