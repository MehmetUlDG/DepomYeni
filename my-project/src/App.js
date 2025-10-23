import React, { useState } from "react";
import './App.css'
import SearchStick from './components/SearchStick';
import CategoryFilter from './components/CategoryFilter';
import BookList from "./components/BookList";
import FavoritPanel from './components/FavoritPanel';

function App() {
    const ILK_KITAPLAR = [
        // Mevcut Kitaplar
        { id: 1, baslik: "Savaş ve Barış", yazar: "Lev Tolstoy", kategori: "Klasik", yayinYili: 1869 },
        { id: 2, baslik: "Küçük Prens", yazar: "Antoine de Saint-Exupéry", kategori: "Çocuk", yayinYili: 1943 },
        { id: 3, baslik: "1984", yazar: "George Orwell", kategori: "Distopya", yayinYili: 1949 },
        { id: 4, baslik: "Nutuk", yazar: "Mustafa Kemal Atatürk", kategori: "Tarih", yayinYili: 1927 },
        { id: 5, baslik: "Dorian Gray'in Portresi", yazar: "Oscar Wilde", kategori: "Klasik", yayinYili: 1890 },
        { id: 6, baslik: "Hobbit", yazar: "J. R. R. Tolkien", kategori: "Fantastik", yayinYili: 1937 },
        { id: 7, baslik: "Suç ve Ceza", yazar: "Fyodor Dostoyevski", kategori: "Klasik", yayinYili: 1866 },
        { id: 8, baslik: "Bir İdam Mahkumunun Son Günü", yazar: "Victor Hugo", kategori: "Klasik", yayinYili: 1829 },
        { id: 9, baslik: "Denemeler", yazar: "Michel de Montaigne", kategori: "Felsefe", yayinYili: 1580 },
        { id: 10, baslik: "Kürk Mantolu Madonna", yazar: "Sabahattin Ali", kategori: "Roman", yayinYili: 1943 },

        // Yeni Kitaplar (Bilim Kurgu, Polisiye, Biyografi, Mistik)
        { id: 11, baslik: "Dune", yazar: "Frank Herbert", kategori: "Bilim Kurgu", yayinYili: 1965 },
        { id: 12, baslik: "Sherlock Holmes'ün Maceraları", yazar: "Arthur Conan Doyle", kategori: "Polisiye", yayinYili: 1892 },
        { id: 13, baslik: "Homo Deus", yazar: "Yuval Noah Harari", kategori: "Tarih", yayinYili: 2016 },
        { id: 14, baslik: "Yüzüklerin Efendisi", yazar: "J. R. R. Tolkien", kategori: "Fantastik", yayinYili: 1954 },
        { id: 15, baslik: "Körlük", yazar: "José Saramago", kategori: "Distopya", yayinYili: 1995 },
        { id: 16, baslik: "Simyacı", yazar: "Paulo Coelho", kategori: "Mistik", yayinYili: 1988 },
        { id: 17, baslik: "Fahrenheit 451", yazar: "Ray Bradbury", kategori: "Bilim Kurgu", yayinYili: 1953 },
        { id: 18, baslik: "Saatleri Ayarlama Enstitüsü", yazar: "Ahmet Hamdi Tanpınar", kategori: "Roman", yayinYili: 1961 },
        { id: 19, baslik: "Bir Bilim Adamının Romanı", yazar: "Oğuz Atay", kategori: "Biyografi", yayinYili: 1975 },
        { id: 20, baslik: "Agnes Grey", yazar: "Anne Brontë", kategori: "Klasik", yayinYili: 1847 },
        { id: 21, baslik: "Güneşin Oğlu", yazar: "Jean-Claude Servais", kategori: "Mistik", yayinYili: 1990 },
        { id: 22, baslik: "İnce Memed", yazar: "Yaşar Kemal", kategori: "Roman", yayinYili: 1955 },
        { id: 23, baslik: "Hayvan Çiftliği", yazar: "George Orwell", kategori: "Distopya", yayinYili: 1945 },
        { id: 24, baslik: "Küçük Kadınlar", yazar: "Louisa May Alcott", kategori: "Çocuk", yayinYili: 1868 },
        { id: 25, baslik: "Sonsuzluğun Sonu", yazar: "Isaac Asimov", kategori: "Bilim Kurgu", yayinYili: 1955 },
    ];

    const TUM_KATEGORILER = ["Hepsi", ...new Set(ILK_KITAPLAR.map(k => k.kategori))].sort();
    const localOku = (anahtar, varsayilan) => {
        try {
            const item = localStorage.getItem(anahtar);
            return item ? JSON.parse(item) : varsayilan;
        } catch (error) {
            console.error("Local storage okuma hatası:", error);
            return varsayilan;
        }
    };

    const localYaz = (anahtar, deger) => {
        try {
            localStorage.setItem(anahtar, JSON.stringify(deger));
        } catch (error) {
            console.error("Local storage yazma hatası:", error);
        }
    };

    const [kitaplar] = useState(ILK_KITAPLAR);
    const [aramaMetni, setAramaMetni] = useState(() => {
        const kaydedilmisMetin = localOku('kitaplik_aramaMetni')
        return kaydedilmisMetin || '';
    }
    )
    const [favoriler, setFavoriler] = useState(() => {
        const kaydedilmisVeri = localOku('kitaplik_favoriler')
        return kaydedilmisVeri || [];
    })
    const [kategori, setKategori] = useState()

    React.useEffect(() => {
        localYaz('kitaplik_favoriler', favoriler);
    }, [favoriler]);

    React.useEffect(() => {
        localYaz('kitaplik_aramaMetni', aramaMetni);
    }, [aramaMetni]);


    // Favori durumunu değiştirme fonksiyonu
    const toggleFavori = React.useCallback((kitapId) => {
        setFavoriler(prevFavoriler => {
            if (prevFavoriler.includes(kitapId)) {
                // Favoriden çıkar
                return prevFavoriler.filter(id => id !== kitapId);
            } else {
                // Favoriye ekle
                return [...prevFavoriler, kitapId];
            }
        });
    }, []);

    // Kitapları filtreleme mantığı (useMemo ile performansı artırma)
    const filtrelenmisKitaplar = React.useMemo(() => {
        let sonuclar = kitaplar;
        const normalizeArama = aramaMetni.toLowerCase().trim();
        const seciliKategori = kategori;

        // 1. Arama Metnine Göre Filtreleme
        if (normalizeArama) {
            sonuclar = sonuclar.filter(kitap =>
                kitap.baslik.toLowerCase().includes(normalizeArama)
            );
        }

        // 2. Kategoriye Göre Filtreleme
        if (seciliKategori !== 'Hepsi') {
            sonuclar = sonuclar.filter(kitap =>
                kitap.kategori === seciliKategori
            );
        }

        // Favori bilgisini ekleyerek sonuçları döndür
        return sonuclar.map(kitap => ({
            ...kitap,
            favorideMi: favoriler.includes(kitap.id)
        }));

    }, [kitaplar, aramaMetni, kategori, favoriler]);

    const favoriKitapObjeleri = React.useMemo(() =>
        kitaplar.filter(k => favoriler.includes(k.id))
        , [kitaplar, favoriler]);

    return (
        <div className="App">
            <header className="App-header">
                <h1>📚 Okul Kulübü Web Kitaplığı</h1>
            </header>

            <FavoritPanel favoriKitaplar={favoriKitapObjeleri} />

            <div className="kontrol-paneli">
                <SearchStick
                    aramaMetni={aramaMetni}
                    setAramaMetni={setAramaMetni}
                />
                <CategoryFilter
                    kategori={kategori}
                    setKategori={setKategori}
                />
            </div>

            <BookList
                kitaplar={filtrelenmisKitaplar}
                toggleFavori={toggleFavori}
            />

            <footer>
                <p>&copy;2025 Mehmet Uludağ 2321032002</p>
            </footer>
        </div>
    );
}

export default App;
