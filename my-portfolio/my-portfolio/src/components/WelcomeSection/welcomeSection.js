import React, { useEffect, useState } from 'react';
import './welcomeSection.css';
import { ChevronDown } from 'react-feather';
import { useLanguage } from '../../context/LanguageContext';
import { useNavigate } from 'react-router-dom';
import ContactSection from '../ContactSection/contactSection';

const WelcomeSection = () => {
    const { language, translations } = useLanguage();
    const fullText = translations[language].welcomeTitle;
    const [displayedText, setDisplayedText] = useState('');
    const [currentIndex, setCurrentIndex] = useState(0);
    const [showMailCard, setShowMailCard] = useState(false);
    const navigate=useNavigate();


    const handleNavigation=(path)=>{
          navigate(path);
    }

    useEffect(() => {
        setDisplayedText('');
        setCurrentIndex(0);
    }, [language]);


    useEffect(() => {
        if (currentIndex < fullText.length) {
            const timeout = setTimeout(() => {
                setDisplayedText(prev => prev + fullText[currentIndex]);
                setCurrentIndex(prev => prev + 1);
            }, 150);
            return () => clearTimeout(timeout);
        }
    }, [currentIndex, fullText]);


    return (
        <>
        <section className="welcome-section">
            <div className="welcome-overlay"></div>
            <div className="welcome-content">
                <div className="text-container">
                    <div className="welcome-text">
                        <h1 className="welcome-title">
                            <span className="title-line">
                                {displayedText}
                                {currentIndex < fullText.length && <span className="typing-cursor"> | </span>}
                            </span>
                        </h1>
                        <p className="welcome-subtitle">{translations[language].welcomeSubtitle}</p>
                        <div className="welcome-buttons">
                            <button onClick={()=>handleNavigation('/projects')} className="btn-primary">{translations[language].viewProjects}</button>
                            <button onClick={() => setShowMailCard(true)}  className="btn-secondary">{translations[language].contactMe}</button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="scroll-indicator">
                <p>{translations[language].explore}</p>
                <ChevronDown className="scroll-arrow" />
            </div>
        </section>
         {showMailCard && <ContactSection onClose={() => setShowMailCard(false)} />}
         </>
    );
};


export default WelcomeSection;