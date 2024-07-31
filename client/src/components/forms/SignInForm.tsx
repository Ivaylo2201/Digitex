import { ChangeEvent, useState } from 'react';
import { FormField } from './FormField';
import { User } from '../../types/User';
import { useLogger } from '../context/LogContextProvider';
import { FormLayout } from '../layout/FormLayout';

export const SignInForm: React.FC = () => {
    const [formData, setFormData] = useState<User>({
        username: '',
        password: ''
    });

    const { signIn, error } = useLogger();

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    return (
        <FormLayout
            label={'Sign in'}
            onSubmit={(e) => signIn(e, formData)}
            error={error}
            hyperlink={{
                helpText: "Don't have an account? Sign up",
                to: '/accounts/signup'
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
        </FormLayout>
    );
};
