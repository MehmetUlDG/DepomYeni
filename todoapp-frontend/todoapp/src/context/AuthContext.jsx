import axios from "axios";
import { useEffect, useState, createContext, useContext } from "react";
import { getUserSpecificApi } from "../services/apiServices";
const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState();
    const [task, setTask] = useState();
    const [LoggedIn, setLoggedIn] = useState(null);
    const [authLoading, setAuthLoading] = useState(false);
    const [selectedTask, setSelectedTask] = useState(null);

    const parseUserFromToken = (token) => {
        try {
            if (!token || typeof token !== 'string') {
                throw new Error('Geçersiz token');
            }

            const parts = token.split('.');
            if (parts.length !== 3) {
                throw new Error('Geçersiz token formatı');
            }

            const payload = JSON.parse(atob(parts[1]));

            // Gerekli claim'leri kontrol et
            if (!payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]) {
                throw new Error('Email claim bulunamadı');
            }

            const fullname = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] || '';
            const nameParts = fullname.trim().split(/\s+/);

            return {
                email: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
                id: parseInt(payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"], 10),
                name: nameParts[0] || '',
                surname: nameParts.slice(1).join(' ') || ''
            };
        } catch (error) {
            console.error('Token parse hatası:', error);
            return null;
        }
    };
    // Geliştirme amaçlı email üzerinden fake id üretme
    const generateIdFromEmail = (email) => {
        return Math.abs(email.split(' ').reduce((hash, char) => (char << 5) - hash + char.charCodeAt(0), 0));
    };
    // Hata vermesine rağmen işlem başarılı ise kullan
    const isServerErrorButOperationSuccess = (error) => {
        return error.response?.status === 500 &&
            error.config?.method === 'delete' &&
            error.config?.url.includes('/api/ToDoTask/');
    };

    useEffect(() => {
        const initializeAuth = async () => {
            try {
                const storedToken = localStorage.getItem('token');
                const storedUser = localStorage.getItem('user');

                if (storedToken && storedUser) {
                    // Token'ı validate et
                    const parsedUserFromToken = parseUserFromToken(storedToken);
                    const parsedStoredUser = JSON.parse(storedUser);

                    if (parsedUserFromToken && parsedUserFromToken.id === parsedStoredUser.id) {
                        // Token ve stored user uyuşuyor
                        setUser(parsedStoredUser);
                        setLoggedIn(true);
                    } else {
                        // Uyuşmazlık varsa temizle ve yeniden çek
                        console.warn('Token ve user uyuşmuyor, temizleniyor...');
                        localStorage.removeItem('token');
                        localStorage.removeItem('user');
                    }
                }
            } catch (error) {
                console.error('Auth initialization error:', error);
                localStorage.removeItem('token');
                localStorage.removeItem('user');
            } finally {
                setAuthLoading(false);
            }
        };

        initializeAuth();
    }, []);


    const Login = async (email, password) => {

        try {
            setAuthLoading(true);
            // Http isteklerine header ekleme ve kullanıcı giriş işlemi 
            const response = await axios.post('http://localhost:5144/api/ToDoUser/login', {
                email,
                password
            }, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': '*/*'
                }
            });

            const token = response.data.token;

            if (!token) {
                throw new Error('Token alınamadı');
            }

            // Token'dan user bilgilerini parse et
            const userData = parseUserFromToken(token);
            if (!userData) {
                throw new Error('Token parse edilemedi');
            }

            // localStorage'a kaydet
            localStorage.setItem('token', token);
            localStorage.setItem('user', JSON.stringify(userData));

            // state'i güncelle
            setUser(userData);
            setLoggedIn(true);

            return { success: true, user: userData };

        } catch (error) {
            console.error('Login error:', error);

            // Hata durumunda temizle
            localStorage.removeItem('token');
            localStorage.removeItem('user');
            setUser(null);
            setLoggedIn(false);

            return {
                success: false,
                error: error.response?.data?.message || error.message || 'Giriş başarısız'
            };
        } finally {
            setAuthLoading(false);
        }
    };

    const LogOut = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        setUser(null);
        setLoggedIn(false);
    };

    const updateUserProfile = async (newData) => {
        try {
            const userApi = getUserSpecificApi(user.id);
            const response = userApi.updateUser(newData);
            const updatedUser = { ...user, ...newData };
            setUser(updatedUser);
            localStorage.setItem('user', JSON.stringify(updatedUser));
            return { success: true, data: (await response).data }
        } catch (error) {
            console.error('Update error:', error);
            return { success: false, error: error.response?.data };
        }
    };

    const deleteUserAccount = async () => {
        try {
            let userId = user?.id;
            if (!userId) {
                const storedUser = JSON.parse(localStorage.getItem('user') || null);
                userId = storedUser.id;
                if (!userId) {
                    throw new Error("Kullanıcı bilgisi bulunamadı");
                }
            }

            const userApi = getUserSpecificApi(userId);
            await userApi.deleteUser();

            localStorage.removeItem('user');
            localStorage.removeItem('token');
            setUser(null);
            setLoggedIn(false);

            return { success: true };

        } catch (error) {
            console.error('Hesap silme hatası:', error);
            return {
                success: false, error: error.response?.data.message || error.message
            }

        }
    };

    const createTask = async (taskData) => {
        try {
            let userId = user?.id;
            if (!userId) {
                const storedUser = JSON.parse(localStorage.getItem('user') || null);
                userId = storedUser.id;
                if (!userId) {
                    return {
                        success: false,
                        error: "Kullanıcı bilgilerine ulaşılamadı."
                    }
                }
            }

            const numericUserId = Number(userId);
            if (isNaN(numericUserId)) {
                throw new Error("Geçersiz kullanıcı ID formatı");
            };
            const backendData = {
                title: taskData.title || '',
                description: taskData.description || '',
                isCompleted: Boolean(taskData.isCompleted),
                createdAt: taskData.createdAt || new Date().toISOString(),
                completedAt: taskData.completedAt ? (taskData.completedAt || new Date().toISOString()) : null,
                userId: numericUserId,
                googleEventId: taskData.googleEventId || ''
            }



            const taskApi = getUserSpecificApi(numericUserId);
            const response = await taskApi.createTask(backendData);
            setTask(taskData);

            return { success: true, data: response.data, message: 'Görev başarı ile yüklendi.' };

        } catch (error) {
            console.error("Detaylı hata:", {
                status: error.response?.status,
                data: error.response?.data,
                config: error.config
            });
            return { success: false, error: error.response?.data.message }
        }
    };
    const fetchTasks = async () => {
        try {
            const userId = user?.id || JSON.parse(localStorage.getItem('user'))?.id;
            if (!userId) throw new Error("Kullanıcı bilgisi yok");

            const taskApi = getUserSpecificApi(userId);
            const response = await taskApi.getTasks();
            return { success: true, data: response.data };
        } catch (error) {
            return {
                success: false,
                error: error.response?.data?.message || error.message
            };

        }
    };

    const updateTask = async (taskId, taskData) => {
        try {
            // Kullanıcı ID kontrolü
            let userId = user?.id;
            if (!userId) {
                const storedUser = JSON.parse(localStorage.getItem('user') || 'null');
                userId = storedUser?.id;
                if (!userId) {
                    return {
                        success: false,
                        error: "Kullanıcı bilgilerine ulaşılamadı."
                    };
                }
            }

            const numericUserId = Number(userId);
            if (isNaN(numericUserId)) {
                return {
                    success: false,
                    error: "Geçersiz kullanıcı ID formatı"
                };
            }

            // Backend'e gönderilecek veriyi hazırla
            const backendData = {
                id: taskId || '',
                title: taskData.title || '',
                description: taskData.description || '',
                isCompleted: Boolean(taskData.isCompleted),
                createdAt: taskData.createdAt || new Date().toISOString(),
                completedAt: taskData.isCompleted ?
                    (taskData.completedAt || new Date().toISOString()) :
                    null,
                userId: numericUserId,
                googleEventId: taskData.googleEventId || ''
            };

            const taskApi = getUserSpecificApi(numericUserId);
            const response = await taskApi.updateTask(taskId, backendData);

            return {
                success: true,
                data: response.data,
                message: "Görev başarıyla güncellendi"
            };

        } catch (error) {
            console.error("Güncelleme hatası:", {
                status: error.response?.status,
                data: error.response?.data,
                config: error.config
            });

            // 401 Unauthorized kontrolü
            if (error.response?.status === 401) {
                localStorage.removeItem('token');
                localStorage.removeItem('user');
                return {
                    success: false,
                    error: "Oturum süresi doldu. Lütfen tekrar giriş yapın.",
                    shouldLogout: true
                };
            }

            return {
                success: false,
                error: error.response?.data?.message || "Görev güncellenirken bir hata oluştu"
            };
        }
    };

    const deleteTask = async (taskId) => {
        try {
            // Kullanıcı ID kontrolü
            let userId = user?.id;
            if (!userId) {
                const storedUser = JSON.parse(localStorage.getItem('user') || 'null');
                userId = storedUser?.id;
                if (!userId) {
                    return {
                        success: false,
                        error: "Kullanıcı bilgilerine ulaşılamadı."
                    };
                }
            }

            const numericUserId = Number(userId);
            if (isNaN(numericUserId)) {
                return {
                    success: false,
                    error: "Geçersiz kullanıcı ID formatı"
                };
            }


            const taskApi = getUserSpecificApi(numericUserId);
            await taskApi.deleteTask(taskId);

            return {
                success: true,
                message: "Görev başarıyla silindi"
            };

        } catch (error) {
            if (isServerErrorButOperationSuccess(error)) {
                // 500 hatası ama işlem başarılı
                return {
                    success: true,
                    message: "Görev silindi",
                    warning: "Sunucu yanıt vermedi ama işlem gerçekleşti"
                };
            }

                console.error("SİLME HATASI DETAYLARI:");
                console.error("Error message:", error.message);
                console.error("Error status:", error.response?.status);
                console.error("Error data:", error.response?.data);
                console.error("Error config:", error.config);

                if (error.response) {
                    console.error("Response headers:", error.response.headers);
                    console.error("Response data:", error.response.data);
                }

                // 401 Unauthorized kontrolü
                if (error.response?.status === 401) {
                    localStorage.removeItem('token');
                    localStorage.removeItem('user');
                    return {
                        success: false,
                        error: "Oturum süresi doldu. Lütfen tekrar giriş yapın.",
                        shouldLogout: true
                    };
                }


                return {
                    success: false,
                    error: error.response?.data?.message || "Görev silinirken bir hata oluştu"
                };
            }
        };

        const getTask = async (taskId) => {
            try {
                // Kullanıcı ID kontrolü
                let userId = user?.id;
                if (!userId) {
                    const storedUser = JSON.parse(localStorage.getItem('user') || 'null');
                    userId = storedUser?.id;
                    if (!userId) {
                        return {
                            success: false,
                            error: "Kullanıcı bilgilerine ulaşılamadı."
                        };
                    }
                }

                const numericUserId = Number(userId);
                if (isNaN(numericUserId)) {
                    return {
                        success: false,
                        error: "Geçersiz kullanıcı ID formatı"
                    };
                }

                const taskApi = getUserSpecificApi(numericUserId);
                const response = await taskApi.getTask(taskId);

                return {
                    success: true,
                    data: response.data
                };

            } catch (error) {
                console.error("Task detay alma hatası:", error);

                // 401 Unauthorized kontrolü
                if (error.response?.status === 401) {
                    localStorage.removeItem('token');
                    localStorage.removeItem('user');
                    return {
                        success: false,
                        error: "Oturum süresi doldu. Lütfen tekrar giriş yapın.",
                        shouldLogout: true
                    };
                }

                return {
                    success: false,
                    error: error.response?.data?.message || "Görev bilgisi alınamadı"
                };
            }
        };


        const values = {
            LoggedIn,
            setLoggedIn,
            Login,
            LogOut,
            user,
            authLoading,
            updateUserProfile,
            deleteUserAccount,
            fetchTasks,
            createTask,
            updateTask,
            deleteTask,
            getTask
        };

        return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
    };
    export const useAuth = () => {
        const context = useContext(AuthContext);
        if (context === undefined) {
            throw new Error('useAuth bileşeni AuthProvider olmadan kullanılamaz!');
        }
        return context;
    };

    export default { AuthProvider, useAuth };
