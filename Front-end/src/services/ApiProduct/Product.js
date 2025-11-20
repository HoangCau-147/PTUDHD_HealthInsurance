import axios from '../axios-customize';

const ProductApi = async (id) => {
    return axios.get(`/InsuranceProduct/${id}`);
};

export {
    ProductApi
};
