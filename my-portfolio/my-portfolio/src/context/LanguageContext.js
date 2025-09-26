import { footer } from 'framer-motion/client';
import React, { createContext, useContext, useState, useEffect } from 'react';

const LanguageContext = createContext();


export const LanguageProvider = ({ children }) => {
    const [language, setLanguage] = useState('TR');


    // LocalStorage'dan dili yükle
    useEffect(() => {
        const savedLang = localStorage.getItem('appLanguage');
        if (savedLang) setLanguage(savedLang);
    }, []);

    useEffect(() => {
        localStorage.setItem('appLanguage', language);
    }, [language]);


    const translations = {
        TR: {
            about: 'Hakkımda',
            projects: 'Projelerim',
            certificates: 'Sertifikalar',
            contact: 'İletişim',
            welcomeTitle: 'Merhaba , Ben Mehmet Uludağ',
            welcomeSubtitle: 'Fullstack Developer & Grafik Tasarımcısı',
            viewProjects: 'Projelerimi Gör',
            contactMe: 'İletişime Geç',
            explore: 'Keşfetmeye Başla',
            about_title: 'Ben Kimim',
            about_p1: 'FullStack geliştirme ve grafik tasarım alanında çalışıyorum. Modern, işlevsel ve estetik tasarımlar oluşturmaya tutkuluyum.',
            about_p2: 'Yeni teknolojiler öğrenmeye ve kendimi sürekli geliştirmeye önem veriyorum. Takım çalışmasına yatkın, sorumluluk sahibi ve iletişim becerileri güçlü olan bir profesyonelim.',
            project_title: 'Neler Yapıyorum',
            project_text: '1 yılı aşkın süredir fullstack geliştirme alanında kendimi geliştiriyorum. Modern teknolojiler kullanarak kullanıcı odaklı, responsive ve performanslı uygulamalar oluşturuyorum. Neler yaptığımı incelemek için gitHub profilimi ziyaret edebilirsiniz.',
            footer_p1: 'Frontend Developer & Grafik Tasarımcı',
            footer_p2: 'Modern ve etkileyici web deneyimleri oluşturuyorum.',
            footer_title1: 'Hızlı Linkler',
            footer_title2: 'Hizmetler',
            footer_title3: 'Sosyal Medya',
            footer_row1: 'Ana Sayfa',
            footer_row2: 'Projeler',
            footer_row3: 'Yetenekler',
            footer_row4: 'İletişim',
            footer_row5: 'Web Geliştirme',
            footer_row6: 'Grafik Tasarım',
            footer_row7: 'Responsive Tasarım',
            footer_row8: 'FullStack Çözümler',
            footer_text: ' Mehmet Uludağ . Tüm hakları saklıdır.',
            footer_link1: 'Gizlilik Politikası',
            footer_link2: 'Kullanım Şartları',
            contact_button: '  E-posta Uygulamasında Aç',
            contact_alert: 'Kopyalandı!',
            contact_text: 'İletişim için benimle e-posta yoluyla iletişime geçebilirsiniz',
            contact_title:'E-Posta Adresim'
        },
        EN: {
            about: 'About',
            projects: 'Projects',
            certificates: 'Certificates',
            contact: 'Contact',
            welcomeTitle: 'Hello, I am Mehmet Uludağ',
            welcomeSubtitle: 'Fullstack Developer & Graphic Designer',
            viewProjects: 'View My Projects',
            contactMe: 'Contact Me',
            explore: 'Start Exploring',
            about_title: 'Who I Am',
            about_p1: 'I work in FullStack development and graphic design. I am passionate about creating modern, functional and aesthetic designs.',
            about_p2: 'I value learning new technologies and constantly improving myself. I am a professional who is prone to teamwork, responsible and has strong communication skills.',
            project_title: 'What I Do',

            project_text: 'I have been developing myself in the field of fullstack development for over a year. I create user-oriented, responsive, and high-performance applications using modern technologies. To review my work, visit my GitHub profile.',

            footer_p1: 'Frontend Developer & Graphic Designer',
            footer_p2: 'I create modern and impressive web experiences.',
            footer_title1: 'Quick Links',
            footer_title2: 'Services',
            footer_title3: 'Social Media',
            footer_row1: 'Home',
            footer_row2: 'Projects',
            footer_row3: 'Skills',
            footer_row4: 'Contact',
            footer_row5: 'Web Development',
            footer_row6: 'Graphic Design',
            footer_row7: 'Responsive Design',
            footer_row8: 'FullStack Solutions',
            footer_text: ' Mehmet Uludağ. All rights reserved.',
            footer_link1: 'Privacy Policy',
            footer_link2: 'Terms of Use',
            contact_button: 'Open in Email App',
            contact_alert: 'Copied!',
            contact_text: 'You can contact me via email for communication',
            contact_title:'My E-Mail Adress'

        },
        DE: {
            about: 'Über mich',
            projects: 'Projekte',
            certificates: 'Zertifikate',
            contact: 'Kontakt',
            welcomeTitle: 'Hallo, ich bin Mehmet Uludağ',
            welcomeSubtitle: 'Fullstack Entwickler & Grafikdesigner',
            viewProjects: 'Meine Projekte ansehen',
            contactMe: 'Kontaktiere mich',
            explore: 'Entdecke Mehr',
            about_title: 'Wer ich bin',
            about_p1: 'Ich arbeite im Bereich FullStack-Entwicklung und Grafikdesign. Ich bin leidenschaftlich daran interessiert, moderne, funktionale und ästhetische Designs zu erstellen.',
            about_p2: 'Ich lege Wert darauf, neue Technologien zu erlernen und mich ständig weiterzuentwickeln. Ich bin ein Teamplayer, verantwortungsbewusst und verfüge über starke Kommunikationsfähigkeiten.',
            project_title: 'Was mache ich',

            project_text: 'Seit über einem Jahr entwickle ich mich im Bereich Fullstack-Entwicklung weiter. Ich erstelle benutzerorientierte, responsive und leistungsstarke Anwendungen mit modernen Technologien. Um meine Arbeiten zu sehen, besuchen Sie mein GitHub-Profil.',

            footer_p1: 'Frontend-Entwickler & Grafikdesigner',
            footer_p2: 'Ich erstelle moderne und beeindruckende Web-Erlebnisse.',
            footer_title1: 'Schnelllinks',
            footer_title2: 'Dienstleistungen',
            footer_title3: 'Soziale Medien',
            footer_row1: 'Startseite',
            footer_row2: 'Projekte',
            footer_row3: 'Fähigkeiten',
            footer_row4: 'Kontakt',
            footer_row5: 'Webentwicklung',
            footer_row6: 'Grafikdesigner',
            footer_row7: 'Responsives Design',
            footer_row8: 'FullStack-Lösungen',
            footer_text: ' Mehmet Uludağ. Alle Rechte vorbehalten.',
            footer_link1: 'Datenschutzrichtlinie',
            footer_link2: 'Nutzungsbedingungen',
            contact_button: 'In E-Mail-App öffnen',
            contact_alert: 'Kopiert!',
            contact_text: 'Sie können mich per E-Mail für Kommunikation kontaktieren',
            contact_title:'E-Mail-Adresse'

        }
    };


    return (
        <LanguageContext.Provider value={{ language, setLanguage, translations }}>
            {children}
        </LanguageContext.Provider>
    );
};

export const useLanguage = () => useContext(LanguageContext);