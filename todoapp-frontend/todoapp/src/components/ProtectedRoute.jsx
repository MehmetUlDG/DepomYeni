import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import LoadingSpinner from './LoadingSpinner/LoadingSpinner';
import tokenService from '../services/tokenService';

const PrivateRoute = () => {

    const { authLoading } = useAuth();
    if (authLoading) {
        return <LoadingSpinner text='Kimliğiniz doğrulanıyor...' />
    }

    return tokenService.isAuthenticated ? <Outlet /> : <Navigate to='/login' />

}

export default PrivateRoute;