import React from 'react';
import './projects.css';
import { useLanguage } from '../../context/LanguageContext';

// Logo bileşenleri (gri tonlarına dönüştürülmüş)
export const ReactLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 841.9 595.3" className="skill-logo">
    <g fill="#888888">
      <ellipse cx="420.9" cy="296.5" rx="45.7" ry="45.7" />
      <g fill="none" stroke="#888888" strokeWidth="30">
        <ellipse rx="190" ry="460" cx="420.9" cy="296.5" transform="rotate(60 420.9 296.5)" />
        <ellipse rx="190" ry="460" cx="420.9" cy="296.5" transform="rotate(-60 420.9 296.5)" />
        <ellipse rx="190" ry="460" cx="420.9" cy="296.5" />
      </g>
    </g>
  </svg>
);

export const JsLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 630 630" className="skill-logo">
    <rect width="630" height="630" fill="#e0e0e0" />
    <text x="50%" y="65%" fontSize="300" fontWeight="bold" textAnchor="middle" fill="#888888">
      JS
    </text>
  </svg>
);

export const HtmlLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" className="skill-logo">
    <path fill="#9E9E9E" d="M19.037 113.876l-10.005-112.215h109.936l-10.016 112.198-45.019 12.48z" />
    <path fill="#BDBDBD" d="M64 116.8l36.378-10.086 8.559-95.878H64z" />
    <path fill="#E0E0E0" d="M64 52.455H45.788L44.53 38.361H64V24.599H29.597l.33 3.692 3.382 37.92H64zm0 35.743l-.061-.017-15.327-4.14-.979-10.975H39.816l1.92 21.426 28.213 7.83.051-.017z" />
    <path fill="#F5F5F5" d="M63.952 52.455v13.917h16.947l-1.597 17.849-15.35 4.143v14.134l28.215-7.82.207-2.325 3.234-36.233.335-3.695h-3.708zm0-27.856v13.862h33.244l.276-3.092.628-6.978.329-3.692z" />
  </svg>
);

export const CssLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" className="skill-logo">
    <path fill="#9E9E9E" d="M18.814 114.123L8.76 1.352h110.48l-10.064 112.754-45.243 12.543-45.119-12.526z" />
    <path fill="#BDBDBD" d="M64.001 116.8l36.559-10.141 8.601-96.307H64.001v106.448z" />
    <path fill="#F5F5F5" d="M64.001 51.429h18.302l1.264-14.163H64.001V23.435h34.682l-.332 3.711-3.4 38.114h-30.95V51.429z" />
    <path fill="#E0E0E0" d="M64.083 87.349l-.061.017-15.387-4.159-.985-11.031H33.752l1.937 21.717 28.331 7.863.063-.017v-14.39z" />
    <path fill="#F5F5F5" d="M81.127 64.675l-1.666 18.522-15.426 4.164v14.39l28.354-7.858.208-2.337 2.406-26.881z" />
    <path fill="#E0E0E0" d="M64.048 23.435v13.831H30.64l-.277-3.108-.628-6.978-.33-3.745h34.643zm-.047 27.996v13.831H48.792l-.277-3.108-.628-6.978-.33-3.745h16.846z" />
  </svg>
);

export const GitLogo = () => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 100 100"
    className="skill-logo"
  >
    <path
      fill="#9E9E9E"
      d="M92.71 44.41 52.59 4.29a5.92 5.92 0 0 0-8.37 0l-8.28 8.29 10.49 10.49
         a6.04 6.04 0 0 1 7.22 1.68c1.96 1.96 2.51 4.77 1.68 7.22l10.49 10.49
         a6.04 6.04 0 0 1 7.22 1.68c2.72 2.72 2.72 7.14 0 9.86-2.72 2.72-7.14 2.72-9.86 0
         a6.97 6.97 0 0 1-1.68-7.22l-9.86-9.85v25.98c.67.34 1.3.76 1.88 1.34
         2.72 2.72 2.72 7.14 0 9.86-2.72 2.72-7.14 2.72-9.86 0-2.72-2.72-2.72-7.14 0-9.86
         .58-.58 1.21-1 1.88-1.34V39.31c-.67-.34-1.3-.76-1.88-1.34
         -2.72-2.72-2.72-7.14 0-9.86 2.72-2.72 7.14-2.72 9.86 0
         1.96 1.96 2.51 4.77 1.68 7.22l9.85 9.85 9.85-9.85-10.49-10.49L44.31 4.29
         a5.92 5.92 0 0 0-8.37 0L4.29 36.94a5.92 5.92 0 0 0 0 8.37l40.12 40.12
         a5.92 5.92 0 0 0 8.37 0l40.12-40.12a5.92 5.92 0 0 0 0-8.37z"
    />
  </svg>
);

