import BookCard from "./BookCard";
const BookList = ({ kitaplar, toggleFavori }) => {
    if (kitaplar.length === 0) {
        return <p className="sonuc-yok">Aradığınız kriterlere uygun kitap bulunamadı.</p>;
    }

    return (
        <div className="kitap-liste">
            {kitaplar.map(kitap => (
                <BookCard 
                    key={kitap.id}
                    {...kitap}
                    toggleFavori={toggleFavori}
                />
            ))}
        </div>
    );
};
export default BookList;