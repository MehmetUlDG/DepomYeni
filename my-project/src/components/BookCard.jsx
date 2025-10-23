const BookCard = ({ baslik, yazar, kategori, id, favorideMi, toggleFavori }) => {
    const handleToggle = () => {
        toggleFavori(id);
    };

    return (
        <div className="kitap-kartı">
            <h3>{baslik}</h3>
            <p><strong>Yazar:</strong> {yazar}</p>
            <p><strong>Kategori:</strong> <span className={`kategori-etiketi kategori-${kategori.toLowerCase().replace(/ /g, '-')}`}>{kategori}</span></p>
            <button 
                onClick={handleToggle}
                className={`favori-btn ${favorideMi ? 'favoride' : ''}`}
                aria-label={favorideMi ? `${baslik} kitabını favorilerden çıkar` : `${baslik} kitabını favorilere ekle`}
            >
                {favorideMi ? '❤️ Favoriden Çıkar' : '🤍 Favori Ekle'}
            </button>
        </div>
    );
};
export default BookCard;