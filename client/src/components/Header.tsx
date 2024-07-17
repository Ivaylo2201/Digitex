import { AccountButton } from './AccountButton';
import { CartButton } from './CartButton';
import { CategoryLinks } from './CategoryLinks';
import { InformationPanel } from './InformationPanel';

export const Header = (): JSX.Element => {
    return (
        <header className=''>
            <InformationPanel />

            <main className='bg-theme-eerie-black flex justify-center items-center border-b-4 border-theme-lightcrimson'>
                <div className='w-2/3 flex flex-col lg:flex-row lg:justify-evenly'>
                    <section className='flex justify-center items-center pt-6 pb-3 lg:pt-7 lg:pb-7'>
                        <a
                            href=''
                            className='uppercase font-Montserrat font-bold text-4xl text-theme-white'
                        >
                            Digite
                            <span className='text-theme-lightcrimson font-normal'>
                                X
                            </span>
                        </a>
                    </section>
                    <section className='flex justify-center items-center pt-3 pb-6 lg:pt-7 lg:pb-7'>
                        <div className='flex gap-8'>
                            <AccountButton />
                            <CartButton />
                        </div>
                    </section>
                </div>
            </main>

            <CategoryLinks />
        </header>
    );
};
