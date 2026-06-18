import { useState, useEffect } from "react";
import { createTodo } from "../api";

function TodoForm(props) {

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [priority, setPriority] = useState("low");
    const [categorize, setCategorize] = useState("work");

    var isEditing = props.editingTodo ? true : false;

    useEffect(() => {
        if (props.editingTodo) {
            setTitle(props.editingTodo.title);
            setDescription(props.editingTodo.description);
            setPriority(props.editingTodo.priority);
            setCategorize(props.editingTodo.categorize);
        }
    }, [props.editingTodo]);

    function handleSubmit(e) {
        e.preventDefault();

        var data = { title, description, priority, categorize };

        if (isEditing) {
            props.onUpdate(props.editingTodo.id, data);
        } else {
            createTodo(data).then(() => {
                props.onAdded();
            });
        }

        setTitle("");
        setDescription("");
        setPriority("low");
        setCategorize("work");
    }

    return (
        <div className="form-box">
            <h3>{isEditing ? "Edit Todo" : "Add Todo"}</h3>

            <form onSubmit={handleSubmit}>
                <label>Title</label><br/>
                <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} required /><br/><br/>

                <label>Description</label><br/>
                <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} /><br/><br/>

                <label>Priority </label>
                <select value={priority} onChange={(e) => setPriority(e.target.value)}>
                    <option value="low">Low</option>
                    <option value="medium">Medium</option>
                    <option value="high">High</option>
                </select><br/><br/>

                <label>Category </label>
                <select value={categorize} onChange={(e) => setCategorize(e.target.value)}>
                    <option value="work">Work</option>
                    <option value="personal">Personal</option>
                </select><br/><br/>

                <button type="submit">{isEditing ? "Update" : "Add"}</button>
                {isEditing && <button type="button" onClick={props.onCancelEdit}> Cancel</button>}
            </form>
        </div>
    );
}

export default TodoForm;