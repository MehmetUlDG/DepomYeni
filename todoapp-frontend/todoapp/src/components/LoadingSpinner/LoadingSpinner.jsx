import React from 'react';
import './LoadingSpinner.css';

const LoadingSpinner = ({ 
  size = 50, 
  color = '#0078d4', 
  text = 'Yükleniyor...',
  textColor = '#0078d4'
}) => {
  return (
    <div className="spinner-container">
      <div 
        className="spinner" 
        style={{
          width: size,
          height: size,
          borderColor: `${color}20`,
          borderTopColor: color
        }}
      />
      {text && (
        <p className="spinner-text" style={{ color: textColor }}>
          {text}
        </p>
      )}
    </div>
  );
};

export default LoadingSpinner;