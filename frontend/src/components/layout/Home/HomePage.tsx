import { Page } from '../Page';

export function HomePage() {
  return (
    <Page>
      <div className='font-montserrat min-h-screen bg-white text-gray-900'>
        {/* Hero / Banner Section */}
        <section className='relative bg-gradient-to-r from-gray-50 to-gray-100 py-20 border-b border-gray-200'>
          <div className='max-w-7xl mx-auto px-6 grid grid-cols-1 md:grid-cols-2 gap-12 items-center'>
            {/* Banner Text & CTA */}
            <div className='space-y-6'>
              <span className='text-theme-crimson font-semibold tracking-wider uppercase text-sm'>
                Next-Gen Tech Is Here
              </span>
              <h1 className='text-4xl md:text-6xl font-extrabold tracking-tight leading-tight text-gray-900'>
                Gear Up Your <br />
                <span className='text-theme-crimson'>Ultimate PC Setup</span>
              </h1>
              <p className='text-gray-600 text-lg max-w-md'>
                Discover high-performance components, cutting-edge peripherals,
                and custom-built rigs designed for gamers and creators.
              </p>
              <div className='pt-4 flex flex-wrap gap-4'>
                <a
                  href='/shop'
                  className='px-8 py-3 bg-theme-crimson hover:bg-theme-lightcrimson text-white font-medium rounded transition-colors duration-200 shadow-lg shadow-theme-crimson/20'
                >
                  Shop PC Parts
                </a>
                <a
                  href='/builds'
                  className='px-8 py-3 border border-gray-300 hover:border-theme-crimson hover:text-theme-crimson text-gray-700 font-medium rounded transition-colors duration-200'
                >
                  Explore Prebuilts
                </a>
              </div>
            </div>

            {/* Banner Feature Graphic Placeholder */}
            <div className='hidden md:flex justify-center'>
              <div className='relative w-full max-w-md h-80 bg-white rounded-lg border border-gray-200 flex flex-col justify-center items-center p-8 text-center shadow-xl'>
                <div className='absolute inset-0 bg-gradient-to-tr from-theme-crimson/5 to-transparent rounded-lg pointer-events-none' />
                <span className='text-5xl mb-4'>🖥️</span>
                <h3 className='text-xl font-bold mb-2 text-gray-900'>
                  Deal of the Week
                </h3>
                <p className='text-gray-600 text-sm mb-4'>
                  RTX 40-Series Custom Builds now 15% off
                </p>
                <span className='text-theme-crimson font-mono font-bold text-2xl'>
                  Digitex exclusive
                </span>
              </div>
            </div>
          </div>
        </section>

        {/* Categories Section */}
        <section className='py-16 max-w-7xl mx-auto px-6'>
          <h2 className='text-2xl font-bold mb-8 border-l-4 border-theme-crimson pl-3 text-gray-900'>
            Browse Categories
          </h2>
          <div className='grid grid-cols-2 md:grid-cols-4 gap-6'>
            {[
              { name: 'Processors (CPUs)', icon: '⚙️', count: '24 Items' },
              {
                name: 'Graphics Cards',
                icon: '🎮',
                iconBg: 'bg-gray-100',
                count: '18 Items',
              },
              { name: 'Motherboards', icon: '🔌', count: '15 Items' },
              { name: 'Storage & RAM', icon: '💾', count: '32 Items' },
            ].map((cat, idx) => (
              <a
                key={idx}
                href={`/category/${idx}`}
                className='group p-6 bg-gray-50 rounded border border-gray-200 hover:border-theme-crimson hover:bg-white transition-all duration-200 text-center block shadow-sm hover:shadow-md'
              >
                <div className='text-3xl mb-3 transform group-hover:scale-110 transition-transform duration-200'>
                  {cat.icon}
                </div>
                <h3 className='font-semibold text-base text-gray-800 group-hover:text-theme-crimson transition-colors'>
                  {cat.name}
                </h3>
                <p className='text-gray-500 text-xs mt-1'>{cat.count}</p>
              </a>
            ))}
          </div>
        </section>

        {/* Trust Badges / Footer Intro */}
        <section className='py-12 max-w-7xl mx-auto px-6 grid grid-cols-1 md:grid-cols-3 gap-8 text-center md:text-left'>
          <div className='flex flex-col md:flex-row items-center gap-4'>
            <span className='text-3xl text-theme-crimson'>🚚</span>
            <div>
              <h4 className='font-bold text-gray-900'>
                Fast & Insured Shipping
              </h4>
              <p className='text-gray-600 text-sm'>
                Secure delivery on all fragile components.
              </p>
            </div>
          </div>
          <div className='flex flex-col md:flex-row items-center gap-4'>
            <span className='text-3xl text-theme-crimson'>🛡️</span>
            <div>
              <h4 className='font-bold text-gray-900'>3-Year Warranty</h4>
              <p className='text-gray-600 text-sm'>
                Official manufacturer support on major parts.
              </p>
            </div>
          </div>
          <div className='flex flex-col md:flex-row items-center gap-4'>
            <span className='text-3xl text-theme-crimson'>🛠️</span>
            <div>
              <h4 className='font-bold text-gray-900'>
                Expert Compatibility Check
              </h4>
              <p className='text-gray-600 text-sm'>
                We review your build before shipping.
              </p>
            </div>
          </div>
        </section>
      </div>
    </Page>
  );
}
