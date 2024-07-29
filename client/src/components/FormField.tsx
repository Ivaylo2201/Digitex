import { ChangeEvent } from "react";

type FormFieldProps = {
    type: string;
    placeholder: string;
    onChange: (e: ChangeEvent<HTMLInputElement>) => void;
};

export const FormField: React.FC<FormFieldProps> = ({
    type,
    placeholder,
    onChange
}) => {
    return (
        <input
            type={type}
            placeholder={placeholder}
            name={placeholder.toLowerCase()}
            className='px-2 py-1 bg-theme-gray outline-none'
            onChange={onChange}
        />
    );
};
