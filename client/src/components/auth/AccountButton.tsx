import { useState } from 'react';
import { AccountWindow } from './AccountWindow';
import AccountIcon from '../../icons/AccountIcon';

export const AccountButton: React.FC = () => {
    const [isAccountWindowOpen, setIsAccountWindowOpen] =
        useState<boolean>(false);

    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <button
                className='flex flex-col justify-center items-center cursor-pointer'
                onClick={() => setIsAccountWindowOpen(!isAccountWindowOpen)}
            >
                <AccountIcon />
                <span className='text-theme-white text-xm font-Montserrat'>
                    Account
                </span>
            </button>
            {isAccountWindowOpen && <AccountWindow />}
        </div>
    );
};
