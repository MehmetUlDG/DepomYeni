import { useState, useEffect } from "react";
import { useFormik } from "formik";
import { useNavigate, useParams } from "react-router-dom";
import { useAuth } from '../../context/AuthContext';
import Error404 from '../../components/Error/Error';
import './UpdateTaskPage.css';

const UpdateTask = () => {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const { user, updateTask, fetchTasks } = useAuth(); 
    const {taskId}=useParams();
    const formik = useFormik({
        initialValues: {
            id: taskId ||'',
            userId: user?.id || '',
            title: '',
            description: '',
            isCompleted: false,
            createdAt: '',
            completedAt: null,
            googleEventId: '',
        },
        onSubmit: async (values, { setSubmitting }) => {
            try {
                setLoading(true);
                setError(null);
                
                if (!values.id) {
                    throw new Error('Güncellenecek görev bulunamadı');
                }
                 // Kullanıcı id'sinin anlık olarak alınması
                const currentUserId = user?.id || JSON.parse(localStorage.getItem('user'))?.id;
                if (!currentUserId) {
                    throw new Error('Kullanıcı bilgileri bulunamadı');
                }
                    // Etkinlik kart bilgileri 
                const taskData = {
                    ...values,
                    userId: currentUserId,
                    completedAt: values.isCompleted ? values.completedAt : null
                };

                const result = await updateTask(values.id, taskData);
                // Apiden gelen sonuç başarılı ise yönlendir
                if (result.success) {
                    alert('Etkinlik başarıyla güncellendi!');
                    navigate('/tasklist');
                } else {
                    throw new Error(result.error || 'Güncelleme başarısız');
                }
            } catch (error) {
                console.error("Güncelleme hatası:", error);
                setError(error.message || 'Güncelleme işlemi başarısız');
                // 401 forbidden ve diğer hata türlerinin yönetimi 
                if (error.response?.status === 401 || error.shouldLogout) {
                    localStorage.removeItem('token');
                    localStorage.removeItem('user');
                    navigate('/login');
                }
            } finally {
                setLoading(false);
                setSubmitting(false);
            }
        }
    });

    useEffect(() => {
        const loadAndSetTask = async () => {
            try {
                setLoading(true);
                setError(null);
                
                // 1. Tüm taskları çek
                const tasksResult = await fetchTasks();
                if (!tasksResult.success) {
                    throw new Error(tasksResult.error || 'Görevler yüklenemedi');
                }

                // 2. Güncellenecek taskı belirle (örneğin en son eklenen)
                const taskToUpdate = tasksResult.data.find(task => task.id.toString() === taskId); // Veya başka bir mantığa göre seç
                if (!taskToUpdate) {
                    throw new Error('Güncellenecek görev bulunamadı');
                }

                // 3. Form değerlerini ayarla
                formik.setValues({
                    id: taskToUpdate.id,
                    userId: taskToUpdate.userId,
                    title: taskToUpdate.title || '',
                    description: taskToUpdate.description || '',
                    isCompleted: Boolean(taskToUpdate.isCompleted),
                    createdAt: taskToUpdate.createdAt,
                    completedAt: taskToUpdate.completedAt || null,
                    googleEventId: taskToUpdate.googleEventId || '',
                });
            } catch (error) {
                console.error("Görev yükleme hatası:", error);
                setError(error.message || 'Bilgiler yüklenirken hata oluştu');
                
                if (error.response?.status === 401 || error.shouldLogout) {
                    localStorage.removeItem('token');
                    localStorage.removeItem('user');
                    navigate('/login');
                }
            } finally {
                setLoading(false);
            }
        };

        loadAndSetTask();
    }, []); // Sadece ilk render'da çalışsın

    // Backend tarafındaki tarih bilgisinin formatlanması
    const formatDate = (dateString) => {
        if (!dateString) return '';
        try {
            const date = new Date(dateString);
            return date.toLocaleDateString('tr-TR', {
                day: 'numeric',
                month: 'long',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });
        } catch {
            return 'Geçersiz tarih';
        }
    };

    if (loading) return <div className="loading-container"><p>Yükleniyor...</p></div>;
    if (error) return <Error404 errorMessage={error} className='error' />;

    return (
        <div className="body">
            <div className="update-task-container">
                <div className="update-task-title">
                    Etkinliği Güncelle
                </div>
                <form onSubmit={formik.handleSubmit} className="update-user-form">
                    <input name="id" type="hidden" value={formik.values.id} />
                    <input name="userId" type="hidden" value={formik.values.userId} />
                    
                    <div className="form-group">
                        <label htmlFor="title" className="update-task">Başlık*</label>
                        <input
                            name="title"
                            id="title"
                            type="text"
                            onChange={formik.handleChange}
                            value={formik.values.title}
                            className="update-task"
                            required
                        />
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="description" className="update-task">Açıklama</label>
                        <textarea
                            name="description"
                            id="description"
                            onChange={formik.handleChange}
                            value={formik.values.description}
                            className="update-task"
                            rows="4"
                        />
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="isCompleted" className="update-task">
                            <input
                                name="isCompleted"
                                id="isCompleted"
                                type="checkbox"
                                onChange={() => formik.setFieldValue('isCompleted', !formik.values.isCompleted)}
                                checked={formik.values.isCompleted}
                                className="update-task"
                            />
                            Tamamlandı olarak işaretle
                        </label>
                    </div>
                    
                    {formik.values.isCompleted && (
                        <div className="form-group">
                            <label htmlFor="completedAt" className="update-task">Tamamlanma Tarihi</label>
                            <input
                                name="completedAt"
                                id="completedAt"
                                type="datetime-local"
                                onChange={(e) => {
                                    const isoDate = e.target.value ? new Date(e.target.value).toISOString() : null;
                                    formik.setFieldValue('completedAt', isoDate);
                                }}
                                value={formik.values.completedAt ? 
                                    new Date(formik.values.completedAt).toISOString().slice(0, 16) : ''}
                                className="update-task"
                            />
                            {formik.values.completedAt && (
                                <p className="date-preview">
                                    Seçilen Tarih: {formatDate(formik.values.completedAt)}
                                </p>
                            )}
                        </div>
                    )}
                    
                    <button 
                        type="submit" 
                        className="update-button" 
                        disabled={formik.isSubmitting || loading}
                    >
                        {formik.isSubmitting ? 'Kaydediliyor...' : 'Kaydet'}
                    </button>
                </form>
            </div>
        </div>
    );
};

export default UpdateTask;