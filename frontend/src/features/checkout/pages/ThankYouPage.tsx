import { Page } from '@/components/layout/Page';
import { useQueryClient } from '@tanstack/react-query';
import { useEffect } from 'react';
import confetti from 'canvas-confetti';
import { Link } from 'react-router-dom';
import { Check } from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function ThankYouPage() {
  const queryClient = useQueryClient();
  const {
    components: { thankYouPage },
  } = useTranslation();

  useEffect(() => {
    queryClient.invalidateQueries({ queryKey: ['cart'] });

    const duration = 3500;
    const end = Date.now() + duration;

    const frame = () => {
      confetti({
        particleCount: 3,
        spread: 70,
        origin: { x: 0 },
      });

      confetti({
        particleCount: 3,
        spread: 70,
        origin: { x: 1 },
      });

      if (Date.now() < end) requestAnimationFrame(frame);
    };

    frame();
  }, [queryClient]);

  return (
    <Page>
      <div className='flex items-center justify-center min-h-[40vh] px-4'>
        <div className='max-w-lg w-full bg-white rounded-3xl shadow-xl border p-10 text-center'>
          <div className='flex justify-center mb-6'>
            <div className='h-16 w-16 flex items-center justify-center rounded-full bg-green-100 text-3xl'>
              <Check />
            </div>
          </div>

          <h1 className='text-3xl font-bold mb-3 text-theme-gunmetal'>
            {thankYouPage.paymentSuccessful}
          </h1>

          <p className='text-gray-600 mb-2'>{thankYouPage.orderProcessed}</p>

          <p className='text-gray-600 mb-6'>{thankYouPage.confirmationEmail}</p>

          <div className='flex flex-col sm:flex-row gap-3 justify-center'>
            <Link
              to='/'
              className='px-6 py-3 rounded-lg bg-theme-gunmetal text-white font-medium hover:opacity-90 transition'
            >
              {thankYouPage.continueShopping}
            </Link>

            <Link
              to='/orders'
              className='px-6 py-3 rounded-lg border font-medium hover:bg-gray-50 transition'
            >
              {thankYouPage.viewOrders}
            </Link>
          </div>
        </div>
      </div>
    </Page>
  );
}
