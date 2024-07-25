import { Link } from 'react-router-dom';

export const AccountWindow: React.FC = (): JSX.Element => {
    return (
        <section className='absolute z-50 top-16 rounded-sm flex px-10 py-5 flex-col gap-4 bg-theme-white border border-theme-gray'>
            <Link
                to='/accounts/login'
                className='w-32 text-center text-xm uppercase bg-theme-gunmetal hover:bg-theme-lightcrimson text-theme-white rounded-full py-2 transition-colors duration-200'
            >
                Log in
            </Link>

            <Link
                to='/accounts/signup'
                className='w-32 text-center text-xm uppercase bg-theme-gunmetal hover:bg-theme-lightcrimson text-theme-white rounded-full py-2 transition-colors duration-200'
            >
                Sign up
            </Link>
        </section>
    );
};
