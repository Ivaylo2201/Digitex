import axios, { AxiosResponse } from 'axios';
import {
    createContext,
    FormEvent,
    useContext,
    useState
} from 'react';
import { NavigateFunction, useNavigate } from 'react-router-dom';
type User = {
    username: string;
    password: string;
};

type LogContextType = {
    signIn: (e: FormEvent, body: User) => void;
    signOut: () => void;
    signUp: () => void;
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

    const signOut = (): void => {
        setIsLoggedIn(false);
        localStorage.removeItem('token');
    };

    const signUp = async (): Promise<void> => {};


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
