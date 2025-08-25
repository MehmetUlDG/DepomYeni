import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Error.css';

const Error404 = ({errorMessage, className =''}) => {
  const navigate = useNavigate();

  return (
    <div className="error-container ${className}">
      <div className="error-content">
        <div className="error-animation">
          <div className="error-404">404</div>
          <div className="error-circle"></div>
          <div className="error-circle-small"></div>
        </div>
        <h1 className="error-title">Hata</h1>
        <p className="error-message">
          {errorMessage || 'Bir şeyler yanlış gitti!'}
        </p>
        <button 
          className="error-button"
          onClick={() => navigate('/dashboard')}
        >
          Anasayfaya Dön
        </button>
      </div>
    </div>
  );
};

export default Error404;