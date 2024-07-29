import { LoggedInState } from './LoggedInState';
import { LoggedOutState } from './LoggedOutState';
import { useLogger } from './LogContextProvider';

export const AccountWindow: React.FC = () => {
    const { isLoggedIn } = useLogger();

    return (
        <section className='absolute z-50 top-16 rounded-sm flex px-10 py-5 flex-col gap-4 bg-theme-white border border-theme-gray'>
            {isLoggedIn ? <LoggedInState /> : <LoggedOutState />}
        </section>
    );
};
