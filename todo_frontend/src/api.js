import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5244/api/todo",
});

export const getAllTodos = () => api.get("/");
export const createTodo = (data) => api.post("/", data);
export const updateTodo = (id, data) => api.put(`/${id}`, data);
export const deleteTodo = (id) => api.delete(`/${id}`);
export const searchTodos = (keyword) =>
    api.get(`/search`, { params: { keyword } });

export const getByCategory = (cat) =>
    api.get(`/categorize/${cat}`);

export const getByPriority = (pri) =>
    api.get(`/priority/${pri}`);