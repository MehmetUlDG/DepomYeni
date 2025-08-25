import { useState, useEffect } from "react";
import { useFormik } from "formik";
import axios from "axios";
import Error404 from '../../components/Error/Error';
import LoadingSpinner from "../../components/LoadingSpinner/LoadingSpinner";
import './UpdateUser.css';
import { useNavigate } from "react-router-dom";
import { useAuth } from '../../context/AuthContext';
import { getUserSpecificApi } from "../../services/apiServices";
const UpdateUser = () => {
    const [users, setUser] = useState();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const { user, updateUserProfile } = useAuth();
    const formik = useFormik({
        initialValues: {
            userId: '',
            name: '',
            surname: '',
            email: '',
            password: '',
        },
        onSubmit: async (values, { setSubmitting }) => {
           
            if (!user?.id) {
                setLoading(false);
                setError('Böyle bir kullanıcıya rastlanılmadı.');
                return;
            }
            try {
                 // Apiden gelen sonuç başarılı ise yönlendirme yapar
                const result = await updateUserProfile(values);
                if (result.success) {
                    alert('Güncelleme işlemi başarılı.');
                    navigate('/profile');
                }
                else {
                    setError('Hay Aksi! Bir şeyler ters gitti.' + error.message);
                }
            }
            catch (error) {
                console.error("Axios Hatası:", error);
                console.error("Sunucu Hatası:", error.response?.data);
                setError('Güncelleme işlemi başarısız.' + error.message);
            }
            finally {
                setLoading(false);
                setSubmitting(false);
            }
        }
    });
    useEffect(() => {
        const fetchUser = async () => {
            if (!user?.id) {
                setLoading(false);
                setError('Kullanıcı bilgileri yüklenmedi');
                return;
            }
            try {
                const userApi = getUserSpecificApi(user.id);
                const response = userApi.getUser();
                setUser(response.data);
                    // Bilgilerin formik üzerinde tutulması
                formik.setValues({
                    id: user.id,
                    name: user.name || '',
                    surname: user.surname || '',
                    email: user.email || '',
                    password: user.password || '',
                });

            } catch (error) {
                setError('Bilgiler yüklenirken beklenmeyen bir hata oldu.' + error.message);
            }
            finally {
                setLoading(false);
            }
        }
        fetchUser();
    }, []); // Sadece ilk render de çalışsın.


    if (error) return <Error404 errorMessage={error} className='error' />

    return (
        <div className="body">
            <div className="update-user-container">
                <div className="update-user-title">
                    Bilgilerini Güncelle
                </div>
                <form onSubmit={formik.handleSubmit} className="update-user-form">
                    <div className="form-group">
                        < label htmlFor="name" className="update-user">İsim</label>
                        <input name="name" id="name" type="text" onChange={formik.handleChange}
                            value={formik.values.name} className="update-user" />
                    </div>
                    <div className="form-group">
                        < label htmlFor="surname" className="update-user">Soyisim</label>
                        <input name="surname" id="surname" type="text" onChange={formik.handleChange}
                            value={formik.values.surname} className="update-user" />
                    </div>
                    <div className="form-group">
                        < label htmlFor="email" className="update-user">E-Posta</label>
                        <input name="email" id="email" type="email" onChange={formik.handleChange}
                            value={formik.values.email} className="update-user" />
                    </div>
                    <div className="form-group">
                        < label htmlFor="password" className="update-user">Şifre</label>
                        <input name="password" id="password" type="password" onChange={formik.handleChange}
                            value={formik.values.password} autoComplete="new-password" className="update-user" />
                    </div>
                    <button type="submit" className="update-button" disabled={formik.isSubmitting}>
                        {formik.isSubmitting ? 'Kaydediliyor...' : 'Kaydet'}
                    </button>
                </form>
            </div>
        </div>
    );

}
export default UpdateUser;