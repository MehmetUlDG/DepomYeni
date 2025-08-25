import './TaskCard.css';
import LoadingSpinner from './LoadingSpinner/LoadingSpinner';
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth, AuthProvider } from '../context/AuthContext';
import { getUserSpecificApi } from '../services/apiServices';
import Error404 from '../components/Error/Error';
const TaskCard = () => {
  const [tasks, setTasks] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [selectedTask, setSelectedTask] = useState(null);
  const navigate = useNavigate();
  const { user } = useAuth();
  useEffect(() => {
    const fetchTasks = async () => {

      try {
        // Etkinlik bilgilerinin listelenmesi 
        const taskApi = getUserSpecificApi(user.id);
        taskApi.getTasks()
          .then(response => {
            setTasks(response.data);
            setSelectedTask(response.data[0] || null);
            setLoading(false);
          })
      }
      catch {
        (err => {
          setError('Görevler yüklenirken hata oluştu: ' + err.message);
          setLoading(false);
        });
      }
    }
    fetchTasks();
  }, [user?.id]);// Sadece ilk render de çalışsın.


  // Backend tarafındaki tarih bilgisini formatlama
  const formatDate = (dateString) => {
    if (!dateString) return 'Tarih yok';
    try {
      return new Date(dateString).toLocaleDateString('tr-TR', {
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

  const handleAdd = () => {
    navigate('/tasklist/add');
  };
   // Etkinlik id'sine göre düzenleme işlemi 
  const handleEdit = () => {
    if (!selectedTask) {
      alert('Lütfen güncellemek için bir görev seçin.');
      return;
    }

    navigate(`/tasklist/edit/${selectedTask.id}`);
  };
   // Etkinlik id'sine göre silme işlemi
  const handleDelete = () => {
    if (!selectedTask) {
      alert('Lütfen silmek için bir görev seçin.');
      return;
    }
    navigate(`/tasklist/delete/${selectedTask.id}`);
  };

  if (loading) return <LoadingSpinner text=" Görevler yükleniyor..." />;
  if (error) return <Error404 errorMessage={error} className='error' />;
  if (tasks.length === 0) return <div className="no-task">
    <button className="add-task-button" onClick={handleAdd}>
      <span className="plus-icon">+</span> Add Task
    </button>  Görev bulunamadı </div>;
  if (!selectedTask) return <div className="no-task">
    <div className='add-task-container'>
      <button className="add-task-button" onClick={handleAdd}>
        <span className="plus-icon">+</span> Add Task</button>
    </div>
    Görev seçilmedi</div>;

  return (
    <div className="task-container">
      <div className="no-task">
        <button className="add-task-button" onClick={handleAdd}>
          <span className="plus-icon">+</span> Add Task
        </button></div>;
      {/* Görev listesi */}
      <div className="task-list">
        {tasks.map(task => (
          <div
            key={task.id}
            className={`task-item ${selectedTask.id === task.id ? 'selected' : ''} ${task.isCompleted ? 'completed-item' : ''
              }`}
            onClick={() => setSelectedTask(task)}
          >
            <div className="task-item-content">
              <span className="task-title">{task.title}</span>
              <span className={`task-status-badge ${task.isCompleted ? 'completed' : 'pending'
                }`}>
                {task.isCompleted ? '✓' : '⌛'}
              </span>
            </div>
            {task.dueDate && (
              <span className="task-due-date">
                {new Date(task.dueDate).toLocaleDateString('tr-TR', {
                  day: 'numeric',
                  month: 'short'
                })}
              </span>
            )}
          </div>
        ))}
      </div>

      {/* Seçili görev detayı */}
      <div className={`task-card ${selectedTask.isCompleted ? 'completed' : ''}`}>
        <div className="task-header">
          <h3 className="task-title">{selectedTask.title || 'Başlıksız Görev'}</h3>
          <div className={`task-status ${selectedTask.isCompleted ? 'completed' : 'pending'}`}>
            {selectedTask.isCompleted ? 'Tamamlandı' : 'Bekliyor'}
          </div>
        </div>

        <p className="task-description">{selectedTask.description || 'Açıklama yok'}</p>

        <div className="task-meta">
          <div className="meta-item">
            <i className="far fa-calendar-alt"></i>
            <span>Oluşturulma: {formatDate(selectedTask.createdAt)}</span>
          </div>

          {selectedTask.completedAt && (
            <div className="meta-item">
              <i className="far fa-calendar-check"></i>
              <span>Tamamlanma: {formatDate(selectedTask.completedAt)}</span>
            </div>
          )}

          {selectedTask.googleEventId && (
            <div className="meta-item">
              <i className="fab fa-google"></i>
              <span>Google Event ID: {selectedTask.googleEventId}</span>
            </div>
          )}
        </div>

        <div className="task-actions">
          <button className="task-button complete-btn">
            {selectedTask.isCompleted ? 'Tamamlandı' : 'Tamamla'}
          </button>
          <button className="task-button edit-btn" onClick={handleEdit}>Düzenle</button>
          <button className="task-button delete-btn" onClick={handleDelete}>Sil</button>
        </div>
      </div>
    </div>
  );
};

export default TaskCard;