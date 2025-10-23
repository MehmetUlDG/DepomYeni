import React from "react";
const FavoritPanel = ({ favoriKitaplar }) => {
    const [acik, setAcik] = React.useState(false);

    return (
        <div className="favori-panel">
            <button 
                className="favori-toggle-btn" 
                onClick={() => setAcik(!acik)}
                aria-expanded={acik}
            >
                ⭐ Favoriler ({favoriKitaplar.length})
            </button>
            {acik && (
                <div className={`favori-liste-acilir ${acik? 'acik':''}`}>
                    {favoriKitaplar.length === 0 ? (
                        <p>Henüz favori kitap yok.</p>
                    ) : (
                        <ul>
                            {favoriKitaplar.map(k => (
                                <li key={k.id}>
                                    <strong>{k.baslik}</strong> ({k.yazar})
                                </li>
                            ))}
                        </ul>
                    )}
                </div>
            )}
        </div>
    );
};
export default FavoritPanel;