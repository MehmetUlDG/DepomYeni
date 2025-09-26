import React,{useState} from 'react';
import './contactSection.css';
import { useLanguage } from '../../context/LanguageContext';
import { tr } from 'framer-motion/client';

const ContactSection = ({ onClose }) => {
  const [isCopied, setIsCopied] = useState();
  const email = "mehmetuludag2021@outlook.com"; // Buraya kendi email adresinizi yazın
  
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

    
  const copyToClipboard = () => {
    navigator.clipboard.writeText(email)
      .then(() => {
        setIsCopied(true);
        setTimeout(() => setIsCopied(false), 2000);
      })
      .catch(err => {
        console.error('Kopyalama işlemi başarısız:', err);
      });
  };

  const openEmailClient = () => {
    window.location.href = `mailto:${email}`;
  };

  return (
    <div className="mail-card-overlay" onClick={onClose}>
      <div className="mail-card" onClick={(e) => e.stopPropagation()}>
        <button className="close-btn" onClick={onClose}>
          <i className="fas fa-times"></i>
        </button>
        
        <div className="mail-card-header">
          <i className="fas fa-envelope"></i>
          <h2>{t.contact_title}</h2>
        </div>
        
        <div className="email-display">
          <span className="email-text">{email}</span>
          <button 
            className="copy-btn"
            onClick={copyToClipboard}
            title="Panoya kopyala"
          >
            <i className="fas fa-copy"></i>
          </button>
        </div>
        
        {isCopied && (
          <div className="copy-notification">
            <i className="fas fa-check"></i>
          {t.contact_alert}
          </div>
        )}
        
        <button className="email-client-btn" onClick={openEmailClient}>
          <i className="fas fa-paper-plane"></i>
         {t.contact_button}
        </button>
        
        <div className="mail-card-footer">
          <p>{t.contact_text}</p>
        </div>
      </div>
    </div>
  );
};

export default ContactSection;