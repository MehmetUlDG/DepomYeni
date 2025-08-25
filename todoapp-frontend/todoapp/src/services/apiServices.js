import axios from 'axios';
// Api' nin kok bolumunun alınması
const api = axios.create({
    baseURL: 'http://localhost:5144/api'
});
//Tüm HTTP isteklerine otomatik olarak Authorization header'ı ekler
api.interceptors.request.use(config => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
//Tüm apilerin tek bir noktada erişim sağlar
export const getUserSpecificApi = (userId) => {
    return {
        getTasks: () => api.get(`/TodoTask/user/${userId}`),
        createTask: (taskData) => api.post(`/ToDoTask/AddTask/${userId}`, taskData),
        updateTask: (taskId, taskData) => api.put(`/ToDoTask/update/${taskId}`, taskData),
        deleteTask: (taskId) => api.delete(`/ToDoTask/delete/${taskId}`),
        getTask:()=>api.get(`/ToDoTask/task/${taskId}`),
        getUser: () => api.get(`/ToDoUser/${userId}`),
        updateUser: (values) => {
            const token = localStorage.getItem('token');
            if (!token) return Promise.reject('Token bulunamadı.')
            return api.put(`/ToDoUser`, values);
        },

        deleteUser: () => api.delete(`/ToDoUser/${userId}`),
        loginGoogle: () => api.post(`/ToDoUser/google-login`)
    }
};

