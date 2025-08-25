import React, { use, useEffect, useState } from 'react';
import './DeletePage.css';
import LoadingSpinner from '../../components/LoadingSpinner/LoadingSpinner';
import Error404 from '../../components/Error/Error';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';

const DeletePage = () => {
  const [isDeleted, setDeleted] = useState(false);
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const { user, deleteUserAccount } = useAuth();
  const navigate = useNavigate();

  const handleDeleteAccount = async () => {

    if (!window.confirm("Hesabınızı silmek istediğinize emin misiniz?")) return;
    setLoading(true);
    const result = await deleteUserAccount();
    setLoading(false);
     //Süreç başarılı ise anasayfaya yönlendir.
    if (result.success) 
    {
      navigate('/dashboard');
    }

    else 
    {
      setError(result.error);
    }
    
  }



  if (isLoading) return <LoadingSpinner text="Silme işlemi yapılıyor..." />;
  if (error) return <Error404 errorMessage={error} className='error' />
  if (isDeleted) return <div className="success" >Silme işlemi başarılı! </div>;

  return (
    <div className="delete-page-container">
      <div className="delete-confirmation-box">
        <div className="delete-icon">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
            <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
          </svg>
        </div>

        <h2>Hesabınızı Silmek İstediğinize Emin Misiniz?</h2>
        <p>
          Bu işlem geri alınamaz. Tüm kullanıcı verileriniz, görevleriniz ve bilgileriniz kalıcı olarak silinecektir.
        </p>

        <div className="button-group">
          <button
            className="cancel-button"
            onClick={(e) => {
              e.preventDefault();
              navigate('/profile', { replace: true });
            }}
          >
            Vazgeç
          </button>
          <button
            className="delete-button"
            onClick={handleDeleteAccount}
            disabled={isLoading}
          >
            {isLoading ? (
              "Siliniyor..."
            ) : (
              "Hesabı Sil"
            )}
          </button>
        </div>
      </div>
    </div>
  );

};
export default DeletePage;