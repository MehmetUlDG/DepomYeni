import React,{useState} from 'react';
import './footer.css';
import {  Linkedin, GitHub, Mail} from 'react-feather';
import { useLanguage } from '../../context/LanguageContext'; // Doğru import yolu
import { NavLink } from 'react-router-dom';
import ContactSection from '../ContactSection/contactSection';

const Footer = () => {
  const currentYear = new Date().getFullYear();
  const [showMailCard, setShowMailCard] = useState(false);
  
  // useLanguage hook'unu doğru şekilde kullan
  const languageContext = useLanguage();
  
  if (!languageContext) {
    return <div>Loading...</div>; // veya null
  }

  const { language, translations } = languageContext;
  
  // Fallback mekanizması
  const currentLanguage = language || 'TR';
  const t = translations ? translations[currentLanguage] : null;

  if (!t) {
    return <div>Loading translations...</div>;
  }

   const socialLinks = {
    linkedin: "https://www.linkedin.com/in/mehmet-uluda%C4%9F-7b2604343/",
    github: "https://github.com/MehmetUlDG",
  };

  return (
    <>
    <footer className="footer">
      <div className="container">
        <div className="footer-content">
          <div className="footer-section">
            <h3>Mehmet Uludağ</h3>
            <p>{t.footer_p1}</p>
            <p>{t.footer_p2}</p>
          </div>
          
          <div className="footer-section">
            <h4>{t.footer_title1}</h4>
            <ul className="footer-links">
              <li><NavLink to="/" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_row1} </NavLink></li>
              <li><NavLink to="/projects" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_row2}</NavLink></li>
              <li><NavLink to="/projects" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_row3}</NavLink></li>
              <li><NavLink onClick={() => setShowMailCard(true)} className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_row4}</NavLink></li>
            </ul>
          </div>
          
          <div className="footer-section">
            <h4>{t.footer_title2}</h4>
            <ul className="footer-links">
              <li>{t.footer_row5}</li>
              <li>{t.footer_row6}</li>
              <li>{t.footer_row7}</li>
              <li>{t.footer_row8}</li>
            </ul>
          </div>
          
          <div className="footer-section">
            <h4>{t.footer_title3}</h4>
            <div className="social-links">
              <a href={socialLinks.linkedin} aria-label="LinkedIn">
                <Linkedin size={20} />
              </a>
              <a href={socialLinks.github} aria-label="GitHub">
                <GitHub size={20} />
              </a>
              <a onClick={() => setShowMailCard(true)} aria-label="Email">
                <Mail size={20} />
              </a>
            </div>
          </div>
        </div>
        
        <div className="footer-bottom">
          <div className="footer-divider"></div>
          <div className="footer-bottom-content">
            <p>&copy; {currentYear} {t.footer_text}</p>
            <div className="footer-legal">
              <NavLink to={"/Privacy"} className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_link1}</NavLink>
              <NavLink to={"/Use Of Term"} className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{t.footer_link2}</NavLink>
            </div>
          </div>
        </div>
      </div>
    </footer>
     {showMailCard && <ContactSection onClose={() => setShowMailCard(false)} />}
     </>
  );
};

export default Footer;