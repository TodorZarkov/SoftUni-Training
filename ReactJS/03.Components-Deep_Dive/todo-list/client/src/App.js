import Header from "./components/Header";
import Loading from "./components/Loading";
import Footer from "./components/Footer";
import TodosList from "./components/TodosList";

import { useEffect, useState } from "react"

function App() {

    const [todos, setTodos] = useState([]);

    useEffect(() => {
        fetch(`http://localhost:3030/jsonstore/todos`)
            .then(r => r.json())
            .then(data => {
                setTodos(Object.keys(data).map(id => ({id, ...data[id]}) ));
                //console.log(todos);
            });
    }, []);

    const toggleTodoStatus = (id) => {
        setTodos(state => state.map(t => t.id === id?({...t, isCompleted: !t.isCompleted}): t))
    };

    const onTodoAdd = () => {
        const lastId = todos[todos.length-1].id;
        const text = prompt('Task name:');
        setTodos(state => [...state, {id: lastId+1, text, isCompleted: false}])
    }

    return (
        <body>

            <Header />

            <main className="main">

                <section className="todo-list-container">
                    <h1>Todo List</h1>

                    <div className="add-btn-container">
                        <button className="btn" onClick={() => onTodoAdd()}>+ Add new Todo</button>
                    </div>

                    <div className="table-wrapper">

                        <Loading />

                        <TodosList  todos = {todos}
                                    toggleTodoStatus = {toggleTodoStatus}/>

                    </div>
                </section>
            </main>

            <Footer />

        </body>
    );
}

export default App;
