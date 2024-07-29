import { ChangeEvent, FormEvent, useEffect, useState } from 'react';
import { useLogger } from './LogContextProvider';
import { FormField } from './FormField';

type User = {
    username: string;
    password: string;
};

export const SignInForm: React.FC = () => {
    const [formData, setFormData] = useState<User>({
        username: '',
        password: ''
    });
    const { signIn, setError, error } = useLogger();

    useEffect(() => {
        setError('');
    }, [formData]);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleSubmit = (e: FormEvent) => {
        signIn(e, formData);
    };

    return (
        <main className='p-10 lg:p-20 flex justify-center'>
            <form
                onSubmit={handleSubmit}
                className='p-14 bg-theme-white relative inline-flex flex-col gap-6 items-center font-Montserrat border-2 rounded-lg border-theme-gray transition-colors duration-150 hover:border-theme-crimson'
            >
                <h2 className='text-4xl mb-6 font-bold text-theme-darkblue'>
                    Sign in
                </h2>
                <FormField
                    type='text'
                    placeholder='Username'
                    onChange={handleChange}
                />
                <FormField
                    type='password'
                    placeholder='Password'
                    onChange={handleChange}
                />
                <hr className='w-full' />
                <span className='font-bold text-theme-crimson'>{error}</span>
                <button
                    type='submit'
                    className='text-xm uppercase bg-theme-crimson hover:bg-theme-lightcrimson text-theme-white rounded-full px-5 py-2 mr-1 transition-colors duration-150'
                >
                    Sign In
                </button>
            </form>
        </main>
    );
};
