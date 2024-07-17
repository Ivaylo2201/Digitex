import AccountIcon from '../icons/AccountIcon';

export const AccountButton = (): JSX.Element => {
    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <a className='flex flex-col justify-center items-center cursor-pointer'>
                <AccountIcon />
                <span className='text-theme-white text-xm font-Montserrat'>
                    Account
                </span>
            </a>
        </div>
    );
};
