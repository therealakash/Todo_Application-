import TodoCard from "./TodoCard";

function TodoList(props) {
    return (
        <div>
            {props.todos.map(function (todo) {
                return (
                    <TodoCard
                        key={todo.id}
                        todo={todo}
                        onEdit={props.onEdit}
                        onDelete={props.onDelete}
                    />
                );
            })}
        </div>
    );
}

export default TodoList;