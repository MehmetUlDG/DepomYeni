import { BrowserRouter, Route, BrowserRouter as Router, Routes, useLocation, useNavigate } from 'react-router-dom';
import LoginPages from './Pages/AuthPages/LoginPages';
import Navbar from './components/Navbar/Navbar';
import Profile from './Pages/ProfilePage/Profile';
import TaskCard from './components/TaskCard';
import DeletePage from './Pages/DeletePages/DeletePage';
import DeleteTaskPage from './Pages/DeletePages/DeleteTaskPage';
import UpdateUser from './Pages/UpdateUserPages/UpdateUser';
import UpdateTask from './Pages/UpdateTaskPages/UpdateTaskPage';
import AddTask from './Pages/AddTaskPages/AddTaskPage';
import PrivateRoute from './components/ProtectedRoute';
import RegisterPages from './Pages/AuthPages/RegisterPages';
import { useEffect } from 'react';
import Dashboard from './Pages/Dashboard/Dashboard';

function App() {
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => {
    const token = localStorage.getItem('token');
    // Kullanıncın giriş durumunu uygulama ayağa kalktığında kontrol ederek token yönetimi
    if(token){
      fetch("http://localhost:5144/api/ToDoUser/validate",{
        headers:{
          Authorization:`Bearer ${token}`
        }
      }).then(res=>{
        if(!res.ok){
          localStorage.removeItem("token");
          navigate("/login");
        }
      }).catch(()=>{
        localStorage.removeItem("token");
        navigate("/login");
      })
    }
  }, [navigate, location]);
  
  return (
    <>
      <Navbar />
      <Routes>
        <Route path='/login' element={<LoginPages />} />
        <Route path="/register" element={<RegisterPages />} />
        <Route path='/dashboard' element={<Dashboard />} />

        <Route element={<PrivateRoute />}>
          <Route path='/dashboard' element={<Dashboard />} />
          <Route path='/profile' element={<Profile />} />
          <Route path="/tasklist" element={<TaskCard />} />
          <Route path='/profile/edit' element={<UpdateUser />} />
          <Route path="/profile/delete" element={<DeletePage />} />
          <Route path='/tasklist/edit/:taskId' element={<UpdateTask />} />
          <Route path="/tasklist/delete/:taskId" element={<DeleteTaskPage />} />
          <Route path='/tasklist/add' element={<AddTask />} />
        </Route>
  
      </Routes>
    </>
  );
};

export default App;