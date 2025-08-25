import React, { useEffect, useState } from 'react';
import './DeleteTaskPage.css';
import LoadingSpinner from '../../components/LoadingSpinner/LoadingSpinner';
import Error404 from '../../components/Error/Error';
import { useNavigate, useParams } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';

const DeleteTaskPage = () => {
    const [isDeleted, setDeleted] = useState(false);
    const [isLoading, setLoading] = useState(true); // Başlangıçta true
    const [error, setError] = useState(null);
    const [message, setMessage] = useState('');
    const navigate = useNavigate();
    const { user, deleteTask, LogOut } = useAuth();
    const { taskId } = useParams();

    useEffect(() => {
        const fetchDeleteTask = async () => {
            try {
                setError(null);
                setLoading(true);
                setMessage('');
                //Kullanıcı ıd'sini anlık olarak alma
                const currentUserId = user?.id || JSON.parse(localStorage.getItem('user'))?.id;
                if (!currentUserId) {
                    setError('Kullanıcıya ait benzersiz anahtar bulunamadı. Lütfen tekrar giriş yapın.');
                    setLoading(false);
                    return;
                }

                if (!taskId) {
                    setError('Silinecek görev belirtilmedi.');
                    setLoading(false);
                    return;
                }

                const result = await deleteTask(taskId);

                if (result.success) {
                    setDeleted(true);
                    setMessage(result.message || 'Görev başarıyla silindi');

                    // Başarılıysa 2 saniye sonra yönlendir
                    setTimeout(() => {
                        navigate('/tasklist');
                    }, 2000);

                } else {
                    setError(result.error || 'Silme işlemi başarısız.');

                    if (result.shouldLogout) {
                        // Logout gerekiyorsa
                        setTimeout(() => {
                            LogOut();
                            navigate('/login');
                        }, 2000);
                    } else {
                        // Sadece hata, 5 saniye sonra yönlendir
                        setTimeout(() => {
                            navigate('/tasklist');
                        }, 5000);
                    }
                }

            } catch (error) {
                console.error('Beklenmeyen hata:', error);
                setError(`Silme işlemi esnasında bir hata oldu: ${error.message}`);

                // Hata durumunda da yönlendir
                setTimeout(() => {
                    navigate('/tasklist');
                }, 5000);
            } finally {
                setLoading(false);
            }
        };

        // Sadece taskId varsa silme işlemini başlat
        if (taskId) {
            fetchDeleteTask();
        } else {
            setError('Geçersiz görev IDsi');
            setLoading(false);
        }
    }, [taskId, user, navigate, LogOut]);

    if (isLoading) {
        return <LoadingSpinner text="Silme işlemi yapılıyor..." />;
    }

    if (error) {
        return (
            <div className="error-container">
                <Error404 errorMessage={error} className='error' />
                <button
                    className="back-button"
                    onClick={() => navigate('/tasklist')}
                >
                    Görev Listesine Dön
                </button>
            </div>
        );
    }

    if (isDeleted) {
        return (
            <div className="delete-page-container">
                <div className="delete-confirmation-box success">
                    <div className="success-icon">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="green">
                            <path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15l-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z" />
                        </svg>
                    </div>
                    <h2>Silme İşlemi Başarılı!</h2>
                    <p>{message}</p>
                    <p>2 saniye içinde görev listesine yönlendirileceksiniz...</p>
                </div>
            </div>
        );
    }

    return (
        <div className="delete-page-container">
            <div className="delete-confirmation-box">
                <div className="loading-icon">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="blue">
                        <path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8z" />
                    </svg>
                </div>
                <p>İşlem devam ediyor...</p>
            </div>
        </div>
    );
};

export default DeleteTaskPage;