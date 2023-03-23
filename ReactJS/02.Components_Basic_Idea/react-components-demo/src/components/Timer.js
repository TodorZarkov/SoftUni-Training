import {useState} from 'react';

export default function Timer (props) {
    const [seconds, setSeconds] = useState(props.start);


    setTimeout(()=>{
        setSeconds(state => state + 1)
    }, 1000);
    return (
        <div>
            <h2>Timer</h2>
            Time: {seconds}s
        </div>
    );
};