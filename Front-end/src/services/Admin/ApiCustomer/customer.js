import axios from '../../axios-customize';

export const CustomersApi = () => {
    return axios.get('/customer');
};
