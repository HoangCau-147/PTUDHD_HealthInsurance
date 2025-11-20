import axios from '../../axios-customize';

export const benefitsApi = () => {
    return axios.get('/InsuranceBenefitType');
};
export const addIBenefitApi = (idBenefitType, benefitName, description) => {
    return axios.post(`/benefitType/${idBenefitType}/benefit`, { benefitName, description });
};
export const addIBenefitTypeApi = (name, benefits) => {
    return axios.post(`/InsuranceBenefitType`, { name, benefits });
};
export const updateBenefitApi = () => {
    return axios.post('/InsuranceBenefitType');
};
export const getBenefitByIdApi = (id) => {
    return axios.get(`/InsuranceBenefitType/${id}`);
};
