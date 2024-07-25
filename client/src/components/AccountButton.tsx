import { useState } from 'react';
import AccountIcon from '../icons/AccountIcon';
import { AccountWindow } from './AccountWindow';

export const AccountButton = (): JSX.Element => {
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
