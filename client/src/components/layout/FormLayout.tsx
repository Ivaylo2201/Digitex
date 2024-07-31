import { FormEvent } from 'react';
import { Link } from 'react-router-dom';

export type Form = {
    username: string;
    password: string;
};

type Hyperlink = {
    helpText: string;
    to: string;
};

interface FormProps {
    label: string;
    onSubmit: (e: FormEvent) => void;
    children: React.ReactNode;
    error: string;
    hyperlink: Hyperlink;
}

export const FormLayout: React.FC<FormProps> = ({
    label,
    onSubmit,
    children,
    error,
    hyperlink
}) => {
    return (
        <main className='p-10 lg:p-20 flex justify-center'>
            <form
                onSubmit={onSubmit}
                className='p-14 bg-theme-white relative inline-flex flex-col gap-4 items-center font-Montserrat border-2 rounded-lg border-theme-gray transition-colors duration-150 hover:border-theme-crimson'
            >
                <h2 className='text-4xl mb-6 font-bold text-theme-darkblue'>
                    {label}
                </h2>

                {children}

                <hr className='w-full' />
                <p>
                    {hyperlink.helpText}{' '}
                    <Link
                        to={hyperlink.to}
                        className='font-bold text-theme-crimson'
                    >
                        here
                    </Link>
                </p>
                <span className='font-bold text-theme-crimson'>{error}</span>
                <button
                    type='submit'
                    className='text-xm uppercase bg-theme-crimson hover:bg-theme-lightcrimson text-theme-white rounded-full px-8 py-2 mr-1 transition-colors duration-150'
                >
                    {label}
                </button>
            </form>
        </main>
    );
};
