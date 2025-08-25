const TOKEN_KEY = 'authToken';

const tokenService = {
    // Token localStorage üzerine eklenir
    setToken: (token) => {
        if (typeof token === 'string') {
            localStorage.setItem(TOKEN_KEY, token);
        }
        else {
            console.error('Token must be a string');
        }
    },
    //Token getirme 
    getToken: () => {
        return localStorage.getItem(TOKEN_KEY);
    },
    // Token silme
    removeToken: () => {
        localStorage.removeItem(TOKEN_KEY);
    },
    // Kullanıcının giriş durumunu kontrol etme
    isAuthenticated: () => {
        return !!localStorage.getItem(TOKEN_KEY);
    },
};
export default tokenService;