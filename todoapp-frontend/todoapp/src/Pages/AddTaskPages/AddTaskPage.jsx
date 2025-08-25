import { useState, useEffect } from "react";
import { useFormik } from "formik";
import axios from "axios";
import Error404 from '../../components/Error/Error';
import LoadingSpinner from "../../components/LoadingSpinner/LoadingSpinner";
import './AddTaskPage.css';
import { useNavigate } from "react-router-dom";
import { useAuth } from '../../context/AuthContext';
const AddTask = () => {
    const [add, setAdd] = useState();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const { createTask, user } = useAuth();
    const formik = useFormik({
        initialValues: {
            title: '',
            description: '',
            isCompleted: '',
            createdAt: new Date().toISOString(), //Güncel tarih ataması
            completedAt: '',
            userId: user?.id || '',
            googleEventId: '',
        },
        onSubmit: async (values, { setSubmitting }) => {
            try {
                setError('');
                 setSubmitting(true);
                 // Kullanıcı ıd'sini anlık olarak alma
                const currentUserId = user?.id || JSON.parse(localStorage.getItem('user'))?.id;
                if (!currentUserId) {
                    setError('Kullanıcının benzersiz anahtarı bulunamadı.');
                    setSubmitting(false);
                }

                const taskData = {
                    ...values,
                    userId: currentUserId
                };

                const result = await createTask(values);

                if (result.success) {
                    setAdd(result.data);
                    alert('Etkinliğiniz eklenmiştir.');
                    navigate('/tasklist');
                }
                else {
                    setError(result.error || 'Görev eklenirken bir hata oldu.');
                }
            }
            catch (error) {
                setError('Bir şeyler ters gitti ' + error.message);
            }
            finally {
                setLoading(false);
                setSubmitting(false);
            }
        }
    });

    useEffect(() => {
        if (user?.id) {
            formik.setFieldValue('userId', user.id)
        }
    }, [user]);

    if (error) return <Error404 errorMessage={error} className='error' />
    return (
        <div className="body">
            <div className="update-user-container">
                <div className="update-user-title">
                    Etkinlik Ekle
                </div>
                <form onSubmit={formik.handleSubmit} className="add-task-form">
                    <div className="form-group">
                        <input name="userId" type="hidden"
                            value={formik.values.userId} />
                    </div>
                    <div className="form-group">
                        < label htmlFor="title" className="add-task">Başlık</label>
                        <input name="title" id="title" type="text" onChange={formik.handleChange}
                            value={formik.values.title} className="add-task" />
                    </div>
                    <div className="form-group">
                        < label htmlFor="description" className="add-task">Açıklama</label>
                        <input name="description" id="description" type="text" onChange={formik.handleChange}
                            value={formik.values.description} className="add-task" />
                    </div>
                    <div className="form-group">
                        < label htmlFor="isCompleted" className="add-task">Tamamlanma Durumu</label>
                        <input name="isCompleted" id="isCompleted" type="checkbox"
                            onChange={() => formik.setFieldValue('isCompleted', !formik.values.isCompleted)}
                            checked={formik.values.isCompleted} className="add-task" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="completedAt" className="update-task">Tamamlanma Tarihi</label>
                        <input
                            name="completedAt"
                            id="completedAt"
                            type="datetime-local"
                            onChange={(e) => {
                                const isoDate = new Date(e.target.value).toISOString();
                                formik.setFieldValue('completedAt', isoDate);
                            }}
                            value={formik.values.completedAt ?
                                new Date(formik.values.completedAt).toISOString().slice(0, 16) : ''}
                            className="add-task"
                        />
                    </div>
                    <button type="submit" className="add-button" disabled={formik.isSubmitting}>
                        {formik.isSubmitting ? 'Ekleniyor...' : 'Ekle'}
                    </button>
                </form>
            </div>
        </div>
    )
}
export default AddTask;