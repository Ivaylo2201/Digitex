import axios, { AxiosResponse } from 'axios';
import { createContext, FormEvent, useContext, useState } from 'react';
import { NavigateFunction, useNavigate } from 'react-router-dom';
import getAuthHeaders from '../utils/getAuthHeaders';
type User = {
    username: string;
    password: string;
};

type LogContextType = {
    signIn: (e: FormEvent, body: User) => void;
    signOut: () => void;
    signUp: (e: FormEvent, body: User) => void;
    setError: React.Dispatch<React.SetStateAction<string>>;
    error: string;
    isLoggedIn: boolean;
};

type ProviderProps = {
    children: React.ReactNode;
};

const LogContext = createContext<LogContextType | null>(null);

export const useLogger = (): LogContextType => {
    const context = useContext(LogContext);
    if (!context) {
        throw new Error();
    }
    return context;
};

export const LogProvider: React.FC<ProviderProps> = ({ children }) => {
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(
        !(localStorage.getItem('token') === null)
    );
    const [error, setError] = useState<string>('');
    const navigate: NavigateFunction = useNavigate();

    const signIn = async (e: FormEvent, body: User): Promise<void> => {
        e.preventDefault();
        const url: string = 'http://localhost:8000/api/accounts/signin/';

        try {
            const response: AxiosResponse<{ token: string }> = await axios.post(
                url,
                body
            );
            localStorage.setItem('token', response.data.token);
            setIsLoggedIn(true);
            setError('');
            navigate('/');
        } catch (error) {
            if (axios.isAxiosError(error)) {
                setError(error.response?.data.detail);
            }
        }
    };

    const signOut = async (): Promise<void> => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
        const url: string = 'http://localhost:8000/api/accounts/signout/';

        try {
            await axios.delete(url, getAuthHeaders());
        } catch (error) {
            console.error(error);
        }
    };

    const signUp = async (e: FormEvent, body: User): Promise<void> => {
        e.preventDefault();
        const url: string = 'http://localhost:8000/api/accounts/signup/';

        try {
            await axios.post(url, body);
            signIn(e, body);
        } catch (error) {
            console.error(error);
        }
    };

    const contextValue: LogContextType = {
        isLoggedIn,
        setError,
        error,
        signIn,
        signOut,
        signUp
    };

    return (
        <LogContext.Provider value={contextValue}>
            {children}
        </LogContext.Provider>
    );
};
