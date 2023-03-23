import { useState } from "react";

function getTitle(count) {
    switch (count) {
        case 1:
            return 'First Blood';
        case 2:
            return 'Double Kill';
        case 3:
            return 'Tripple Kill';
        case 4:
            return 'Quadra Kill';
        case 5:
            return 'Unstapable';
    
        default:
            return 'Counter';
    }
}

export default function Counter(props) {
    const [counter, setCounter] = useState(0);

    function incrementCounterHandler (e) {
        setCounter(s => s + 1)
    };

    function decrementCounterHandler() {
        setCounter(s => s - 1)
    };

    function clearCounterHandler() {
        setCounter(0);
    };

    return (
        <div>
            <p style={{fontSize: Math.max(counter, 1) + 'em'}}>{counter > 5 ? 'Godlike':getTitle(counter)}:{counter}</p>
            <button onClick={decrementCounterHandler}>-</button>
            {
                props.canReset && 
                <button onClick={clearCounterHandler}>x</button>
            }
            {counter < 10
                ?<button onClick={incrementCounterHandler}>+</button>
                : null
            }
        </div>
    );
};