import axios from '../axios-customize';

export const HomeApi = async () => {
    return axios.get('/InsuranceProduct');
};
