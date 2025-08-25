import * as yup from 'yup';

const validationSchema = yup.object().shape({
    name: yup.string() 
    .required('İsim alanı zorunludur.'),
    surname: yup.string().required('Soyisim alanı zorunludur.'),
    email: yup.string().email('Geçerli bir e-posta adresi giriniz.').required('E-posta alanı zorunludur.'),
    password: yup.string().min(6, 'Şifre en az 6 karakter olmalıdır.').max(18,'Şifre en fazla 18 karakter olabilir.').required('Şifre alanı zorunludur.')
});
export default validationSchema;