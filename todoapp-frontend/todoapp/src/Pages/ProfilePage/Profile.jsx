import './Profile.css';
import logo from '../../assets/user.png';
import axios from 'axios';
import LoadingSpinner from '../../components/LoadingSpinner/LoadingSpinner';
import { useState, useEffect } from 'react';
import Error404 from '../../components/Error/Error';
import { useNavigate } from 'react-router-dom';
import tokenService from '../../services/tokenService';
import { useAuth } from '../../context/AuthContext';
import { getUserSpecificApi } from '../../services/apiServices';
const Profile = () => {
    const [userData, setUserData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const { user } = useAuth();
    const { LogOut } = useAuth();

    useEffect(() => {
        const fetchUser = async () => {
            if (!user?.id) {
                setLoading(false);
                setError('Kullanıcı bilgileri yüklenmedi');
                return;
            }
            // Kullanıcı bilgilerinin getirilmesi
            try {
                const userApi = getUserSpecificApi(user.id)
                const response = await userApi.getUser();
                setUserData(response.data);
                setLoading(false);
            }
            catch (error) {
                setError('Kullanıcı bilgileri yüklenirken hata oluştu: ' + error.message);
                setLoading(false);
            };

        }

        fetchUser();
    }, [user]);
     //Backend tarih formatının değiştirilmesi
    const formatDate = (dateString) => {
        if (!dateString) return 'Tarih yok';
        try {
            return new Date(dateString).toLocaleDateString('tr-TR', {
                day: 'numeric',
                month: 'long',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });
        } catch {
            return 'Geçersiz tarih';
        }
    };
   
    const handleEdit = () => {
        navigate('/profile/edit');
    }
    const handleDelete = () => {
        navigate('/profile/delete');
    }

    const handleLogout = () => {
        LogOut();
        navigate('/login');
        localStorage.removeItem('token');
    }

    if (loading) return <LoadingSpinner text="Profiliniz yükleniyor..." />;
    if (error) return <Error404 errorMessage={error} className='error' />;

    return (
        <div className="profile-container">
            <div className="profile-header">
                <div className="profile-avatar">
                    <img
                        src={logo}
                        alt="Profil Resmi"
                    />
                </div>
                <h1 className="profile-name">
                    {userData ? '' + userData.name + ' ' + userData.surname : 'Kullanıcı Adı'}
                </h1>
                <p className="profile-title"></p>
                <h1 className="profile-email">
                    {userData ? userData.email : 'Kullanıcı E-postası'}
                </h1>
            </div>
            <div className="profile-content">
                <div className="profile-section">
                    <h1> {userData ? ' Hesap Oluşturma Tarihi ' + formatDate(userData.createdAt) : 'Hesap Oluşturma Tarihi Bilgisi Yok'}</h1>
                </div>

            </div>
            <div className="profile-actions">
                <button className="profile-button edit-btn" onClick={handleEdit}>Düzenle</button>
                <button className="profile-button delete-btn" onClick={handleDelete}>Hesabı Sil</button>
                <button className="profile-button follow-btn" onClick={handleLogout}>Çıkış Yap</button>
            </div>
        </div>
    );
}

export default Profile;