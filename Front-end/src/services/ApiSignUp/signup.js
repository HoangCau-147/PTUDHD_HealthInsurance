import axios from '../axios-customize';

export const SignupApi = async (
    userName,
    password,
    email,
    roles,
    name,
    identifycationNumber,
    fullBirthday,
    phoneNumber,
    address,
) => {
    return axios.post('/authentication/Register/Customer', {
        userName,
        password,
        email,
        roles,
        name,
        identifycationNumber,
        fullBirthday,
        phoneNumber,
        address,
    });
};
