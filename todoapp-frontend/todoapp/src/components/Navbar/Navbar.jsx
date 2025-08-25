import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import logo from '../../assets/logo1.svg';
import { useAuth } from '../../context/AuthContext';
import tokenService from '../../services/tokenService';


const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { LoggedIn, LogOut } = useAuth();
  const navigate = useNavigate();
  const handleLogout = () => {
    LogOut();
    navigate('/login');
    localStorage.removeItem('token');
  }

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  //Navbar özelleştirmeleri yapılacak.
  return (
    <nav className="navbar">
      <div className="navbar-container">
        { }
        <Link to="/dashboard" className="navbar-logo">
          <img
            src={logo}
            alt="Todo App"
            className="logo-image"
          />

        </Link>

        {/* Hamburger Menu Icon (Mobil) */}
        <div className="menu-icon" onClick={toggleMenu}>
          <div className={`bar ${isOpen ? 'open' : ''}`} />
          <div className={`bar ${isOpen ? 'open' : ''}`} />
          <div className={`bar ${isOpen ? 'open' : ''}`} />
        </div>

        {/* Navigasyon Linkleri */}
        <ul className={`nav-menu ${isOpen ? 'active' : ''}`}>
          {!LoggedIn && (<>
            <li className="nav-item">
              <Link to="/register" className="nav-link" onClick={toggleMenu}>
                Kayıt Ol
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/login" className="nav-link" onClick={toggleMenu}>
                Giriş Yap
              </Link>
            </li>
          </>)}
          {LoggedIn && (<>
            <li className="nav-item">
              <Link to="/dashboard" className="nav-link" onClick={handleLogout}>
                Çıkış Yap
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/tasklist" className="nav-link" onClick={toggleMenu}>
                Etkinliklerim
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/profile" className="nav-link" onClick={toggleMenu}>
                Profilim
              </Link>
            </li>
          </>)}
        </ul>
      </div>
    </nav>
  );
};

export default Navbar;