export const DotNetLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" className="skill-logo">
    <rect width="100" height="100" fill="#9E9E9E" rx="10" />
    <text x="50" y="65" textAnchor="middle" fill="#F5F5F5" fontFamily="Arial, sans-serif" fontSize="40" fontWeight="bold">.NET</text>
  </svg>
);

export const CSharpLogo = ({ className = "skill-logo", title = "C#" }) => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 790 790"
    className={className}
    role="img"
    aria-label={title}
  >
    <title>{title}</title>
    <path
      fill="#9E9E9E"
      fillRule="evenodd"
      d="m395 36-37.203 21.479L84.097 215.5v359L395 754l310.903-179.5v-359L435.395 59.322z"
    />
    <path
      fill="#F5F5F5"
      fillRule="evenodd"
      d="M397.252 618c-122.883 0-222.5-99.617-222.5-222.5S274.369 173 397.252 173c82.224 0 154.679 45.73 193.197 112.063l-88.056 50.87c-20.751-37.094-59.614-61.751-105.141-61.751-67.002 0-121.316 54.316-121.316 121.318s54.314 121.318 121.316 121.318c45.228 0 84.675-24.752 105.537-61.447l87.943 50.074C552.45 572.67 480.145 618 397.252 618"
    />
    <text
      x="532.413"
      y="447"
      fill="#F5F5F5"
      fontFamily="Open Sans"
      fontSize="169"
      fontWeight="700"
    >
      #
    </text>
  </svg>
);

export const GoLogo = ({ className = "skill-logo", title = "Go" }) => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 205.4 76.7"
    className={className}
    role="img"
    aria-label={title}
  >
    <title>{title}</title>
    <g fill="#9E9E9E">
      <path d="M15.5,23.2c-0.4,0-0.5-0.2-0.3-0.5l2.1-2.7c0.2-0.3,0.7-0.5,1.1-0.5h35.7c0.4,0,0.5,0.3,0.3,0.6l-1.7,2.6c-0.2,0.3-0.7,0.6-1,0.6L15.5,23.2z"/>
      <path d="M0.4,32.4c-0.4,0-0.5-0.2-0.3-0.5l2.1-2.7c0.2-0.3,0.7-0.5,1.1-0.5h45.6c0.4,0,0.6,0.3,0.5,0.6l-0.8,2.4c-0.1,0.4-0.5,0.6-0.9,0.6L0.4,32.4z"/>
      <path d="M24.6,41.6c-0.4,0-0.5-0.3-0.3-0.6l1.4-2.5c0.2-0.3,0.6-0.6,1-0.6h20c0.4,0,0.6,0.3,0.6,0.7L47.1,41c0,0.4-0.4,0.7-0.7,0.7L24.6,41.6z"/>
      <path d="M128.4,21.4c-6.3,1.6-10.6,2.8-16.8,4.4c-1.5,0.4-1.6,0.5-2.9-1c-1.5-1.7-2.6-2.8-4.7-3.8c-6.3-3.1-12.4-2.2-18.1,1.5c-6.8,4.4-10.3,10.9-10.2,19c0.1,8,5.6,14.6,13.5,15.7c6.8,0.9,12.5-1.5,17-6.6c0.9-1.1,1.7-2.3,2.7-3.7c-3.6,0-8.1,0-19.3,0c-2.1,0-2.6-1.3-1.9-3c1.3-3.1,3.7-8.3,5.1-10.9c0.3-0.6,1-1.6,2.5-1.6c5.1,0,23.9,0,36.4,0c-0.2,2.7-0.2,5.4-0.6,8.1c-1.1,7.2-3.8,13.8-8.2,19.6c-7.2,9.5-16.6,15.4-28.5,17c-9.8,1.3-18.9-0.6-26.9-6.6c-7.4-5.6-11.6-13-12.7-22.2c-1.3-10.9,1.9-20.7,8.5-29.3c7.1-9.3,16.5-15.2,28-17.3c9.4-1.7,18.4-0.6,26.5,4.9c5.3,3.5,9.1,8.3,11.6,14.1C130,20.6,129.6,21.1,128.4,21.4z"/>
      <path d="M161.5,76.7c-9.1-0.2-17.4-2.8-24.4-8.8c-5.9-5.1-9.6-11.6-10.8-19.3c-1.8-11.3,1.3-21.3,8.1-30.2c7.3-9.6,16.1-14.6,28-16.7c10.2-1.8,19.8-0.8,28.5,5.1c7.9 5.4,12.8,12.7,14.1,22.3c1.7,13.5-2.2,24.5-11.5,33.9c-6.6,6.7-14.7,10.9-24,12.8C166.8,76.3,164.1,76.4,161.5,76.7z M185.3,36.3c-0.1-1.3-0.1-2.3-0.3-3.3c-1.8-9.9-10.9-15.5-20.4-13.3c-9.3,2.1-15.3,8-17.5,17.4c-1.8,7.8,2,15.7,9.2,18.9c5.5,2.4,11,2.1,16.3-0.6C180.5,51.3,184.8,44.9,185.3,36.3z"/>
    </g>
  </svg>
);

