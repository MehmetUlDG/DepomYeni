import React from 'react';
import './privacy.css';

const PrivacyPolicy = () => {
  return (
    
    <div className="privacy-container">
      <div className="privacy-header">
        <h1>Gizlilik Politikası</h1>
        <p>Portfolyo sitemizde gizliliğinize önem veriyoruz. İşte veri işleme uygulamalarımız hakkında bilmeniz gerekenler.</p>
      </div>

      <div className="privacy-content">
        <div className="privacy-card card-3">
          <div className="card-header">
            <h2 className="card-title">Veri Toplama</h2>
          </div>
          <p className="card-content">
            Bu portfolyo sitesi, ziyaretçilerden herhangi bir kişisel veri (isim, e-posta, telefon numarası vb.) toplamamaktadır.
          </p>
        </div>

        <div className="privacy-card card-1">
          <div className="card-header">
            <h2 className="card-title">Çerezler (Cookies)</h2>
          </div>
          <p className="card-content">
            Bu site çerez kullanmamaktadır. Ziyaretçilerin tarayıcılarında herhangi bir iz bırakılmaz veya takip yapılmaz. Oturum yönetimi, kullanıcı tercihleri veya analiz için herhangi bir çerez teknolojisi kullanılmamaktadır.
          </p>
        </div>

        <div className="privacy-card card-2">
          <div className="card-header">
            <h2 className="card-title">Analitik Araçlar</h2>
          </div>
          <p className="card-content">
            Site, performans analizi için herhangi bir üçüncü taraf analiz aracı (Google Analytics vb.) kullanmamaktadır. Ziyaretçi davranışları, demografik bilgiler veya site kullanım istatistikleri takip edilmemektedir.
          </p>
        </div>

        <div className="privacy-card card-4">
          <div className="card-header">
            <h2 className="card-title">Yasal Uyumluluk</h2>
          </div>
          <p className="card-content">
            6698 sayılı Kişisel Verilerin Korunması Kanunu kapsamında kişisel veri işlemediğimiz için KVKK yükümlülükleri kapsamında değerlendirilmemekteyiz. Yasal gerekliliklerde değişiklik olması durumunda politikamızı güncelleyeceğiz.
          </p>
          <a href="https://www.mevzuat.gov.tr/mevzuat?MevzuatNo=6698&MevzuatTur=1&MevzuatTertip=5"
            target="_blank"
            rel="noopener noreferrer"
            className="learn-more">
            Kanun metni <i className="fas fa-arrow-right"></i>
          </a>
        </div>

        <div className="privacy-card card-2">
          <div className="card-header">
            <h2 className="card-title">Üçüncü Taraf Bağlantılar</h2>
          </div>
          <p className="card-content">
            Sitemizde sosyal medya profillerimize veya diğer dış kaynaklara bağlantılar bulunabilir. Bu sitelerin gizlilik uygulamalarından sorumlu değiliz.
          </p>
        </div>

        <div className="privacy-card card-2">
          <div className="card-header">
            <h2 className="card-title">Veri İşleme</h2>
          </div>
          <p className="card-content">
            Portfolyo sitemizde herhangi bir form, üyelik sistemi veya veri toplayıcı bileşen bulunmamaktadır. Sitede sadece projelerimiz ve deneyimlerimiz hakkında bilgi sunulmaktadır.
          </p>
        </div>

        <div className="privacy-card card-2">
          <div className="card-header">
            <h2 className="card-title">Değişiklikler</h2>
          </div>
          <p className="card-content">
            Gizlilik politikamızda değişiklik yapma hakkını saklı tutarız. Değişiklikler sitede yayınlandığında geçerli olacaktır.
            Gizlilik politikası ile ilgili herhangi bir sorunuz olursa, iletişim sayfası üzerinden bana ulaşabilirsiniz.
          </p>
        </div>

      </div>

    </div>
  );
};

export default PrivacyPolicy;
