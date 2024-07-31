import { ChangeEvent, useState } from 'react';
import { FormField } from './FormField';
import { User } from '../../types/User';
import { useLogger } from '../context/LogContextProvider';
import { FormLayout } from '../layout/FormLayout';

export const SignUpForm: React.FC = () => {
    const [formData, setFormData] = useState<User & { email: string }>({
        username: '',
        password: '',
        email: ''
    });

    const { signUp, error } = useLogger();

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    return (
        <>
            <FormLayout
                label={'Sign up'}
                onSubmit={(e) => signUp(e, formData)}
                error={error}
                hyperlink={{
                    helpText: 'Already have an account? Sign in',
                    to: '/accounts/signin'
                }}
            >
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
                <FormField
                    type='email'
                    placeholder='Email'
                    onChange={handleChange}
                />
            </FormLayout>
        </>
    );
};
