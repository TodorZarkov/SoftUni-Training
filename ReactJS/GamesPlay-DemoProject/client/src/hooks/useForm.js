import { useState } from "react";

export const useForm = (onSubmit, initialValues) => {
    
    const [values, setValues] = useState(initialValues);

   

    const onChange = (e) => {
        setValues(state => ({...state, [e.target.name]: e.target.value}))
    }

    const onChangeValues = (newValues) => {
        const checkedValues = {};
        for (const key in initialValues) {
            if (initialValues.hasOwnProperty(key)) {
                checkedValues[key] = newValues[key];
            }
        }

        setValues(checkedValues);
    };

    const onFormSubmit = (e) => {
        e.preventDefault();
        onSubmit(values);
        onChangeValues(initialValues);
    }

    return [values, onChange, onFormSubmit, onChangeValues];
};