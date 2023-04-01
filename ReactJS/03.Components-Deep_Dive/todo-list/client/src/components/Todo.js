export default function Todo({
    todos,
    toggleTodoStatus,
}) {
    return todos.map(todo =>
        <tr key={todo.id} className={`todo${todo.isCompleted ? ' is-completed' : ''}`}>
            <td>{todo.text}</td>
            <td>{todo.isCompleted ? 'Complete' : 'Not Complete'}</td>
            <td className="todo-action">
                <button className="btn todo-btn" onClick={() => toggleTodoStatus(todo.id)}>Change status</button>
            </td>
        </tr>
    )
};