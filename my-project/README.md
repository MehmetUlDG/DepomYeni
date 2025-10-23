# 📚 React ile Okul Kütüphanesi Projesi

Bu proje, React kullanılarak geliştirilmiş basit bir okul kütüphanesi web uygulamasıdır. Kullanıcıların (öğrencilerin veya öğretmenlerin) kütüphanedeki mevcut kitapları aramasına, filtrelemesine ve listelemesine olanak tanır.

Bu proje, [React eğitimi] veya [kişisel portfolyo] amacıyla oluşturulmuştur.

##  ekran görüntüsü
![web penceresinden görüntü](<Ekran görüntüsü 2025-10-23 234336.png>)


---

## 🚀 Özellikler

Bu projenin temel özellikleri şunlardır:

* **Kitap Listeleme:** Tüm kitapların bir liste veya kart görünümünde gösterilmesi.
* **Dinamik Arama:** Kitap adı, yazar veya [kategori] bazında anlık arama yapabilme.
* **Filtreleme:** (Varsa) Kitapları kategorilerine (örn: Roman, Bilim, Tarih) göre filtreleme.
* **Kitap Detayları:** (Varsa) Her kitap için basit bir detay görünümü (kapak fotoğrafı, özet vb.).
* **Duyarlı Tasarım (Responsive):** Mobil cihazlarda ve tabletlerde düzgün çalışan arayüz.

---

## 🛠️ Kullanılan Teknolojiler

Projenin geliştirilmesinde aşağıdaki teknolojiler ve kütüphaneler kullanılmıştır:

* **[React](https://reactjs.org/):** Kullanıcı arayüzü kütüphanesi.
* **[React Hooks](https://reactjs.org/docs/hooks-intro.html):** `useState` (arama durumu, kitap listesi için), `useEffect` (veri çekme için) vb.
* **CSS3:** (veya SASS, Styled Components, Material-UI, Tailwind CSS - hangisini kullandıysanız buraya yazın) Projenin stillendirilmesi için.
* **(Opsiyonel) [React Router](https://reactrouter.com/):** (Eğer farklı sayfalar varsa, örn: Kitap Detay sayfası) Sayfalar arası gezinme için.
* **(Opsiyonel) [Axios](https://axios-http.com/):** (Eğer veriyi bir API'den çekiyorsanız) HTTP istekleri için.
* **(Opsiyonel) db.json:** (Eğer `json-server` kullandıysanız) Basit bir sahte API oluşturmak için.

---

## ⚙️ Kurulum ve Başlatma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Projeyi klonlayın:**
    ```bash
    git clone https://github.com/MehmetUlDG/DepomYeni/tree/main/my-project.git
    ```

2.  **Proje dizinine gidin:**
    ```bash
    cd my-project
    ```

3.  **Gerekli paketleri yükleyin:**
    (Eğer npm kullanıyorsanız)
    ```bash
    npm install
    ```
    (Eğer yarn kullanıyorsanız)
    ```bash
    yarn install
    ```

4.  **Projeyi başlatın:**
    (Eğer npm kullanıyorsanız)
    ```bash
    npm start
    ```
    (Eğer yarn kullanıyorsanız)
    ```bash
    yarn dev
    ```

5.  Tarayıcınızda `http://localhost:3000` (veya Vite için `http://localhost:5173`) adresini açın.

---

## 📂 Proje Yapısı (Örnek)

Projenin temel dosya yapısı şu şekildedir:

->node_modules
->public
->src
  |->components
  |-> App.css
  |-> App.js
  |-> App.test.js
  |-> index.js
  |-> index.css
  |-> reportWebVitals.js
  |-> setupTest.js
  |-> .gitignore
  |-> package-lock.json
  |-> package.json
  |-> README.md