import React from 'react';
import { Link } from 'react-router-dom';
import { useLogger } from '../context/LogContextProvider';


export const LoggedInState: React.FC = () => {
    const { signOut } = useLogger()

    return (
        <Link
            to='/accounts/signin'
            className='font-Montserrat w-32 text-center text-xm bg-theme-gunmetal hover:bg-theme-lightcrimson text-theme-white rounded-full py-2 transition-colors duration-200'
            onClick={signOut}
        >
            Sign out
        </Link>
    );
};
