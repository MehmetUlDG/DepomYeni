import './LoginPages.css';
import { useFormik } from 'formik';
import logo from '../../assets/google.png';
import axios from 'axios';
import { useAuth } from '../../context/AuthContext';
import * as yup from 'yup';
import { useNavigate } from 'react-router-dom';
import tokenService from '../../services/tokenService';
import { Link } from 'react-router-dom';
import { useState } from 'react';
const LoginPages = () => {
    const { Login } = useAuth();
    const [submitError, setSubmitError] = useState('');
    const navigate = useNavigate();
    const formik = useFormik({
        initialValues: {
            email: '',
            password: ''
        },
        validationSchema: yup.object().shape({
            email: yup.string().email('Geçerli bir e-posta adresi giriniz.').required('E-posta alanı zorunludur.'),
            password: yup.string().min(6, 'Şifre en az 6 karakter olmalıdır.').max(18, 'Şifre en fazla 18 karakter olabilir.').required('Şifre alanı zorunludur.')
        }),
        onSubmit: async (values, { setSubmitting }) => {
            try {
                setSubmitError('');
                const { email, password } = values;
                const result = await Login(email, password);
                if (result.success) {
                    alert('Hoşgeldiniz');
                    setTimeout(() => {
                        navigate('/tasklist');
                    }, 0);
                }
                else {
                    setSubmitError(result.error || 'Hatalı giriş işlemi.');
                }

            } catch (error) {
                setSubmitError('Bir hata oluştu lütfen tekrar deneyin.');
                console.error('Login Error:', error);
            }
            finally {
                setSubmitting(false);
            }
        }
    });


    return (
        <div className='form-container'>
            <div className='form-card'>
                <header className='form-header'>Giriş Yap</header>
                {submitError && <div className="error-message">{submitError}</div>}
                <form onSubmit={formik.handleSubmit} className='form'>
                    <div className='form-group'>
                        <label htmlFor='email' className='form-label'>E-Posta</label>
                        <input
                            type='email'
                            id='email'
                            name='email'
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.email}
                            className={`form-input ${formik.touched.email && formik.errors.email ? 'error' : ''}`}
                        />
                        {formik.touched.email && formik.errors.email && (
                            <div className="validation-error">{formik.errors.email}</div>
                        )}
                    </div>
                    <div className='form-group'>
                        <label htmlFor='password' className='form-label'>Şifre</label>
                        <input
                            type='password'
                            id='password'
                            name='password'
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.password}
                            className={`form-input ${formik.touched.password && formik.errors.password ? 'error' : ''}`}
                            autoComplete='current-password'
                        />
                        {formik.touched.password && formik.errors.password && (
                            <div className="validation-error">{formik.errors.password}</div>
                        )}
                    </div>
                    <button
                        type='submit'
                        className='submit-button'
                        disabled={formik.isSubmitting}
                    >
                        {formik.isSubmitting ? 'Giriş Yapılıyor...' : 'Giriş Yap'}
                    </button>
                    <button
                        type="button"
                        className="google-login-button"
                        disabled={formik.isSubmitting}
                    >
                        <div className="google-icon-wrapper">
                            <img className="google-icon" src={logo} alt="Google logo" />
                        </div>
                        <span className="btn-text">Google ile giriş yap</span>
                    </button>
                </form>
                <div className="register-prompt">
                    <p>Henüz bir hesabınız yok mu?</p>
                    <Link to="/register" className="register-link">
                        Hesap Oluştur
                    </Link>
                </div>
            </div>
        </div>
    )
}

const parseUserFromToken = (token) => {
    try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        return {
            email: payload.email || payload.sub,
            id: payload.userId || payload.id,
            name: payload.name || payload.unique_name
        };
    } catch (error) {
        console.error('Token parse hatası:', error);
        return {
            email: 'unknown@example.com',
            id: 0,
            name: 'Unknown User'
        };
    }
};
export default LoginPages;