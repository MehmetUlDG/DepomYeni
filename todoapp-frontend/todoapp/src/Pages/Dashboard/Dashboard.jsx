import React from 'react';
import './dashboard.css';
import { useNavigate } from 'react-router-dom';

const Dashboard = () => {
  const navigate=useNavigate();
  return (
    <div className="dashboard-container">
      <div className="welcome-overlay">
        <div className="welcome-content">
          <h1 className="welcome-title">
            ToDoApp'ın <span className="highlight">planlı</span> ve <span className="highlight">kolaylıklarla</span> dolu dünyasına hoşgeldiniz
          </h1>
          <p className="welcome-subtitle">Görevlerinizi yönetmenin en modern yolu</p>
          <div className="cta-buttons">
            <button className="primary-btn"
              onClick={() => navigate('/Register')}>Kayıt Ol</button>
          </div>
        </div>
      </div>

      <div className="dashboard-background">
        <div className="grid-lines"></div>
        <div className="floating-elements">
          <div className="circle-element"></div>
          <div className="square-element"></div>
          <div className="triangle-element"></div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;