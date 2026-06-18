import { useEffect, useState } from "react";
import Header from "./components/Header";
import SearchBar from "./components/SearchBar";
import FilterBar from "./components/FilterBar";
import TodoForm from "./components/TodoForm";
import TodoList from "./components/TodoList";
import { getAllTodos, deleteTodo, updateTodo, searchTodos, getByCategory, getByPriority } from "./api";
import "./App.css";

function App() {
  const [todos, setTodos] = useState([]);
  const [search, setSearch] = useState("");
  const [editingTodo, setEditingTodo] = useState(null);

  useEffect(() => {
    loadTodos();
  }, []);

  function loadTodos() {
    getAllTodos().then(function (res) {
      setTodos(res.data);
    });
  }

  function handleSearch() {
    searchTodos(search).then(function (res) {
      setTodos(res.data);
    });
  }

  function handleReset() {
    setSearch("");
    loadTodos();
  }

  function handleCategory(cat) {
    getByCategory(cat).then(function (res) {
      setTodos(res.data);
    });
  }

  function handlePriority(pri) {
    getByPriority(pri).then(function (res) {
      setTodos(res.data);
    }).catch(function () {
      setTodos([]);
    });
  }

  function handleDelete(id) {
    deleteTodo(id).then(function () {
      loadTodos();
    });
  }

  function handleEdit(todo) {
    setEditingTodo(todo);
  }

  function handleUpdate(id, data) {
    updateTodo(id, data).then(function () {
      setEditingTodo(null);
      loadTodos();
    });
  }

  function handleCancelEdit() {
    setEditingTodo(null);
  }

  return (
    <div className="container">
      <Header />
      <SearchBar search={search} setSearch={setSearch} onSearch={handleSearch} onReset={handleReset} />
      <FilterBar onCategory={handleCategory} onPriority={handlePriority} onReset={handleReset} />
      <TodoForm onAdded={loadTodos} editingTodo={editingTodo} onUpdate={handleUpdate} onCancelEdit={handleCancelEdit} />
      <TodoList todos={todos} onDelete={handleDelete} onEdit={handleEdit} />
    </div>
  );
}

export default App;