export const NodeLogo = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 256 288" className="skill-logo">
    <path fill="#9E9E9E" d="M127.9 0L0 72v144l127.9 72L256 216V72z" />
    <text x="50%" y="60%" textAnchor="middle" fontSize="60" fontWeight="bold" fill="#F5F5F5">
      Node
    </text>
  </svg>
);

export const PythonLogo = () => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 256 255"
    className="skill-logo"
  >
    <path
      fill="#9E9E9E"
      d="M126.9 0c-10.9 0-21.4.9-30.6 2.5-27.1 4.8-32 14.9-32 33.5v24.6h64v8H41.2
         c-19.4 0-36.3 11.7-41.6 34.1-6.1 25.3-6.4 41.2 0 67.6
         4.8 20 16.2 34.2 35.6 34.2h23.1v-30.7
         c0-22.2 19.2-42.7 41.6-42.7h64.1c18.5 0 32-15.1 32-33.5V36
         c0-17.9-15.2-31-32-33.5C152.7.9 137.8 0 126.9 0z
         M95.7 19.5c6.7 0 12.2 5.6 12.2 12.4
         0 6.9-5.5 12.4-12.2 12.4s-12.2-5.6-12.2-12.4
         c0-6.9 5.5-12.4 12.2-12.4z"
    />
    <path
      fill="#E0E0E0"
      d="M230.7 69.1H208v30.7c0 23.5-20 42.7-41.6 42.7h-64.1
         c-17.5 0-32 15.2-32 33.5v61.8c0 17.9 15.1 28.5 32 33.5
         20.3 6 39.8 7.1 64.1 0 16.1-4.7 32-14.1 32-33.5v-24.6h-64v-8H208
         c19.4 0 26.7-13.6 32-34.2 6.7-27.8 6.4-43.6 0-67.6
         -4.8-19.5-16.1-34.3-35.3-34.3z
         M160.8 210.6c6.7 0 12.2 5.6 12.2 12.4
         0 6.9-5.5 12.4-12.2 12.4s-12.2-5.6-12.2-12.4
         c0-6.9 5.5-12.4 12.2-12.4z"
    />
  </svg>
);

const ProjectsAndSkillsSection = () => {
  const { language, translations } = useLanguage();
  const skills = [
    { name: "React", icon: <ReactLogo /> },
    { name: "JavaScript", icon: <JsLogo /> },
    { name: "HTML5", icon: <HtmlLogo /> },
    { name: "CSS3", icon: <CssLogo /> },
    { name: "C#", icon: <CSharpLogo /> },
    { name: "Go", icon: <GoLogo /> },
    { name: "Node.js", icon: <NodeLogo /> },
    { name: "Git", icon: <GitLogo /> },
    { name: "React", icon: <ReactLogo /> },
    { name: "JavaScript", icon: <JsLogo /> },
    { name: "HTML5", icon: <HtmlLogo /> },
    { name: "C#", icon: <CSharpLogo /> },
    { name: "Go", icon: <GoLogo /> },
    {name: ".Net", icon: <DotNetLogo/>},
    {name: "Python", icon: <PythonLogo/>}
  ];

  return (
    <section className="projects-skills-section">
      {/* Projeler Bölümü */}
      <div className="projects-section">
        <div className="container">
          <div className="section-header">
            <h2 className="section-title">{translations[language].project_title}</h2>
            <p className="section-description">
              {translations[language].project_text}
            </p>
          </div>
        </div>
         </div>
         <div className='container'>
          <div className="section-header">
          </div>
          <div className="skills-container">
            <div className="skills-track">
              {skills.map((skill, index) => (
                <div key={index} className="skill-item">
                  <div className="skill-icon">
                    {skill.icon}
                  </div>
                  <span className="skill-name">{skill.name}</span>
                </div>
              ))}
            </div>
          </div>
          </div>
    </section>
  );
};

export default ProjectsAndSkillsSection;