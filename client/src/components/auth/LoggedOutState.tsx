import { Link } from 'react-router-dom';

export const LoggedOutState: React.FC = () => {
    return (
        <>
            <Link
                to='/accounts/signin'
                className='font-Montserrat w-32 text-center text-xm bg-theme-gunmetal hover:bg-theme-lightcrimson text-theme-white rounded-full py-2 transition-colors duration-200'
            >
                Sign in
            </Link>
            <hr />
            <Link
                to='/accounts/signup'
                className='font-Montserrat w-32 text-center text-xm bg-theme-gunmetal hover:bg-theme-lightcrimson text-theme-white rounded-full py-2 transition-colors duration-200'
            >
                Sign up
            </Link>
        </>
    );
};
