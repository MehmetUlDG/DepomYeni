import { useFormik } from 'formik';
import './LoginPages.css';
import validationSchema from '../Validations';
import axios from 'axios';
import { useAuth } from '../../context/AuthContext';
import { useNavigate } from 'react-router-dom';
const RegisterPages = () => {
    const { Login } = useAuth();
    const navigate =useNavigate();
    const formik = useFormik({
        initialValues: {
            name: '',
            surname: '',
            email: '',
            password: ''
        },
        validationSchema: validationSchema,
       onSubmit: async (values, { setSubmitting, resetForm }) => {
    try {
        const response = await axios.post('http://localhost:5144/api/ToDoUser/register', values);
         // Süreç başarılı ise form resetleme ve yönlendirme yapılsın
        if (response.status === 200) {
            resetForm();
            alert("Kayıt Başarılı! Giriş Yapabilirsiniz.");
            navigate('/login');
            
        } else {
            alert("Kayıt Başarısız! Lütfen bilgilerinizi kontrol edin.");
        }
        // Login işlemini yapan api'ye response verisinin gönderilmesi
        Login(response);  

    }
    catch (error) {
        if (error.response && error.response.status) {
            switch (error.response.status) {
                case 400:
                    alert('Geçersiz istek. Lütfen bilgilerinizi kontrol edin.');
                    break;
                case 401:
                    alert('Yetkisiz erişim. Lütfen giriş yapın.');
                    break;
                case 500:
                    alert('Sunucu hatası. Lütfen daha sonra tekrar deneyin.');
                    break;
                case 403:
                    alert('Erişim reddedildi. Bu işlem için yetkiniz yok.');
                    break;
                default:
                    alert('Bir hata oluştu. Lütfen tekrar deneyin.');
            }
        } else {
            alert('Sunucuya ulaşılamadı veya bilinmeyen bir hata oluştu.');
        }
    }
    finally {
        setSubmitting(false);
    }
}

    });


    return (
        <div className="form-container">
            <div className="form-card">
                <header className="form-header">Kayıt Ol</header>
                <form onSubmit={formik.handleSubmit} className="form">
                    {formik.errors.general && (
                        <div style={{
                            color: 'red',
                            padding: '10px',
                            margin: '10px 0',
                            border: '1px solid red',
                            borderRadius: '4px'
                        }}>
                            {formik.errors.general}
                        </div>
                    )}
                    <div className="form-group">
                        <label htmlFor="name" className="form-label">İsim</label>
                        <input
                            type="text"
                            id="name"
                            name="name"
                            onChange={formik.handleChange}
                            value={formik.values.name}
                            className="form-input"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="surname" className="form-label">Soyisim</label>
                        <input
                            type="text"
                            id="surname"
                            name="surname"
                            onChange={formik.handleChange}
                            value={formik.values.surname}
                            className="form-input"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email" className="form-label">E-posta</label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            onChange={formik.handleChange}
                            value={formik.values.email}
                            className="form-input"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password" className="form-label">Şifre</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            onChange={formik.handleChange}
                            value={formik.values.password}
                            className="form-input"
                        />
                    </div>
                    <button type='submit' className='submit-button' disabled={formik.isSubmitting}>
                        {formik.isSubmitting ? 'Kayıt Olunuyor...' : 'Kayıt Ol'}
                    </button>
                </form>
            </div>
        </div>
    );
}
export default RegisterPages;