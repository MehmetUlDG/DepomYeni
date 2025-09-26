import React, { useState, useEffect } from 'react';
import './Navbar.css';
import { useLanguage } from '../context/LanguageContext';
import '../components/ContactSection/contactSection';
import ContactSection from '../components/ContactSection/contactSection';
import { NavLink } from 'react-router-dom';

const Navbar = () => {
    const [isScrolled, setIsScrolled] = useState(false);
    const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
    const [isLanguageMenuOpen, setIsLanguageMenuOpen] = useState(false);
    const [showMailCard, setShowMailCard] = useState(false);


    const { language, setLanguage, translations } = useLanguage();


    useEffect(() => {
        const handleScroll = () => setIsScrolled(window.scrollY > 2);
        window.addEventListener('scroll', handleScroll);
        return () => window.removeEventListener('scroll', handleScroll);
    }, []);


    const toggleMobileMenu = () => {
        setIsMobileMenuOpen(prev => !prev);
        if (!isMobileMenuOpen) setIsLanguageMenuOpen(false);
    };


    const toggleLanguageMenu = () => setIsLanguageMenuOpen(prev => !prev);


    const selectLanguage = (lang) => {
        setLanguage(lang);
        setIsLanguageMenuOpen(false);
    };

   

    return (
        <>
        <nav className={`navbar ${isScrolled ? 'scrolled' : ''}`}>
            <div className="navbar-container">
                <div className="navbar-logo">
                    <a href="/"><i className="fas fa-code"></i> Mehmet Uludağ</a>
                </div>


                <div className={`navbar-menu ${isMobileMenuOpen ? 'open' : ''}`}>
                    <div className="navbar-left">
                        <NavLink to="/about" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{translations[language].about}</NavLink>
                        <NavLink to="/projects" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{translations[language].projects}</NavLink>
                        <NavLink to="/projects" className={({ isActive }) => 
              `nav-link ${isActive ? 'active' : ''}`}>{translations[language].certificates}</NavLink>
                    </div>
                    <div className="navbar-right">
                        <div className="language-selector">
                            <button className="language-button" onClick={toggleLanguageMenu}>
                                <i className="fas fa-globe"></i>
                                <span>{language}</span>
                                <i className="fas fa-chevron-down"></i>
                            </button>
                            {isLanguageMenuOpen && (
                                <div className="language-menu">
                                    <button onClick={() => selectLanguage('TR')}>Türkçe (TR)</button>
                                    <button onClick={() => selectLanguage('EN')}>English (EN)</button>
                                    <button onClick={() => selectLanguage('DE')}>Deutsch (DE)</button>
                                </div>
                            )}
                        </div>
                        <a onClick={() => setShowMailCard(true)}>
                            {translations[language].contact}
                        </a>
                    </div>
                </div>
                <div className="navbar-toggle" onClick={toggleMobileMenu}>
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
            </div>
        </nav>
        {showMailCard && <ContactSection onClose={() => setShowMailCard(false)} />}
        </>
    );
};
export default Navbar;


