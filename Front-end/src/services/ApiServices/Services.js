import axios from '../axios-customize';

const ServicesProductApi = async () => {
    return axios.get(`/InsuranceProduct`);
};

export {
    ServicesProductApi
}; 