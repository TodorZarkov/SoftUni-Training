import { useState } from "react";

export const useForm = (onSubmit, initialValues) => {


    const [values, setValues] = useState(initialValues);

    const onChange = (e) => {
        setValues(state => ({...state, [e.target.name]: e.target.value}))
    }

    const onFormSubmit = (e) => {
        e.preventDefault();
        onSubmit(values);
    }

    return [values, onChange, onFormSubmit];
};