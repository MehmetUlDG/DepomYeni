import { useEffect, useRef } from 'react';
import './use_of_term.css';
import {useNavigate} from 'react-router-dom';
const UseOfTerm = () => {
    const navLinksRef = useRef([]);
    const sectionsRef = useRef([]);
    const acceptButtonRef = useRef(null);
    const learnMoreLinkRef = useRef(null);
    const navigate =useNavigate();

    useEffect(() => {
        // DOM elemanlarını ref'ler aracılığıyla al
        navLinksRef.current = Array.from(document.querySelectorAll('.nav-link'));
        sectionsRef.current = Array.from(document.querySelectorAll('.content-section'));
        
        // Kabul butonu işlevselliği
        if (acceptButtonRef.current) {
            acceptButtonRef.current.addEventListener('click', handleAcceptButtonClick);
        }
        
        // "Daha fazla bilgi" linki
        if (learnMoreLinkRef.current) {
            learnMoreLinkRef.current.addEventListener('click', handleLearnMoreClick);
        }
        
        // Navigasyon linklerine tıklama olaylarını ekle
        navLinksRef.current.forEach(link => {
            link.addEventListener('click', handleNavLinkClick);
        });
        
        // Scroll olayını dinle
        window.addEventListener('scroll', setActiveNavLink);
        
        // İlk yüklemede aktif linki ayarla
        setActiveNavLink();
        
        // Sayfa yüklendiğinde animasyon efekti
        setTimeout(() => {
            document.body.classList.add('loaded');
        }, 100);
        
        // Cleanup function
        return () => {
            if (acceptButtonRef.current) {
                acceptButtonRef.current.removeEventListener('click', handleAcceptButtonClick);
            }
            
            if (learnMoreLinkRef.current) {
                learnMoreLinkRef.current.removeEventListener('click', handleLearnMoreClick);
            }
            
            navLinksRef.current.forEach(link => {
                link.removeEventListener('click', handleNavLinkClick);
            });
            
            window.removeEventListener('scroll', setActiveNavLink);
        };
    }, []);
    
    const handleAcceptButtonClick = () => {
        alert('Kullanım şartlarını kabul ettiniz. Siteye yönlendiriliyorsunuz.');
        navigate('/');
    };
    
    const handleLearnMoreClick = (e) => {
        e.preventDefault();
        alert('Gizlilik politikası sayfasına yönlendirileceksiniz.');
        navigate('/Privacy');
    };
    
    const handleNavLinkClick = (e) => {
        e.preventDefault();
        
        const targetId = e.currentTarget.getAttribute('href');
        const targetSection = document.querySelector(targetId);
        
        if (targetSection) {
            window.scrollTo({
                top: targetSection.offsetTop - 20,
                behavior: 'smooth'
            });
        }
    };
    
    const setActiveNavLink = () => {
        let currentSection = '';
        
        sectionsRef.current.forEach(section => {
            const sectionTop = section.offsetTop;
            
            if (window.pageYOffset >= (sectionTop - 200)) {
                currentSection = section.getAttribute('id');
            }
        });
        
        navLinksRef.current.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href').substring(1) === currentSection) {
                link.classList.add('active');
            }
        });
    };

    return (
        <div className="useofterm-container">
            <div className="useofterm-header">
                <h1>Kullanım Şartları</h1>
                <p>Bu portfolyo sitesini kullanmadan önce lütfen kullanım şartlarımızı dikkatlice okuyunuz.</p>
            </div>

            <div className="useofterm-content">
                <div className="acceptance-notice">
                    <p>Bu siteyi ziyaret ederek, aşağıdaki kullanım koşullarını kabul etmiş olursunuz. Koşullardan herhangi birini kabul etmiyorsanız, lütfen siteyi kullanmayınız.</p>
                </div>

                <div className="content-navigation">
                    <h3>İçindekiler</h3>
                    <ul>
                        <li><a href="#privacy" className="nav-link">1. Gizlilik</a></li>
                        <li><a href="#copyright" className="nav-link">2. Telif Hakları</a></li>
                        <li><a href="#general" className="nav-link">3. Genel Hükümler</a></li>
                        <li><a href="#updates" className="nav-link">4. Sözleşme Güncellemeleri</a></li>
                        <li><a href="#liability" className="nav-link">5. Sorumluluğun Sınırlandırılması</a></li>
                        <li><a href="#jurisdiction" className="nav-link">6. Uygulanacak Hukuk ve Yetkili Mahkeme</a></li>
                    </ul>
                </div>

                <div className="content-section" id="privacy">
                    <h2>1. Gizlilik</h2>
                    <p>Gizlilik Politikamız başka bir sayfada yer almaktadır. İnternet sitesini kullanmaya devam ettiğiniz takdirde kişisel verilerinizin, gizlilik politikamıza uygun olarak işlenmesine rıza gösterdiğiniz kabul edilecektir.</p>
                    <a href="#" className="learn-more" ref={learnMoreLinkRef}>Daha fazla bilgi <i>→</i></a>
                </div>

                <div className="content-section" id="copyright">
                    <h2>2. Telif Hakları</h2>
                    <p>Bu portfolyo sitesinde yer alan tüm içerikler (metinler, görseller, projeler, tasarımlar, kod parçacıkları ve diğer tüm materyaller) fikri mülkiyet ve telif haklarına tabi olup, Fikir ve Sanat Eserleri Kanunu ve ilgili diğer yasal mevzuatlar çerçevesinde korunmaktadır.</p>
                </div>

                <div className="content-section" id="general">
                    <h2>3. Genel Hükümler</h2>
                    <p>Bu portfolyo sitesi tarafından sunulan bilgiler ve hizmetler, herhangi bir hukuki koruma garanti etmemektedir. Sitede sunulan içeriklerin kullanılması neticesinde uğrayabileceğiniz zararlar dolayısıyla, doğrudan ve/veya dolaylı hiçbir sorumluluk kabul edilmemektedir.</p>

                    <p>Portfolyo sitesinde yer alan bilgilerin doğruluk ve güncelliğini sağlamak için elimizden geleni yapmaktayız. Ancak, gösterdiğimiz tüm bu çabaya rağmen ortaya çıkabilecek ihtilaflarda, site içerisinde yer alan bilgilerin doğruluğu ve güncelliği ile ilgili açık veya zımni, herhangi bir garanti verilmemekte, hiçbir taahhütte bulunulmamaktadır.</p>
                </div>

                <div className="content-section" id="updates">
                    <h2>4. Sözleşme Güncellemeleri</h2>
                    <p>Bu sayfada yer alan Kullanım Koşulları, herhangi bir zamanda, önceden bildirimde bulunmaksızın değiştirilebilmektedir. İnternet sitesini kullanmaya devam ettiğiniz takdirde, bu Kullanım Koşulları'nın en güncel versiyonunu kabul etmiş olduğunuz varsayılır.</p>
                </div>

                <div className="content-section" id="liability">
                    <h2>5. Sorumluluğun Sınırlandırılması</h2>
                    <p>Portfolyo sitesinin kullanımından doğan zararlara ilişkin sorumluluk, kast ve ağır ihmal ile sınırlıdır. Sözleşmenin ihlalinden doğan zararlarda, talep edilebilecek toplam tazminat, öngörülebilir hasarlar ile sınırlıdır.</p>
                </div>

                <div className="content-section" id="jurisdiction">
                    <h2>6. Uygulanacak Hukuk ve Yetkili Mahkeme</h2>
                    <p>İşbu Sözleşme'nin uygulanmasından veya yorumlanmasından doğacak her türlü uyuşmazlığın çözümünde, Türkiye Cumhuriyeti yasaları uygulanır. İstanbul Adliyesi Mahkemeleri ve İcra Daireleri yetkilidir.</p>
                </div>

                <div className="last-update">
                    <p>Son Güncelleme: 21 Eylül 2025</p>
                </div>

                <button className="accept-button" id="acceptButton" ref={acceptButtonRef}>Kullanım Şartlarını Kabul Ediyorum</button>
            </div>
        </div>
    );
};

export default UseOfTerm;