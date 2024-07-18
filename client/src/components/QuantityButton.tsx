interface QuantityButtonProps {
    callback: () => void;
    Icon: React.ComponentType;
}

export const QuantityButton = ({
    callback,
    Icon
}: QuantityButtonProps): JSX.Element => {
    return (
        <button
            className='w-1/3 h-full bg-theme-white hover:bg-theme-gray transition-colors duration-150 border border-theme-lightblue flex justify-center items-center rounded-full'
            onClick={callback}
        >
            <Icon />
        </button>
    );
};
