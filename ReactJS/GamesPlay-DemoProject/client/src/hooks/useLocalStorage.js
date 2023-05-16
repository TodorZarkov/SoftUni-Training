import { useState } from "react";

export const useLocalStorage = (key, initialValue) => {
    

    const [state, setState] = useState(() => {
        const persistetStateSerialized = localStorage.getItem(key);
        if(persistetStateSerialized) {
            const persistedState = JSON.parse(persistetStateSerialized);
            return persistedState;
        } else {
            return initialValue;
        }
    });


    const setLocalStorage = (value) => {
        setState(value);
        localStorage.setItem(key, JSON.stringify(value));
    } ;

    
    return [state, setLocalStorage];
};

//get when load from storage if any
//set storage
//update storage
//[state, setState] = useState(key, initValues)