import { useState } from "react"
const CategoryFilter = ({kategori,setKategori}) => {
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
    return (
        <div className="kategori-filtre">
            <label htmlFor="kategori-select">Kategori:</label>
            <select
                id="kategori-select"
                value={kategori}
                onChange={(e) => setKategori(e.target.value)}
            >
                {TUM_KATEGORILER.map(cat => (
                    <option key={cat} value={cat}>{cat}</option>
                ))}
            </select>
        </div>
    )
}
export default CategoryFilter;
