import { Link } from 'react-router-dom';
import FacebookIcon from '../icons/FacebookIcon';
import GooglePlusIcon from '../icons/GooglePlusIcon';
import InstagramIcon from '../icons/InstagramIcon';

export const Footer: React.FC = (): JSX.Element => {
    return (
        <footer className='py-8 gap-2 flex flex-col justify-center items-center bg-theme-eerie-black'>
            <Link
                to='/'
                className='uppercase font-Montserrat font-bold text-4xl text-theme-white'
            >
                Digite
                <span className='text-theme-crimson'>X</span>
            </Link>
            <hr className='bg-theme-white w-1/2 my-5' />
            <div className='flex justify-center items-center gap-7'>
                <FacebookIcon />
                <InstagramIcon />
                <GooglePlusIcon />
            </div>
            <span className='font-Montserrat text-theme-white mt-5'>
                2024 &copy; Copyright. All right reserved.
            </span>
        </footer>
    );
};
