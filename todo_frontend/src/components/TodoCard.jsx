function TodoCard(props) {
    return (
        <div className="todo-card">
            <h3>{props.todo.title}</h3>
            <p>{props.todo.description}</p>
            <p><b>Priority:</b> {props.todo.priority}</p>
            <p><b>Category:</b> {props.todo.category}</p>
            <button onClick={() => props.onEdit(props.todo)}>Edit</button>
            <button onClick={() => props.onDelete(props.todo.id)}>Delete</button>
        </div>
    );
}

export default TodoCard;