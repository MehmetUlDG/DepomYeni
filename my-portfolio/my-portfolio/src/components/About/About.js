import React, { useEffect, useState } from "react";
import "./About.css";
import { useLanguage } from '../../context/LanguageContext';

const About = () => {
  const [lightIntensity, setLightIntensity] = useState(0);
  const [isVisible, setIsVisible] = useState(false);
  const { language, translations } = useLanguage();

  useEffect(() => {
    const handleScroll = () => {
      const scrollY = window.scrollY;
      const maxScroll = 400;
      const intensity = Math.min(scrollY / maxScroll, 1);
      setLightIntensity(intensity);

      if (scrollY > 100) {
        setIsVisible(true);
      }
    };

    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, []);


  return (
    <section className="about-section">
       <div className="grid-overlay"></div>
      <div className={`about-content ${isVisible ? "show" : ""}`}>
        <h1 className="about-title">{translations[language].about_title}</h1>
        <p className="about-text">
          {translations[language].about_p1}
        </p>
        <p className="about-text">
          {translations[language].about_p2}
        </p>
      </div>
          <div className="about-media">
          {/* Buraya video/GIF ekleyeceğiz */}
          <video 
            className="about-video"
            autoPlay 
            loop 
            muted 
            playsInline
          >
             <source src={`${process.env.PUBLIC_URL}/video.mp4`} type="video/mp4" />
            Tarayıcınız video öğesini desteklemiyor.
          </video>
        </div>
    </section>
  );
};

export default About;




